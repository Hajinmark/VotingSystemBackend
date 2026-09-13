namespace VotingSystem.API.DTO.Elections
{
    public class CreateElectionDTO
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int CreatedBy { get; set; }
       
    }
}
