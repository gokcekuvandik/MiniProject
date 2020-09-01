using MiniProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Data.IRepository
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbum(int albumId);
    }
}
