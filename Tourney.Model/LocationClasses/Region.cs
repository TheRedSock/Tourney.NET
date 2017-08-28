using System.Collections.Generic;

namespace Tourney.Model.LocationClasses
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<City> Cities { get; set; }
    }
}