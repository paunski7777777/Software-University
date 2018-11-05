namespace Torshia.Services.Contracts
{
    using Torshia.Models;

    using System.Linq;

    public interface ITaskService
    {
        IQueryable<Task> All();
        Task GetById(int id);
        void CreateTask(Task task);
    }
}