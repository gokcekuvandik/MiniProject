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
    public class AlbumRepository : IAlbumRepository
    {
        public IEnumerable<Album> GetAllAlbums()
        {
            return new JavaScriptSerializer()
                .Deserialize<Album[]>(Helper.GetRestResponse("http://jsonplaceholder.typicode.com/albums").Content);
        }

        public Album GetAlbum(int albumId)
        {
            return GetAllAlbums().SingleOrDefault(x => x.Id == albumId);
        }
    }
}
