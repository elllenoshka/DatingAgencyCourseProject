using DatingAgencyServer.Dtos;
using DatingAgencyServer.Repositories;

namespace DatingAgencyServer.Services
{
    public class AdminService
    {
        private readonly AdminRepository adminRepository;

        public AdminService(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }

        public List<Dictionary<string, object?>> GetClients()
        {
            return adminRepository.GetClients();
        }

        public List<Dictionary<string, object?>> GetMatches()
        {
            return adminRepository.GetMatches();
        }

        public List<Dictionary<string, object?>> GetMeetings()
        {
            return adminRepository.GetMeetings();
        }

        public List<Dictionary<string, object?>> GetArchive()
        {
            return adminRepository.GetArchive();
        }

        public List<Dictionary<string, object?>> GetEmployees()
        {
            return adminRepository.GetEmployees();
        }

        public CreateMatchResponseDto CreateMatch(CreateMatchRequestDto request)
        {
            if (request.ClientProfileId <= 0)
            {
                return new CreateMatchResponseDto
                {
                    Success = false,
                    Message = "Некоректно обраний клієнт."
                };
            }

            PartnerDataDto? partnerData = adminRepository.FindPartnerForClient(request.ClientProfileId);

            if (partnerData == null)
            {
                return new CreateMatchResponseDto
                {
                    Success = false,
                    Message = "Для обраного клієнта не знайдено нового сумісного партнера."
                };
            }

            string explanation;

            int compatibilityScore = CalculateCompatibility(
                partnerData.SelectedCity,
                partnerData.PartnerCity,
                partnerData.SelectedEducation,
                partnerData.PartnerEducation,
                partnerData.SelectedInterests,
                partnerData.PartnerInterests,
                partnerData.SelectedBirthDate,
                partnerData.PartnerBirthDate,
                out explanation
            );

            adminRepository.InsertMatch(
                request.ClientProfileId,
                partnerData.PartnerClientProfileId,
                compatibilityScore,
                "Створено адміністратором"
            );

            return new CreateMatchResponseDto
            {
                Success = true,
                Message = "Пару створено.",
                PartnerName = partnerData.PartnerName,
                CompatibilityScore = compatibilityScore,
                Explanation = explanation
            };
        }

        public ApiResponseDto DeleteMatch(int matchId)
        {
            if (matchId <= 0)
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Некоректний номер пари."
                };
            }

            adminRepository.DeleteMatch(matchId);

            return new ApiResponseDto
            {
                Success = true,
                Message = "Пару видалено."
            };
        }

        public ApiResponseDto ArchiveMatch(int matchId)
        {
            if (matchId <= 0)
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Некоректний номер пари."
                };
            }

            adminRepository.ArchiveMatch(matchId);

            return new ApiResponseDto
            {
                Success = true,
                Message = "Пару архівовано."
            };
        }

        public ApiResponseDto SetEmployeeStatus(ToggleEmployeeStatusRequestDto request)
        {
            if (request.UserId <= 0)
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Некоректний номер працівника."
                };
            }

            adminRepository.SetEmployeeStatus(request.UserId, request.IsActive);

            return new ApiResponseDto
            {
                Success = true,
                Message = request.IsActive
                    ? "Працівника активовано."
                    : "Працівника деактивовано."
            };
        }

        public ApiResponseDto AddEmployee(AddEmployeeRequestDto request)
        {
            if (request == null)
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Запит не може бути порожнім."
                };
            }

            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.Phone) ||
                string.IsNullOrWhiteSpace(request.Position))
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Будь ласка, заповніть всі поля."
                };
            }

            if (!request.Email.Contains("@"))
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Введіть коректний email."
                };
            }

            if (adminRepository.EmployeeEmailExists(request.Email.Trim()))
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Користувач із таким email вже існує."
                };
            }

            request.FullName = request.FullName.Trim();
            request.Email = request.Email.Trim();
            request.Password = request.Password.Trim();
            request.Phone = request.Phone.Trim();
            request.Position = request.Position.Trim();

            adminRepository.AddEmployee(request);

            return new ApiResponseDto
            {
                Success = true,
                Message = "Працівника успішно додано."
            };
        }

        private int CalculateCompatibility(
            string firstCity,
            string secondCity,
            string firstEducation,
            string secondEducation,
            string firstInterests,
            string secondInterests,
            DateTime firstBirthDate,
            DateTime secondBirthDate,
            out string explanation)
        {
            int score = 0;
            explanation = "";

            if (firstCity == secondCity)
            {
                score += 35;
                explanation += "+35% — однакове місто\n";
            }

            if (firstEducation == secondEducation)
            {
                score += 20;
                explanation += "+20% — однаковий рівень освіти\n";
            }

            if (HasCommonInterest(firstInterests, secondInterests))
            {
                score += 30;
                explanation += "+30% — знайдено спільні інтереси\n";
            }

            int firstAge = CalculateAge(firstBirthDate);
            int secondAge = CalculateAge(secondBirthDate);

            if (Math.Abs(firstAge - secondAge) <= 5)
            {
                score += 15;
                explanation += "+15% — різниця у віці не більше 5 років\n";
            }

            if (score == 0)
            {
                explanation = "Збігів за основними критеріями не знайдено.";
            }

            if (score > 100)
            {
                score = 100;
            }

            return score;
        }

        private bool HasCommonInterest(string firstInterests, string secondInterests)
        {
            if (string.IsNullOrWhiteSpace(firstInterests) ||
                string.IsNullOrWhiteSpace(secondInterests))
            {
                return false;
            }

            string[] firstWords = firstInterests.ToLower().Split(',');
            string secondText = secondInterests.ToLower();

            foreach (string word in firstWords)
            {
                string cleanWord = word.Trim();

                if (cleanWord.Length > 2 && secondText.Contains(cleanWord))
                {
                    return true;
                }
            }

            return false;
        }

        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}