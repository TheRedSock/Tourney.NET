namespace Tourney.Model.ParticipantClasses
{
    /// <summary>
    /// Class for a player which inherits from the <see cref="Participant" /> class.
    /// </summary>
    /// <seealso cref="Tourney.Model.Participant" />
    public class Player : Participant
    {
        /// <summary>
        /// Gets or sets the player identifier.
        /// </summary>
        /// <value>
        /// The player identifier.
        /// </value>
        public int PlayerId { get; set; }

        /// <summary>
        /// Gets or sets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="person">The person.</param>
        public Player(string name, Person person) : base(name)
        {
            Person = person;
        }
    }
}
