using metrack.Domain.Context;
using metrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace metrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController(DataContext context, ILogger<IssuesController> logger) : ControllerBase
    {
        private readonly DataContext _db = context;
        private readonly ILogger<IssuesController> _logger = logger;

        [HttpGet]
        public async Task<List<Issue>> GetUsers()
        {
            return await _db.Issues.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Issue>> CreateIssue(Issue issue)
        {
            if (string.IsNullOrWhiteSpace(issue.Title))
                return BadRequest("Название задачи не может быть пустым");

            _db.Issues.Add(issue);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания задачи");
                return BadRequest("Ошибка создания задачи");
            }

            return Ok(issue);
        }

        [HttpPut]
        public async Task<ActionResult<Issue>> PutIssue(Issue issue)
        {
            if (string.IsNullOrWhiteSpace(issue.Title))
                return BadRequest("Название задачи не может быть пустым");

            var existingIssue = await _db.Issues.FirstOrDefaultAsync(t => t.Id == issue.Id);

            if (existingIssue == null)
                return NotFound("Задача не найдена");

            var resultIssue = new Issue
            {
                Id = existingIssue.Id,
                Title = issue.Title,
                Owner = issue.Owner,
                Status = issue.Status,
                Period = issue.Period,
            };

            _db.Update(resultIssue);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка редактирования задачи");
                return BadRequest("Ошибка редактирования задачи");
            }

            return Ok(resultIssue);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Issue>> DeleteIssue(Guid id)
        {
            var issue = await _db.Issues.FirstOrDefaultAsync(t => t.Id == id);

            if (issue == null)
                return NotFound();

            try
            {
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Ошибка редактирования задачи");
                return BadRequest("Ошибка редактирования задачи");
            }


            return Ok();
        }
    }
}
