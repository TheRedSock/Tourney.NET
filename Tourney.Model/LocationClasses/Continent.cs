using System.Collections.Generic;

namespace Tourney.Model.LocationClasses
{
    public class Continent
    {
        public int ContinentId { get; set; }
        public string Name { get; set; } 
        public List<Country> Countries { get; set; }
    }
}
