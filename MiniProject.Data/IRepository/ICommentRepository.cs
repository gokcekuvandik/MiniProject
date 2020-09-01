using MiniProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data.IRepository
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComments();
        IEnumerable<Comment> GetCommentsByPhotoId(int photoId);
        Comment GetComment(int commentId); 
    }
}
