using metrack.Domain.Context;
using metrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace metrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController(DataContext context) : ControllerBase
    {
        private readonly DataContext _db = context;

        [HttpGet]
        public async Task<List<Issue>> GetUsers()
        {
            return await _db.Issues.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Issue>> CreateUser(Issue issue)
        {
            this._db.Issues.Add(issue);
            await this._db.SaveChangesAsync();

            return Ok(issue);
        }

    }
}
