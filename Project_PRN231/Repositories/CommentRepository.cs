using Project_PRN231.DataAccess;
using Project_PRN231.DTO;
using Project_PRN231.Models;
using Project_PRN231.Repositories.IRepository;

namespace Project_PRN231.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		public void DeleteComment(Comment comment) => CommentManagement.Instance.Delete(comment);

		public IEnumerable<CommentDTO> GetAllComment() => CommentManagement.Instance.GetCommentList();

		public Comment GetCommentById(int Id) => CommentManagement.Instance.GetCommentById(Id);


		public void InsertComment(Comment comment) => CommentManagement.Instance.AddNew(comment);


		public void UpdateComment(Comment comment) => CommentManagement.Instance.Update(comment);

	}
}
