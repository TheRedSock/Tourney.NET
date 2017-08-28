using System.Collections.Generic;

namespace Tourney.Model.LocationClasses
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public Continent Continent { get; set; }
        public List<Region> Regions { get; set; }
    }
}