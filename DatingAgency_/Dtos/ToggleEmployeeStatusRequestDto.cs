namespace DatingAgency.Dtos
{
    public class ToggleEmployeeStatusRequestDto
    {
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}