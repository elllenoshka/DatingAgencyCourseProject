namespace DatingAgency.Dtos
{
    public class PartnerFilterRequestDto
    {
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public int HeightMin { get; set; }
        public int HeightMax { get; set; }
        public string City { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
    }
}