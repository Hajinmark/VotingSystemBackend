using Hangfire;
using hangfire_practice.Service;

namespace hangfire_practice.Job
{
    public class DatabaseBackupJob
    {
        private readonly DatabaseBackupService service;
        private readonly IRecurringJobManager recurringJobManager;
        public DatabaseBackupJob(DatabaseBackupService service, IRecurringJobManager recurringJobManager)
        {
            this.service = service;
            this.recurringJobManager = recurringJobManager;
        }

        public void ExecuteJob()
        {
            try
            {
                recurringJobManager.AddOrUpdate<DatabaseBackupService>(
                "database-backup",
                job => job.RunBackUp(),
                "*/1 * * * *");
            }
            catch
            {
                throw new Exception();
            }
            
        }
    }
}
