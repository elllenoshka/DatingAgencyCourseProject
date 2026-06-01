using DatingAgencyServer.Dtos;
using DatingAgencyServer.Repositories;

namespace DatingAgencyServer.Services
{
    public class MeetingService
    {
        private readonly MeetingRepository meetingRepository;

        public MeetingService(MeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public List<Dictionary<string, object?>> GetSelectedMatch(int matchId)
        {
            return meetingRepository.GetSelectedMatch(matchId);
        }

        public List<Dictionary<string, object?>> GetMeetingsForMatch(int matchId)
        {
            return meetingRepository.GetMeetingsForMatch(matchId);
        }

        public ApiResponseDto CreateMeeting(CreateMeetingRequestDto request)
        {
            if (request.MatchId <= 0)
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Не обрано пару для організації зустрічі."
                };
            }

            if (string.IsNullOrWhiteSpace(request.Format) ||
                string.IsNullOrWhiteSpace(request.Location) ||
                string.IsNullOrWhiteSpace(request.Result) ||
                string.IsNullOrWhiteSpace(request.Notes))
            {
                return new ApiResponseDto
                {
                    Success = false,
                    Message = "Заповніть формат, місце, статус і примітки."
                };
            }

            meetingRepository.CreateMeeting(request);

            return new ApiResponseDto
            {
                Success = true,
                Message = "Зустріч успішно організовано."
            };
        }
    }
}