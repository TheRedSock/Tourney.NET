namespace Tourney.Model.ParticipantClasses
{
    /// <summary>
    /// Class for a player which inherits from the Participant class.
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
        public Person Person { get; set; }
    }
}
