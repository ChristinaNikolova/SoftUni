using IRunes.Services.Albums;
using IRunes.ViewModels.Albums;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace IRunes.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var albums = this.albumsService.GetAll();

            return this.View(albums);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) || input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Albums/Create");
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Redirect("/Albums/Create");
            }

            if (!Uri.TryCreate(input.Cover, UriKind.Absolute, out _))
            {
                return this.Redirect("/Albums/Create");
            }

            this.albumsService.CreateAlbum(input.Name, input.Cover);

            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var album = this.albumsService.GetDetailsAlbum(id);

            return this.View(album);
        }
    }
}
