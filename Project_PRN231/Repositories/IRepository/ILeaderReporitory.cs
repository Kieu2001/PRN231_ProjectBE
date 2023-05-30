using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface ILeaderReporitory
    {
        IEnumerable<AssignTask> GetAllAssignTask();
        AssignTask GetAssignTaskById(int Id);
        void InsertAssignTask(AssignTask assignTask);
        void UpdateAssignTask(AssignTask assignTask);
        void DeleteAssignTask(AssignTask assignTask);
    }
}
