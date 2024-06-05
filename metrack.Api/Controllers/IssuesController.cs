using Amazon.S3;
using Amazon.S3.Model;
using metrack.Api.DTO;
using metrack.Api.Services;
using metrack.Domain.Context;
using metrack.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace metrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController(DataContext context, ILogger<IssuesController> logger) : ControllerBase
    {
        private readonly DataContext _db = context;
        private readonly ILogger<IssuesController> _logger = logger;

        [HttpGet()]
        public async Task<IActionResult> GetIssues()
        {
            return Ok(await _db.Issues.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Issue>> CreateIssue(IssueDTO issue)
        {

            var photoUuid = Guid.NewGuid().ToString();

            await CloudService.UploadFile(issue.Photo, photoUuid);

            var newIssue = new Issue
            {
                Name = issue.Name,
                Phone = issue.Phone,
                CreatedAt = DateTime.UtcNow,
                Photo = "https://storage.yandexcloud.net/metrack-bucket/" + photoUuid + '.' + Path.GetExtension(issue.Photo.FileName),
                Email = issue.Email,
            };

            if (string.IsNullOrWhiteSpace(issue.Name))
                return BadRequest("Имя контакта не может быть пустым");

            _db.Issues.Add(newIssue);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания контакта");
                return BadRequest("Ошибка создания контакта");
            }

            return Ok(newIssue);
        }

        [HttpPut]
        public async Task<ActionResult<Issue>> PutIssue(Issue issue)
        {
            if (string.IsNullOrWhiteSpace(issue.Name))
                return BadRequest("Название контакта не может быть пустым");

            var existingIssue = await _db.Issues.FirstOrDefaultAsync(t => t.Id == issue.Id);

            if (existingIssue == null)
                return NotFound("Задача не найдена");

            var resultIssue = new Issue
            {
                Name = issue.Name,
                Phone = issue.Phone,
                CreatedAt = DateTime.UtcNow,
                Photo = issue.Photo,
                Email = issue.Email,
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

            _db.Issues.Remove(issue);

            try
            {
                CloudService.DeleleFile(issue.Photo);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка редактирования задачи");
                return BadRequest("Ошибка редактирования задачи");
            }


            return Ok();
        }
    }
}
