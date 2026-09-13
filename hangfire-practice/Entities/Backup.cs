using System.ComponentModel.DataAnnotations;

namespace hangfire_practice.Entities
{
    public class Backup
    {
        [Key]
        public int Id { get; set; }
        public int JobTaskId { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }
}
