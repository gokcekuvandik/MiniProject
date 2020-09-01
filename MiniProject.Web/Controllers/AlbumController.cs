using Microsoft.Ajax.Utilities;
using MiniProject.Data.IRepository;
using MiniProject.Data.Models;
using MiniProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Web.Controllers
{
    public class AlbumController : Controller
    {
        public AlbumViewModel VM = new AlbumViewModel();

        public AlbumController(IAlbumRepository albumRepository, IPhotoRepository photoRepository, ICommentRepository commentRepository)
        {
            VM.PopulateAlbums();
        }

        public AlbumController()
        {

        }

        public ActionResult Display()
        {
            return View(VM);
        }
        [HttpPost]
        public ActionResult Display(FormCollection fc, AlbumViewModel vm)
        {
            if (vm.SelectedAlbumId > 0)
                VM.SetSelectedAlbumId(vm.SelectedAlbumId);
            VM.SetSelectedPhotoIndex(Convert.ToInt32(fc["SelectedPhotoId"]));
            return View(VM);
        }
    }
}