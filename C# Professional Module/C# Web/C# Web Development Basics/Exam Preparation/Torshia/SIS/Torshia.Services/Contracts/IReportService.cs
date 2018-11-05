namespace Torshia.Services.Contracts
{
    using System.Linq;

    using Torshia.Models;

    public interface IReportService
    {
        IQueryable<Report> All();
        Report GetById(int id);
        void CreateReport(Report report);
    }
}