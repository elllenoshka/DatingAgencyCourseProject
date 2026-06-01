namespace DatingAgencyServer.Dtos
{
    public class CreateMatchResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string PartnerName { get; set; } = string.Empty;
        public int CompatibilityScore { get; set; }
        public string Explanation { get; set; } = string.Empty;
    }
}