namespace VotingSystem.API.DTO.Elections
{
    public class UpdateElectionDTO
    {
        public int ElectionID { get; set; }
        public string ElectionName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ElectionStatus { get; set; }
    }
}
