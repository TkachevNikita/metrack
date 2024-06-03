using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid StageId { get; set; }

        [ForeignKey(nameof(StageId))]
        public virtual IssueStage Stage { get; set; }
    }
}
