namespace DatingAgency.Dtos
{
    public class RegisterClientRequestDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Height { get; set; }
        public string City { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Occupation { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public string AboutMe { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}