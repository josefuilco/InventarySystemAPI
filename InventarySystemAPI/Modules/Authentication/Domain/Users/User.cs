namespace InventarySystemAPI.Modules.Authentication.Domain.Users
{
    public class User
    {
        public string UserId { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Email { get; set; } = "";
        public bool Active { get; set; }
    }
}