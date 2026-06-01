namespace DatingAgencyServer.Dtos
{
    public class PartnerDataDto
    {
        public int PartnerClientProfileId { get; set; }
        public string PartnerName { get; set; } = string.Empty;

        public string SelectedCity { get; set; } = string.Empty;
        public string SelectedEducation { get; set; } = string.Empty;
        public string SelectedInterests { get; set; } = string.Empty;
        public DateTime SelectedBirthDate { get; set; }

        public string PartnerCity { get; set; } = string.Empty;
        public string PartnerEducation { get; set; } = string.Empty;
        public string PartnerInterests { get; set; } = string.Empty;
        public DateTime PartnerBirthDate { get; set; }
    }
}
