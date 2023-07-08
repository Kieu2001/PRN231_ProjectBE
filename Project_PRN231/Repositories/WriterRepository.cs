using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        public void DeleteWritingTask(WritingTask writingTask) => WriterManagement.Instance.Delete(writingTask);

        public IEnumerable<WritingTask> GetAllWritingTask() => WriterManagement.Instance.GetWritingTaskList();

        public WritingTask GetWritingTaskById(int Id) => WriterManagement.Instance.GetWritingTaskById(Id);

        public List<WritingTask> GetWritingTasksByUserId(int Id) => WriterManagement.Instance.GetWritingTaskByUserId(Id);

        public void InsertWritingTask(WritingTask writingTask) => WriterManagement.Instance.AddNew(writingTask);

        public void UpdateWritingTask(WritingTask writingTask) => WriterManagement.Instance.Update(writingTask);    
    }
}
