using System.ComponentModel.DataAnnotations;

namespace Tourney.Model
{
    /// <summary>
    /// Class for a round.
    /// </summary>
    public class Round
    {
        /// <summary>
        /// Gets or sets the round identifier.
        /// </summary>
        /// <value>
        /// The round identifier.
        /// </value>
        public int RoundId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        public string Name { get; set; }

        // When accessing this table, there needs to be manual sorting logic.
    }
}
