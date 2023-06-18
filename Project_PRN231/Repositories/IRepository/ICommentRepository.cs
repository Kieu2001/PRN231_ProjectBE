using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDTO> GetCommentBrowseList();
        Comment GetCommentById(int Id);
        void InsertComment(Comment comment);
        void UpdateCommentTrue(int Id);
        void UpdateCommentFalse(int Id);

        void DeleteComment(int id);
    }
}
