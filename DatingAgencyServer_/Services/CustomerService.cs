using DatingAgencyServer.Dtos;
using DatingAgencyServer.Repositories;

namespace DatingAgencyServer.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public List<Dictionary<string, object?>> GetAllPartners()
        {
            return customerRepository.GetAllPartners();
        }

        public List<Dictionary<string, object?>> FilterPartners(PartnerFilterRequestDto filter)
        {
            if (filter.AgeMin > 0 && filter.AgeMax > 0 && filter.AgeMin > filter.AgeMax)
            {
                throw new ArgumentException("Мінімальний вік не може бути більшим за максимальний.");
            }

            if (filter.HeightMin > 0 && filter.HeightMax > 0 && filter.HeightMin > filter.HeightMax)
            {
                throw new ArgumentException("Мінімальний зріст не може бути більшим за максимальний.");
            }

            return customerRepository.FilterPartners(filter);
        }
    }
}