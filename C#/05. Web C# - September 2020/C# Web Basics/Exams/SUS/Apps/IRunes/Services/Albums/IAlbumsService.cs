using IRunes.ViewModels.Albums;
using System.Collections.Generic;

namespace IRunes.Services.Albums
{
    public interface IAlbumsService
    {
        IEnumerable<AllAlbumsViewModel> GetAll();

        void CreateAlbum(string name, string cover);

        DetailsAlbumViewModel GetDetailsAlbum(string id);
    }
}
