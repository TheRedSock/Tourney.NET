using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tourney.Model;
using Tourney.Model.LocationClasses;
using Tourney.Model.ParticipantClasses;

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
        /// Gets or sets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public virtual DbSet<Event> Events { get; set; }

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
            // Makes it so the database tables are not pluralized.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Changes the default datetime type to datetime2 instead of SqlDateTime so it can hold older dates.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            #region Many-To-Many
            // Maps the many-to-many relation between Ranking and Tournament.
            modelBuilder.Entity<Ranking>()
                .HasMany(a => a.Tournaments)
                .WithMany(b => b.Rankings)
                .Map(m =>
                {
                    m.ToTable("RankingTournament");
                    m.MapLeftKey("RankingId");
                    m.MapRightKey("TournamentId");
                });

            // Maps the many-to-many relation between Ranking and Participant.
            modelBuilder.Entity<Ranking>()
                .HasMany(a => a.Participants)
                .WithMany(b => b.Rankings)
                .Map(m =>
                {
                    m.ToTable("RankingParticipant");
                    m.MapLeftKey("RankingId");
                    m.MapRightKey("ParticipantId");
                });

            // Maps the many-to-many relation between Player and Teams.
            modelBuilder.Entity<Player>()
                .HasMany(a => a.Teams)
                .WithMany(b => b.Players)
                .Map(m =>
                {
                    m.ToTable("PlayerTeam");
                    m.MapLeftKey("PlayerId");
                    m.MapRightKey("TeamId");
                });
            #endregion

            #region One-To-Many
            // Maps the one-to-many relation between Event and Tournament.
            modelBuilder.Entity<Event>()
                .HasRequired(a => a.Tournament)
                .WithMany(b => b.Events);

            // Maps the one-to-many relation between Match and Event.
            modelBuilder.Entity<Match>()
                .HasRequired(a => a.Event)
                .WithMany(b => b.Matches);

            // Maps the one-to-many relation between Match and Participant (Winner).
            modelBuilder.Entity<Match>()
                .HasOptional(a => a.Winner)
                .WithMany(b => b.Wins)
                .HasForeignKey(c => c.WinnerId);

            // Maps the one-to-many relation between Match and Participant (Loser).
            modelBuilder.Entity<Match>()
                .HasOptional(a => a.Loser)
                .WithMany(b => b.Losses)
                .HasForeignKey(c => c.LoserId);

            // Maps the one-to-many relation between Player and Person.
            modelBuilder.Entity<Player>()
                .HasOptional(a => a.Person)
                .WithMany(b => b.Players);

            #region Builders for Location class relations
            // Maps the relations between the Location class and other classes.
            modelBuilder.Entity<Person>()
                .HasOptional(a => a.Residence)
                .WithMany(b => b.Residences)
                .HasForeignKey(c => c.ResidenceId);

            modelBuilder.Entity<Person>()
                .HasOptional(a => a.Nationality)
                .WithMany(b => b.Nationalities)
                .HasForeignKey(c => c.NationalityId);

            modelBuilder.Entity<Team>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Teams);

            modelBuilder.Entity<Ranking>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Rankings);

            modelBuilder.Entity<Tournament>()
                .HasOptional(a => a.Location)
                .WithMany(b => b.Tournaments);
            #endregion

            #region Location Builders
            // Maps the various one-to-many relations between location subclasses and the Location class.
            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Continent)
                .WithMany(b => b.Locations);

            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Country)
                .WithMany(b => b.Locations);

            modelBuilder.Entity<Location>()
                .HasOptional(a => a.Region)
                .WithMany(b => b.Locations);

            modelBuilder.Entity<Location>()
                .HasOptional(a => a.City)
                .WithMany(b => b.Locations);

            modelBuilder.Entity<City>()
                .HasRequired(a => a.Region)
                .WithMany(b => b.Cities);

            modelBuilder.Entity<Region>()
                .HasRequired(a => a.Country)
                .WithMany(b => b.Regions);

            modelBuilder.Entity<Country>()
                .HasRequired(a => a.Continent)
                .WithMany(b => b.Countries);
            #endregion
            #endregion
        }

        public TourneyContext()
        {
            Configuration.ProxyCreationEnabled = false;

            // This deletes and recreates an empty database if the model has changed.
            //Database.SetInitializer(new TourneyDBInitializer()); 
        }
    }
}
