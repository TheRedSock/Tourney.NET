namespace Tourney.Model.LocationClasses
{
    public class City
    {
        public int RegionId { get; set; }
        public string Name { get; set; }
        public Region Region { get; set; } 
    }
}