using System;
using System.Collections.Generic;
using Tourney.DataAccess;
using Tourney.Model;
using Tourney.Model.LocationClasses;
using Tourney.Model.ParticipantClasses;

namespace Tourney.SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            try // Safeguard the operations
            {
                // Test the model
                var continent = new Continent() { Name = "Europe", Countries = new List<Country>()};
                var country = new Country() { Name = "Norway", Continent = continent, Regions = new List<Region>()};
                var region = new Region() { Name = "Østfold", Country = country, Cities = new List<City>() };
                var city = new City() { Name = "Halden", Region = region };
                continent.Countries.Add(country);
                country.Regions.Add(region);
                region.Cities.Add(city);

                var location = new Location() { Continent = continent, Country = country, Region = region, City = city };

                var person = new Person() {
                    FirstName = "Torstein",
                    LastName = "Røsok",
                    Birthdate = new DateTime(1993, 04, 23),
                    Nationality = location,
                    Residence = location,
                    Players = new List<Player>()
                };

                var player = new Player("TheRedSock", person);
                

                // Test persisting the model to the database
                using (var db = new TourneyContext())
                {
                    db.Continents.Add(continent);
                    db.Countries.Add(country);
                    db.Regions.Add(region);
                    db.Cities.Add(city);
                    db.Locations.Add(location);
                    db.People.Add(person);

                    db.SaveChanges();
                }
                Console.WriteLine("Operations completed successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Bugger, something bad happened :-( ");
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
