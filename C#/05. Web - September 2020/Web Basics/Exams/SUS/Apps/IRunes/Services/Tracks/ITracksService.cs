using IRunes.ViewModels.Tracks;

namespace IRunes.Services.Tracks
{
    public interface ITracksService
    {
        void CreateTrack(string name, decimal price, string link, string albumId);

        DetailsTrackViewModel GetDetailsTrack(string albumId, string trackId);
    }
}
