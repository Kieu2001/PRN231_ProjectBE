using Microsoft.EntityFrameworkCore;
using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class LeaderManagement
    {
        private static LeaderManagement instance = null;
        private static readonly object instanceLock = new object();
        private LeaderManagement() { }
        public static LeaderManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LeaderManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<AssignTask> GetAssignTaskList()
        {
            List<AssignTask> list = new List<AssignTask>();
            try
            {
                var db = new PRN231_SUContext();
                //list = db.AssignTasks.ToList();
                list = db.AssignTasks.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public AssignTask GetAssignTaskById(int taskID)
        {
            AssignTask? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.AssignTasks.Include(x => x.Leader).Include(x => x.Reporter).Include(x => x.Writer).SingleOrDefault(x => x.Id == taskID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public void AddNew(AssignTask assignTask)
        {
            try
            {
                AssignTask rp = GetAssignTaskById(assignTask.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.AssignTasks.Add(assignTask);
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

        public void Update(AssignTask assignTask)
        {
            try
            {
                AssignTask rp = GetAssignTaskById(assignTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<AssignTask>(assignTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public void Delete(AssignTask assignTask)
        {
            try
            {
                AssignTask rp = GetAssignTaskById(assignTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.AssignTasks.Remove(assignTask);
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
