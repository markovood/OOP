using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tracks.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tracks
{
    public class MonacoRaceTrack : RaceTrack, IRaceTrack, IIdentifiable
    {
        private const string MonacoRaceTrackName = "Monaco Race Track";
        private const int MonacoRaceTrackMaxParticipantsCount = 5;
        private const int MonacoRaceTrackMinParticipantsCount = 2;
        private const int MonacoRaceTrackTrackLengthInMeters = 2000;

        public MonacoRaceTrack() 
            : base(
                  MonacoRaceTrackName,
                  MonacoRaceTrackMaxParticipantsCount,
                  MonacoRaceTrackMinParticipantsCount,
                  MonacoRaceTrackTrackLengthInMeters
                  )
        {
        }
    }
}
