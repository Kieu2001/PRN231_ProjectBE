using Project_PRN231.DTO;
using Project_PRN231.Models;

namespace Project_PRN231.Repositories.IRepository
{
	public interface ICommentRepository
	{
		IEnumerable<CommentDTO> GetAllComment();
		Comment GetCommentById(int Id);
		void InsertComment(Comment comment);
		void UpdateComment(Comment comment);
		void DeleteComment(Comment comment);
	}
}
