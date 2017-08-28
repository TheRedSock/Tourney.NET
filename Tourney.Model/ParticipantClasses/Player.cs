namespace Tourney.Model.ParticipantClasses
{
    public class Player : Participant
    {
        public int PlayerId { get; set; }
        public Person Person { get; set; }
    }
}
