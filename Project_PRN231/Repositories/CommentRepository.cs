using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public void DeleteComment(int id) => CommentManagement.Instance.Delete(id);


        public IEnumerable<CommentDTO> GetCommentBrowseList() => CommentManagement.Instance.GetCommentBrowseList();

        public Comment GetCommentById(int Id) => CommentManagement.Instance.GetCommentById(Id);


        public void InsertComment(Comment comment) => CommentManagement.Instance.AddNew(comment);


        public void UpdateCommentFalse(int Id) => CommentManagement.Instance.UpdateFalse(Id);


        public void UpdateCommentTrue(int Id) => CommentManagement.Instance.UpdateTrue(Id);

    }
}
