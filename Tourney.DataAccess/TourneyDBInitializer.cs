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

            context.Continents.Add(continent);
            context.Continents.Add(america);
            context.Countries.Add(country);
            context.Regions.Add(region);
            context.Cities.Add(city);
            context.Locations.Add(location);
            context.Locations.Add(na);
            context.People.Add(person);
            context.People.Add(personTwo);
            context.Players.Add(player);
            context.Players.Add(playerTwo);
            context.Players.Add(playerThree);
            context.Players.Add(playerFour);
            context.Teams.Add(team);
            context.Teams.Add(teamTwo);
            context.Games.Add(game);
            context.Tournaments.Add(tournament);
            context.Events.Add(playoffs);
            context.Matches.Add(matchOne);
            context.Matches.Add(matchTwo);
            context.Matches.Add(matchThree);
            context.Rankings.Add(ranking);

            base.Seed(context);
        }
    }
}
