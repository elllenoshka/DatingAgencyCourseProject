using System;

namespace DatingAgency.Dtos
{
    public class CreateMeetingRequestDto
    {
        public int MatchId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime MeetingDate { get; set; }
        public string Format { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}