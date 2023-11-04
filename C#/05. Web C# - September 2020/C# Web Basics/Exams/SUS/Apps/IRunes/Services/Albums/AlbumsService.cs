using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using System.Collections.Generic;
using System.Linq;

namespace IRunes.Services.Albums
{
    public class AlbumsService : IAlbumsService
    {
        private readonly ApplicationDbContext db;

        public AlbumsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateAlbum(string name, string cover)
        {
            var album = new Album()
            {
                Name = name,
                Cover = cover,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public IEnumerable<AllAlbumsViewModel> GetAll()
        {
            var albums = this.db
                .Albums
                .Select(a => new AllAlbumsViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                })
                .ToList();

            return albums;
        }

        public DetailsAlbumViewModel GetDetailsAlbum(string id)
        {
            var album = this.db
                .Albums
                .Where(a => a.Id == id)
                .Select(a => new DetailsAlbumViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    Cover = a.Cover,
                    Price = a.Tracks.Sum(t => t.Price) - a.Tracks.Sum(t => t.Price) * 0.13M,
                    Tracks = a.Tracks
                       .Select(t => new TrackViewModel()
                       {
                           Id = t.Id,
                           Name = t.Name,
                       })
                       .ToList()
                })
                .FirstOrDefault();

            return album;
        }
    }
}
