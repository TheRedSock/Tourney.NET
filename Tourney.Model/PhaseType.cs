namespace Tourney.Model
{
    /// <summary>
    /// An enumeration for each type of tournament phase.
    /// </summary>
    public enum PhaseType
    {
        /// <summary>
        /// No phase.
        /// </summary>
        None = 0,

        /// <summary>
        /// Single elimination bracket.
        /// <seealso cref="https://en.wikipedia.org/wiki/Single-elimination_tournament"/>
        /// </summary>
        SingleElimination = 1,

        /// <summary>
        /// Double Elimination bracket.
        /// <seealso cref="https://en.wikipedia.org/wiki/Double-elimination_tournament"/>
        /// </summary>
        DoubleElimination = 2,

        /// <summary>
        /// Round robin tournament.
        /// <seealso cref="https://en.wikipedia.org/wiki/Round-robin_tournament"/>
        /// </summary>
        RoundRobin = 3,

        /// <summary>
        /// Swiss tournament system.
        /// <seealso cref="https://en.wikipedia.org/wiki/Swiss-system_tournament"/>
        /// </summary>
        Swiss = 4
    }
}
