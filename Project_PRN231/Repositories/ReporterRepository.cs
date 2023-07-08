using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class ReporterRepository : IReporterRepository
    {
        public void DeleteReportTask(ReportTask reportTask) => ReporterManagement.Instance.Delete(reportTask);

        public IEnumerable<ReportTask> GetAllTask() => ReporterManagement.Instance.GetReportTaskList();

        public List<ReportTask> GetReportTaskByUserId(int Id) => ReporterManagement.Instance.GetReportTaskByUserId(Id);

        public ReportTask GetTaskById(int Id) => ReporterManagement.Instance.GetReportTaskById(Id);

        public void InsertReportTask(ReportTask reportTask) => ReporterManagement.Instance.AddNew(reportTask);

        public void UpdateReportTask(ReportTask reportTask) => ReporterManagement.Instance.Update(reportTask);  
    }
}
