﻿using metrack.Domain.Context;
using metrack.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace metrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueStagesController(DataContext context, ILogger<IssueStagesController> logger) : ControllerBase
    {
        private readonly DataContext _db = context;
        private readonly ILogger<IssueStagesController> _logger = logger;

        //[HttpGet]
        //public async Task<List<IssueStage>> GetIssueStages()
        //{
            
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult<IssueStage>> EditIssueStage(IssueStage issueStage)
        {
            var newIssueStage = new IssueStage
            {
                Id = issueStage.Id,
                Title = issueStage.Title,
                //Issues = issueStage.Issues
            };

            _db.Update(newIssueStage);
            await _db.SaveChangesAsync();

            return Ok(newIssueStage);
        }

        [HttpPost]
        public async Task<ActionResult<IssueStage>> CreateIssueStage(IssueStage issueStage)
        {
            _db.Stages.Add(issueStage);
            await _db.SaveChangesAsync();

            return Ok(issueStage);
        }

        [HttpGet]
        public async Task<ActionResult<List<IssueStage>>> GetIssueStages()
        {
            return Ok(await _db.Stages.ToListAsync());
        }

    }
}
