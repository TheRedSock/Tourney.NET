using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tourney.Model
{
    public class Ranking
    {
        public int RankingId { get; set; }
        public string Name { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public Location Location { get; set; }
    }
}
