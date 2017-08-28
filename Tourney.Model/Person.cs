using System.Collections.Generic;
using Tourney.Model.ParticipantClasses;

namespace Tourney.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Player> Players { get; set; }
        public Location Residence { get; set; }
        public Location Nationality { get; set; }
    }
}