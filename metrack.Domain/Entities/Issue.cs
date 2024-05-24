using System.ComponentModel.DataAnnotations;

namespace metrack.Domain.Entities
{
    public class Issue
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime Period { get; set; }
        public int Status { get; set; }
        public User? Owner { get; set; }
    }
}
