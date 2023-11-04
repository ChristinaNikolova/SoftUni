using IRunes.Data;
using IRunes.Models;
using IRunes.ViewModels.Tracks;
using System.Linq;

namespace IRunes.Services.Tracks
{
    public class TracksService : ITracksService
    {
        private readonly ApplicationDbContext db;

        public TracksService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrack(string name, decimal price, string link, string albumId)
        {
            var track = new Track()
            {
                Name = name,
                Price = price,
                Link = link,
                AlbumId = albumId,
            };

            this.db.Tracks.Add(track);
            this.db.SaveChanges();
        }

        public DetailsTrackViewModel GetDetailsTrack(string albumId, string trackId)
        {
            var track = this.db
                .Tracks
                .Where(t => t.AlbumId == albumId && t.Id == trackId)
                .Select(t => new DetailsTrackViewModel()
                {
                    Name = t.Name,
                    Link = t.Link,
                    Price = t.Price,
                    AlbumId = t.AlbumId,
                })
                .FirstOrDefault();

            return track;
        }
    }
}
