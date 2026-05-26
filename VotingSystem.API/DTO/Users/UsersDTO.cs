namespace VotingSystem.API.DTO.Users
{
    public class UsersDTO
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public UserDetailsDTO ? UserDetails { get; set; }
    }
}
