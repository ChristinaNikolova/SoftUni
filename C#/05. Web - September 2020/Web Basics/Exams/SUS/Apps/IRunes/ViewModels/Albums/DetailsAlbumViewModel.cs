using IRunes.ViewModels.Tracks;
using System.Collections.Generic;

namespace IRunes.ViewModels.Albums
{
    public class DetailsAlbumViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<TrackViewModel> Tracks { get; set; }
    }
}
