using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class ReporterManagement
    {
        private static ReporterManagement instance = null;
        private static readonly object instanceLock = new object();
        private ReporterManagement() { }
        public static ReporterManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ReporterManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ReportTask> GetReportTaskList()
        {
            List<ReportTask> list = new List<ReportTask>();
            try
            {
                var db = new PRN231_SUContext();
                list = db.ReportTasks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public ReportTask GetReportTaskById(int taskID)
        {
            ReportTask? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.ReportTasks.SingleOrDefault(x => x.Id == taskID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public void AddNew(ReportTask reportTask)
        {
            try
            {
                ReportTask rp = GetReportTaskById(reportTask.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.ReportTasks.Add(reportTask);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This task is already done");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ReportTask reportTask)
        {
            try
            {
                ReportTask rp = GetReportTaskById(reportTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<ReportTask>(reportTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This task does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(ReportTask reportTask)
        {
            try
            {
                ReportTask rp = GetReportTaskById(reportTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.ReportTasks.Remove(reportTask);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("This task does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
