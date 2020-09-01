using MiniProject.Data.IRepository;
using MiniProject.Data.Models;
using MiniProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProject.Web.Models
{
    public class AlbumViewModel
    {
        #region Repositories
        //public IAlbumRepository _albumRepository { get; }
        //public IPhotoRepository _photoRepository { get; }
        //public ICommentRepository _commentRepository { get; }
        #endregion

        #region Constructor
        public AlbumViewModel()
        {

        }
        //public AlbumViewModel(IAlbumRepository album, IPhotoRepository photo, ICommentRepository comment)
        //{
        //    _albumRepository = album;
        //    _photoRepository = photo;
        //    _commentRepository = comment;
        //}
        #endregion

        #region Properties
        private List<Album> albums = new List<Album>();
        public List<Album> Albums { get => albums; set => albums = value; }

        private int selectedAlbumId;
        public int SelectedAlbumId { get => selectedAlbumId; set { selectedAlbumId = value; setSelectedAlbum(); } }

        private Album selectedAlbum;
        public Album SelectedAlbum { get => selectedAlbum; set { selectedAlbum = value; populatePhotos(); } }

        private List<Photo> photos = new List<Photo>();
        public List<Photo> Photos { get => photos; set => photos = value; }

        private int index;
        public int Index { get => index; set { index = value; setSelectedPhotoId(); } }

        private void setSelectedPhotoId()
        {
            if (Photos.Any())
                SelectedPhotoId = Photos[index].Id;
        }

        private int selectedPhotoId;
        public int SelectedPhotoId { get => selectedPhotoId; set { selectedPhotoId = value; setSelectedPhoto(); } }

        private Photo selectedPhoto;
        public Photo SelectedPhoto { get => selectedPhoto; set { selectedPhoto = value; populateComments(); } }

        private List<Comment> comments = new List<Comment>();

        public List<Comment> Comments { get => comments; set => comments = value; }
        #endregion

        #region Methods
        internal void PopulateAlbums()
        {
            IAlbumRepository _albumRepository = new AlbumRepository();
            Albums = _albumRepository.GetAllAlbums().ToList();
        }

        internal void SetSelectedAlbumId(int albumId)
        {
            SelectedAlbumId = albumId;
        }

        internal void SetSelectedPhotoIndex(int index)
        {
            if (index >= 0)
                Index = index;
            else
                SelectedPhoto = null;
        }


        private void setSelectedAlbum()
        {
            SelectedAlbum = Albums.SingleOrDefault(x => x.Id == selectedAlbumId);
        }
        private void setSelectedPhoto()
        {
            SelectedPhoto = Photos.SingleOrDefault(x => x.Id == selectedPhotoId);
        }
        private void populatePhotos()
        {
            IPhotoRepository _photoRepository = new PhotoRepository();
            if (selectedAlbum != null)
                Photos = _photoRepository.GetPhotosByAlbumId(selectedAlbum.Id).ToList();
        }
        private void populateComments()
        {
            ICommentRepository _commentRepository = new CommentRepository();
            if (selectedPhoto != null)
                Comments = _commentRepository.GetCommentsByPhotoId(selectedPhoto.Id).ToList();
        }
        #endregion
    }
}