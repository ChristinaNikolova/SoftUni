using IRunes.Services.Tracks;
using IRunes.ViewModels.Albums;
using IRunes.ViewModels.Tracks;
using SUS.HTTP;
using SUS.MvcFramework;

namespace IRunes.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var createTrackInputModel = new CreateTrackInputModel()
            {
                AlbumId = albumId,
            };

            return this.View(createTrackInputModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            if (string.IsNullOrWhiteSpace(input.Link))
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            this.tracksService.CreateTrack(input.Name, input.Price, input.Link, input.AlbumId);

            return this.Redirect($"/Albums/Details?id={input.AlbumId}");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var track = this.tracksService.GetDetailsTrack(albumId, trackId);

            return this.View(track);
        }
    }
}
