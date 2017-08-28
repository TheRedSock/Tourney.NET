using System.Data.Entity;

namespace Tourney.DataAccess
{
    public class TourneyDBInitializer : DropCreateDatabaseIfModelChanges<TourneyContext>
    {
        protected override void Seed(TourneyContext context)
        {
            // Add test data.

            base.Seed(context);
        }
    }
}
