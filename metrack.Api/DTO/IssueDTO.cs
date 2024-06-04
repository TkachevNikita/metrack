using metrack.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace metrack.Api.DTO
{
    public class IssueDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
}
