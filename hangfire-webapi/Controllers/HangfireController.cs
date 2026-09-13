using hangfire_webapi.Data;
using hangfire_webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hangfire_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangfireController : ControllerBase
    {
        private readonly AppDbContext context;
        public HangfireController(AppDbContext context)
        {
            this.context = context; 
        }

        [HttpPost]
        [Route("InsertJob")]
        public async Task <ActionResult<JobTask>> InsertJob(JobTask data)
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
    }
}
