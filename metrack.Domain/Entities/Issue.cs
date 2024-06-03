using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace metrack.Domain.Entities
{
    public class Issue
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Photo {  get; set; }
    }
}
