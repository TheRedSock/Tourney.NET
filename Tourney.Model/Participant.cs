using System.Collections.Generic;

namespace Tourney.Model
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public List<Ranking> Rankings { get; set; }
        public List<Match> Matches { get; set; }
    }
}