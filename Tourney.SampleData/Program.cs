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
                var continent = new Continent("Europe");
                var country = new Country("Norway", continent);
                var region = new Region("Østfold", country);
                var city = new City("Halden", region);
                continent.Countries.Add(country);
                country.Regions.Add(region);
                region.Cities.Add(city);

                var location = new Location() { Continent = continent, Country = country, Region = region, City = city };

                var person = new Person("Torstein", "Røsok") {
                    DateOfBirth = new DateTime(1993, 04, 23),
                    Nationality = location,
                    Residence = location,
                    Players = new List<Player>()
                };

                var player = new Player("TheRedSock", person);

                var team = new Team("Smash Østfold");
                team.Players.Add(player);
                

                // Test persisting the model to the database
                using (var db = new TourneyContext())
                {
                    db.Continents.Add(continent);
                    db.Countries.Add(country);
                    db.Regions.Add(region);
                    db.Cities.Add(city);
                    db.Locations.Add(location);
                    db.People.Add(person);
                    db.Players.Add(player);
                    db.Teams.Add(team);

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
