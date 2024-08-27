using System.Collections.Generic;

namespace Models.Leaderboard
{
    public class LeaderboardDataModel
    {
        public List<LeaderboardItemDataModel> Leaderboard { get; } = new ();
    }
}