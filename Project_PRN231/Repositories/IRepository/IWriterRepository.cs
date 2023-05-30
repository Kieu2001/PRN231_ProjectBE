using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface IWriterRepository
    {
        IEnumerable<WritingTask> GetAllWritingTask();
        WritingTask GetWritingTaskById(int Id);
        void InsertWritingTask(WritingTask writingTask);
        void UpdateWritingTask(WritingTask writingTask);
        void DeleteWritingTask(WritingTask writingTask);
    }
}
