using Tourney.Model.LocationClasses;

namespace Tourney.Model
{
    public class Location
    {
        public int LocationId { get; set; }
        public Continent Continent { get; set; }
        public Country Country { get; set; }
        public Region Region { get; set; }
        public City City { get; set; }
    }
}