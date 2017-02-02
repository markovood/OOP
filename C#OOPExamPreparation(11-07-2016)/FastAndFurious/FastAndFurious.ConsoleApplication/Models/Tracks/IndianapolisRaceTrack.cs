using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tracks.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tracks
{
    public class IndianapolisRaceTrack : RaceTrack, IRaceTrack, IIdentifiable
    {
        private const string IndianapolisRaceTrackName = "Indianapolis Race Track";
        private const int IndianapolisRaceTrackMaxParticipantsCount = 7;
        private const int IndianapolisRaceTrackMinParticipantsCount = 2;
        private const int IndianapolisRaceTrackTrackLengthInMeters = 12000;

        public IndianapolisRaceTrack() 
            : base(
                  IndianapolisRaceTrackName,
                  IndianapolisRaceTrackMaxParticipantsCount,
                  IndianapolisRaceTrackMinParticipantsCount,
                  IndianapolisRaceTrackTrackLengthInMeters
                  )
        {
        }
    }
}
