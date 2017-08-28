using System.Collections.Generic;

namespace Tourney.Model.ParticipantClasses
{
    public class Team : Participant
    {
        public int TeamId { get; set; }
        public List<Player> Players { get; set; }
    }
}
