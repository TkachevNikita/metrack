using System.ComponentModel.DataAnnotations;

namespace metrack.Domain.Entities
{
    public class IssueStage
    {
        [Key]
        public Guid Id { get; set; }
        public string Title {  get; set; }
    }
}
