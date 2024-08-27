using Models.Leaderboard;

namespace Services
{
    public interface ILeaderboardDataService
    {
        LeaderboardDataModel LeaderboardData { get; }
    }
}