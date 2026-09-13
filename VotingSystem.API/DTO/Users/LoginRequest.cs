namespace VotingSystem.API.DTO.Users
{
    public class LoginRequest
    {
        public string Username { get; set; } = null!;
        //public string ?Email { get; set; }
        public string Password { get; set; } = null!;
    }
}
