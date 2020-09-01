using MiniProject.Data.IRepository;
using MiniProject.Data.Models;
using MiniProject.Data.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MiniProject.Data.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public IEnumerable<Comment> GetAllComments()
        {
            return new JavaScriptSerializer()
                .Deserialize<Comment[]>(Helper.GetRestResponse("http://jsonplaceholder.typicode.com/comments").Content);
        }

        public IEnumerable<Comment> GetCommentsByPhotoId(int photoId)
        {
            return GetAllComments().Where(x => x.PostId == photoId);
        }

        public Comment GetComment(int commentId)
        {
            return GetAllComments().SingleOrDefault(x => x.Id == commentId);
        }
    }
}
