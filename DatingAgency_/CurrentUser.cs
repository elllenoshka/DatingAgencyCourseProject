namespace DatingAgency
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; } = string.Empty;
        public static string RoleName { get; set; } = string.Empty;

        public static void Clear()
        {
            UserId = 0;
            FullName = string.Empty;
            RoleName = string.Empty;
        }
    }
}