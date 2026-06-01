namespace DatingAgency.Dtos
{
    public class RegisterClientResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public int? ClientProfileId { get; set; }
    }
}