namespace VotingSystem.API.DTO.Users
{
    public class UsersDTO
    {
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public int RoleId { get; set; }
        public UserDetailsDTO ? UserDetails { get; set; }
    }
}
