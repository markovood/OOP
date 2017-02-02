using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tracks.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tracks
{
    public class TokioUndergroundRaceTrack : RaceTrack, IRaceTrack, IIdentifiable
    {
        private const string TokioUndergroundRaceTrackName = "Tokio Underground Race Track";
        private const int TokioUndergroundRaceTrackMaxParticipantsCount = 8;
        private const int TokioUndergroundRaceTrackMinParticipantsCount = 2;
        private const int TokioUndergroundRaceTrackTrackLengthInMeters = 5000;

        public TokioUndergroundRaceTrack() 
            : base(
                  TokioUndergroundRaceTrackName,
                  TokioUndergroundRaceTrackMaxParticipantsCount,
                  TokioUndergroundRaceTrackMinParticipantsCount,
                  TokioUndergroundRaceTrackTrackLengthInMeters
                  )
        {
        }
    }
}
