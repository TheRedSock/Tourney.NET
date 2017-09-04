using System;
using System.Collections.Generic;
using Tourney.DataAccess;
using Tourney.Model;
using Tourney.Model.LocationClasses;
using Tourney.Model.ParticipantClasses;

// Deprecated
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
                var america = new Continent("North America");
                var country = new Country("Norway", continent);
                var region = new Region("Østfold", country);
                var city = new City("Halden", region);
                continent.Countries.Add(country);
                country.Regions.Add(region);
                region.Cities.Add(city);

                var location = new Location() { Continent = continent, Country = country, Region = region, City = city };
                var na = new Location() { Continent = america };

                var person = new Person("Torstein", "Røsok")
                {
                    DateOfBirth = new DateTime(1993, 04, 23),
                    Nationality = location,
                    Residence = location
                };

                var personTwo = new Person("Jason", "Zimmerman")
                {
                    Nationality = na,
                    Residence = na
                };

                var player = new Player("TheRedSock", person);
                var playerTwo = new Player("Ultra Golgoth", person);
                var playerThree = new Player("Mew2King", personTwo);
                var playerFour = new Player("lolM2K", personTwo);
                var team = new Team("Smash Østfold") { Location = location };
                var teamTwo = new Team("North America") { Location = na };
                team.Players.Add(player);
                team.Players.Add(playerTwo);
                teamTwo.Players.Add(playerThree);
                teamTwo.Players.Add(playerFour);

                var game = new Game("Super Smash Bros. Melee");

                var tournament = new Tournament("Smash the Mill Deluxe", game) { Location = location };
                var playoffs = new Event("Showmatch", tournament);

                var matchOne = new Match(playoffs, playerThree, player) { DateTime = DateTime.Now };
                var matchTwo = new Match(playoffs, playerTwo, playerFour) { DateTime = DateTime.Now };
                var matchThree = new Match(playoffs, teamTwo, team) { DateTime = DateTime.Now };

                playoffs.Matches.Add(matchOne);
                playoffs.Matches.Add(matchTwo);
                playoffs.Matches.Add(matchThree);

                var ranking = new Ranking("SR.EU", game);
                var rankingCrew = new Ranking("Crews", game);
                ranking.Tournaments.Add(tournament);
                ranking.Participants.Add(player);
                ranking.Participants.Add(playerTwo);
                ranking.Participants.Add(playerThree);
                ranking.Participants.Add(playerFour);
                rankingCrew.Participants.Add(team);
                rankingCrew.Participants.Add(teamTwo);

                // Test persisting the model to the database
                using (var db = new TourneyContext())
                {
                    db.Continents.Add(continent);
                    db.Continents.Add(america);
                    db.Countries.Add(country);
                    db.Regions.Add(region);
                    db.Cities.Add(city);
                    db.Locations.Add(location);
                    db.Locations.Add(na);
                    db.People.Add(person);
                    db.People.Add(personTwo);
                    db.Players.Add(player);
                    db.Players.Add(playerTwo);
                    db.Players.Add(playerThree);
                    db.Players.Add(playerFour);
                    db.Teams.Add(team);
                    db.Teams.Add(teamTwo);
                    db.Games.Add(game);
                    db.Tournaments.Add(tournament);
                    db.Events.Add(playoffs);
                    db.Matches.Add(matchOne);
                    db.Matches.Add(matchTwo);
                    db.Matches.Add(matchThree);
                    db.Rankings.Add(ranking);
                    
                    // Try to save changes and return detailed error message if failed.
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                    {
                        Exception raise = dbEx;
                        foreach (var validationErrors in dbEx.EntityValidationErrors)
                        {
                            foreach (var validationError in validationErrors.ValidationErrors)
                            {
                                string message = string.Format("{0}:{1}",
                                    validationErrors.Entry.Entity.ToString(),
                                    validationError.ErrorMessage);
                                // raise a new exception nesting
                                // the current instance as InnerException
                                raise = new InvalidOperationException(message, raise);
                            }
                        }
                        throw raise;
                    }
                }
                Console.WriteLine("Operations completed successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Bugger, something bad happened :-( ");
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press ENTER to exit.");
            Console.ReadLine();
        }
    }
}
