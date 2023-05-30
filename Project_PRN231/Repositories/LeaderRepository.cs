using Project_PRN231.DataAccess;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class LeaderRepository : ILeaderReporitory
    {
        public void DeleteAssignTask(AssignTask assignTask) => LeaderManagement.Instance.Delete(assignTask);

        public IEnumerable<AssignTask> GetAllAssignTask() => LeaderManagement.Instance.GetAssignTaskList();

        public AssignTask GetAssignTaskById(int Id) => LeaderManagement.Instance.GetAssignTaskById(Id);

        public void InsertAssignTask(AssignTask assignTask) => LeaderManagement.Instance.AddNew(assignTask);

        public void UpdateAssignTask(AssignTask assignTask) => LeaderManagement.Instance.Update(assignTask);
    }
}
