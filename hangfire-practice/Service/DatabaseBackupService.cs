using hangfire_practice.Data;
using Microsoft.EntityFrameworkCore;

namespace hangfire_practice.Service
{
    public class DatabaseBackupService
    {
        private readonly HangfireDbContext context;
        public DatabaseBackupService(HangfireDbContext context)
        {
            this.context = context;
        }

        public async Task RunBackUp()
        {
            await context.Database.ExecuteSqlRawAsync("EXEC sp_BackupScript");
        }

    }
}
