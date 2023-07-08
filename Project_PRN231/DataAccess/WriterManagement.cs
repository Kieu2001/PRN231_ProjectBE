using Project_PRN231.Models;

namespace Project_PRN231.DataAccess
{
    public class WriterManagement
    {
        private static WriterManagement instance = null;
        private static readonly object instanceLock = new object();
        public WriterManagement() { }

        public static WriterManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new WriterManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<WritingTask> GetWritingTaskList()
        {
            List<WritingTask> list = new List<WritingTask>();
            try
            {
                var db = new PRN231_SUContext();
                list = db.WritingTasks.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public WritingTask GetWritingTaskById(int taskID)
        {
            WritingTask? rp = null;
            try
            {
                var db = new PRN231_SUContext();
                rp = db.WritingTasks.SingleOrDefault(x => x.Id == taskID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return rp;
        }

        public List<WritingTask> GetWritingTaskByUserId(int Id)
        {
            List<WritingTask> listWriting = new List<WritingTask>();
            try
            {
                var db = new PRN231_SUContext();
                listWriting = db.WritingTasks.Where(x => x.UserId == Id).ToList();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listWriting;
        }
        public void AddNew(WritingTask writingTask)
        {
            try
            {
                WritingTask rp = GetWritingTaskById(writingTask.Id);
                if (rp == null)
                {
                    var db = new PRN231_SUContext();
                    db.WritingTasks.Add(writingTask);
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

        public void Update(WritingTask writingTask)
        {
            try
            {
                WritingTask rp = GetWritingTaskById(writingTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.Entry<WritingTask>(writingTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

        public void Delete(WritingTask writingTask)
        {
            try
            {
                WritingTask rp = GetWritingTaskById(writingTask.Id);
                if (rp != null)
                {
                    var db = new PRN231_SUContext();
                    db.WritingTasks.Remove(writingTask);
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
