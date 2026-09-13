using Hangfire;
using hangfire_practice.Data;
using hangfire_practice.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace hangfire_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly HangfireDbContext context;
        public HangfireController(HangfireDbContext context)
        {
            this.context = context;
        }

        /*
        [HttpPost]
        [Route("InsertJob")]
        public async Task<ActionResult<JobTask>> InsertJob(JobTask data)
        {

            try
            {
                var jobtask = new JobTask
                {
                    Name = data.Name,
                    Status = data.Status,
                    CreatedAt = DateTime.UtcNow,
                    ProcessedAt = DateTime.UtcNow
                };

                context.JobTasks.Add(jobtask);
                await context.SaveChangesAsync();

                return Ok(jobtask);
            }

            catch
            {
                throw new Exception();
            }
        }
        */

        [HttpGet]
        [Route("GetJob")]
        public async Task<ActionResult<JobTask>> GetJob()
        {
            try
            {
                var jobs = await context.JobTasks.ToListAsync();
                return Ok(jobs);
            }
            catch
            {
                throw;
            }
        }

        /*
        [HttpPost("StartJob")]
        public IActionResult StartJob()
        {
            BackgroundJob.Enqueue(() =>
                Console.WriteLine("Hello from Hangfire!"));

            return Ok("Job added to Hangfire.");
        }
        */

        [HttpPost]
        [Route("FireAndForget")]
        public IActionResult FireAndForget()
        {
            try
            {
                string[] names =
                {
                    "John",
                    "Mark",
                    "Peter",
                    "James",
                    "Michael"
                };

                Random random = new Random();

                string randomName = names[random.Next(names.Length)];

                var data = new JobTask
                {
                    Name = randomName,
                    Status = "Active"
                };

                BackgroundJob.Enqueue(() =>
                    DoTheJob(data)
                );

                return Ok("Job Done");
            }

            catch
            {
                throw;
            }
           
        }

        [HttpPost]
        [Route("DelayJob")]
        public IActionResult DelayJob()
        {
            try
            {
                string[] names =
                {
                    "John",
                    "Mark",
                    "Peter",
                    "James",
                    "Michael"
                };

                Random random = new Random();

                string randomName = names[random.Next(names.Length)];

                var data = new JobTask
                {
                    Name = randomName,
                    Status = "Active"
                };

                BackgroundJob.Schedule(() =>
                    DoTheJob(data), TimeSpan.FromSeconds(5)
                );

                return Ok("Delay Job");
            }

            catch
            {
                throw;
            }
        }

        public async Task<string> DoTheJob(JobTask data)
        {
            try
            {
                var dto = new JobTask
                {
                    Name = data.Name,
                    Status = data.Status,
                    CreatedAt = DateTime.Now,
                    ProcessedAt = DateTime.Now
                };

                context.Add(dto);
                await context.SaveChangesAsync();

                return "Successfully Run Job";
            }
            catch
            {
                throw;
            }
        }
    }
}
