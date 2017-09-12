using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tourney.Model;

namespace Tourney.DataAccess
{
    /// <summary>
    /// Database context for the application.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class TourneyContext : DbContext
    {
        /// <summary>
        /// Gets or sets the rankings.
        /// </summary>
        /// <value>
        /// The rankings.
        /// </value>
        public virtual DbSet<Ranking> Rankings { get; set; }

        /// <summary>
        /// Gets or sets the tournaments.
        /// </summary>
        /// <value>
        /// The tournaments.
        /// </value>
        public virtual DbSet<Tournament> Tournaments { get; set; }

        /// <summary>
        /// Gets or sets the games.
        /// </summary>
        /// <value>
        /// The games.
        /// </value>
        public virtual DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the Phases.
        /// </summary>
        /// <value>
        /// The Phases.
        /// </value>
        public virtual DbSet<Phase> Phases { get; set; }

        /// <summary>
        /// Gets or sets the matches.
        /// </summary>
        /// <value>
        /// The matches.
        /// </value>
        public virtual DbSet<Match> Matches { get; set; }

        /// <summary>
        /// Gets or sets the participants.
        /// </summary>
        /// <value>
        /// The participants.
        /// </value>
        public virtual DbSet<Participant> Participants { get; set; }

        /// <summary>
        /// Gets or sets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public virtual DbSet<Player> Players { get; set; }

        /// <summary>
        /// Gets or sets the teams.
        /// </summary>
        /// <value>
        /// The teams.
        /// </value>
        public virtual DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Gets or sets the people.
        /// </summary>
        /// <value>
        /// The people.
        /// </value>
        public virtual DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>
        /// The locations.
        /// </value>
        public virtual DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the continents.
        /// </summary>
        /// <value>
        /// The continents.
        /// </value>
        public virtual DbSet<Continent> Continents { get; set; }

        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public virtual DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the regions.
        /// </summary>
        /// <value>
        /// The regions.
        /// </value>
        public virtual DbSet<Region> Regions { get; set; }

        /// <summary>
        /// Gets or sets the cities.
        /// </summary>
        /// <value>
        /// The cities.
        /// </value>
        public virtual DbSet<City> Cities { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            // Remove various EF conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Changes the default datetime type to datetime2 instead of SqlDateTime.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            
            // Build the model.
            RankingTournamentBuilder(modelBuilder);
            RankingParticipantBuilder(modelBuilder);
            ParticipantTournamentBuilder(modelBuilder);
            PlayerTeamBuilder(modelBuilder);
            PhaseTournamentBuilder(modelBuilder);
            MatchPhaseBuilder(modelBuilder);
            MatchWinnerBuilder(modelBuilder);
            MatchLoserBuilder(modelBuilder);
            PlayerPersonBuilder(modelBuilder);
            PersonResidenceBuilder(modelBuilder);
            PersonNationalityBuilder(modelBuilder);
            TeamLocationBuilder(modelBuilder);
            RankingLocationBuilder(modelBuilder);
            TournamentLocationBuilder(modelBuilder);
            LocationContinentBuilder(modelBuilder);
            LocationCountryBuilder(modelBuilder);
            LocationRegionBuilder(modelBuilder);
            LocationCityBuilder(modelBuilder);
            CityRegionBuilder(modelBuilder);
            RegionCountryBuilder(modelBuilder);
            CountryContinentBuilder(modelBuilder);
        }

        public TourneyContext()
        {
            Configuration.ProxyCreationEnabled = false;

            // This deletes and recreates an empty database if the model has changed.
            Database.SetInitializer(new TourneyDBInitializer()); 
        }

        /// <summary>
        /// Maps the many-to-many relation between the Ranking class and the Tournament class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void RankingTournamentBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ranking>()
                    .HasMany(a => a.Tournaments)
                    .WithMany(b => b.Rankings)
                    .Map(m =>
                    {
                m.ToTable("RankingTournament");
                m.MapLeftKey("RankingId");
                m.MapRightKey("TournamentId");
            });
        }

        /// <summary>
        /// Maps the many-to-many relation between the Ranking class and the Participant class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void RankingParticipantBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ranking>()
                .HasMany(a => a.Participants)
                .WithMany(b => b.Rankings)
                .Map(m =>
                {
                    m.ToTable("RankingParticipant");
                    m.MapLeftKey("RankingId");
                    m.MapRightKey("ParticipantId");
                });
        }

        /// <summary>
        /// Maps the many-to-many relation between the Participant class and the Tournament class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void ParticipantTournamentBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .HasMany(a => a.Tournaments)
                .WithMany(b => b.Participants)
                .Map(m =>
                {
                    m.ToTable("ParticipantTournament");
                    m.MapLeftKey("ParticipantId");
                    m.MapRightKey("TournamentId");
                });
        }

        /// <summary>
        /// Maps the many-to-many relation between the Player class and the Team class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void PlayerTeamBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(a => a.Teams)
                .WithMany(b => b.Players)
                .Map(m =>
                {
                    m.ToTable("PlayerTeam");
                    m.MapLeftKey("PlayerId");
                    m.MapRightKey("TeamId");
                });
        }

        /// <summary>
        /// Maps the one-to-many relation between the Phase class and the Tournament class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void PhaseTournamentBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phase>()
                .HasRequired(a => a.Tournament)
                .WithMany(b => b.Phases);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Match class and the Phase class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void MatchPhaseBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasRequired(a => a.Phase)
                .WithMany(b => b.Matches);
        }

        /// <summary>
        /// Maps a one-to-many relation between the Match class and the Participant class, renamed to Winner outside convention.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void MatchWinnerBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOptional(a => a.Winner)
                .WithMany(b => b.Wins)
                .HasForeignKey(c => c.WinnerId);
        }

        /// <summary>
        /// Maps a one-to-many relation between the Match class and the Participant class, renamed to Loser outside convention.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void MatchLoserBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOptional(a => a.Loser)
                .WithMany(b => b.Losses)
                .HasForeignKey(c => c.LoserId);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Player class and the Person class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void PlayerPersonBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOptional(a => a.Person)
                .WithMany(b => b.Players);
        }

        /// <summary>
        /// Maps a one-to-many relation between the Person class and the Location class, renamed to Residence outside convention.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void PersonResidenceBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOptional(a => a.Residence)
                .WithMany(b => b.Residences)
                .HasForeignKey(c => c.ResidenceId);
        }

        /// <summary>
        /// Maps a one-to-many relation between the Person class and the Location class, renamed to Nationality outside convention.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void PersonNationalityBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasOptional(a => a.Nationality)
               .WithMany(b => b.Nationalities)
               .HasForeignKey(c => c.NationalityId);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Team class and the Location class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void TeamLocationBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Teams);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Ranking class and the Location class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void RankingLocationBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ranking>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Rankings);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Tournament class and the Location class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void TournamentLocationBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Tournaments);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Location class and the Continent class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void LocationContinentBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Continent)
                .WithMany(b => b.Locations);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Location class and the Country class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void LocationCountryBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Country)
                .WithMany(b => b.Locations);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Location class and the Region class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void LocationRegionBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Region)
                .WithMany(b => b.Locations);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Location class and the City class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void LocationCityBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasOptional(a => a.City)
                .WithMany(b => b.Locations);
        }

        /// <summary>
        /// Maps the one-to-many relation between the City class and the Region class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CityRegionBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasRequired(a => a.Region)
                .WithMany(b => b.Cities);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Region class and the Country class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void RegionCountryBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .HasRequired(a => a.Country)
                .WithMany(b => b.Regions);
        }

        /// <summary>
        /// Maps the one-to-many relation between the Country class and the Continent class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        private static void CountryContinentBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasRequired(a => a.Continent)
                .WithMany(b => b.Countries);
        }
    }
}
