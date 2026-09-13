using System.ComponentModel.DataAnnotations;

namespace hangfire_webapi.Entities
{
    public class JobTask
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }
}
