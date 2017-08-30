using System;
using System.Collections.Generic;
using System.Data.Entity;
using Tourney.Model;
using Tourney.Model.LocationClasses;
using Tourney.Model.ParticipantClasses;

namespace Tourney.DataAccess
{
    public class TourneyDBInitializer : DropCreateDatabaseIfModelChanges<TourneyContext>
    {
        protected override void Seed(TourneyContext context)
        {
            // Test the model
            var continent = new Continent("Europe");
            var country = new Country("Norway", continent);
            var region = new Region("Østfold", country);
            var city = new City("Halden", region);
            continent.Countries.Add(country);
            country.Regions.Add(region);
            region.Cities.Add(city);

            var location = new Location() { Continent = continent, Country = country, Region = region, City = city };

            var person = new Person("Torstein", "Røsok")
            {
                DateOfBirth = new DateTime(1993, 04, 23),
                Nationality = location,
                Residence = location,
                Players = new List<Player>()
            };

            context.Continents.Add(continent);
            context.Countries.Add(country);
            context.Regions.Add(region);
            context.Cities.Add(city);
            context.Locations.Add(location);
            context.People.Add(person);

            base.Seed(context);
        }
    }
}
