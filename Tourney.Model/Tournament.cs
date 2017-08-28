using System.Collections.Generic;

namespace Tourney.Model
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Name { get; set; }
        public List<Event> Events { get; set; }
        public List<Ranking> Rankings { get; set; }
    }
}