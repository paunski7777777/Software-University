namespace Torshia.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    
    using Torshia.Data;
    using Torshia.Models;
    using Torshia.Services.Contracts;

    public class TaskService : ITaskService
    {
        private readonly TorshiaContext db;

        public TaskService(TorshiaContext db)
        {
            this.db = db;
        }

        public IQueryable<Task> All() => this.db.Tasks;

        public void CreateTask(Task task)
        {
            this.db.Tasks.Add(task);
            this.db.SaveChanges();
        }

        public Task GetById(int id) => this.db.Tasks.Include(a => a.AffectedSectors).FirstOrDefault(t => t.Id == id);
    }
}