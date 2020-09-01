using MiniProject.Data.IRepository;
using MiniProject.Data.Models;
using MiniProject.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MiniProject.Data.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        public IEnumerable<Photo> GetAllPhotos()
        {
            return new JavaScriptSerializer()
                .Deserialize<Photo[]>(Helper.GetRestResponse("http://jsonplaceholder.typicode.com/photos").Content);
        }

        public IEnumerable<Photo> GetPhotosByAlbumId(int albumId)
        {
            return GetAllPhotos().Where(x => x.AlbumId == albumId);
        }

        public Photo GetPhoto(int photoId)
        {
            return GetAllPhotos().SingleOrDefault(x => x.Id == photoId);
        }
    }
}
