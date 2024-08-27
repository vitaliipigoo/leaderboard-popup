using Models.Leaderboard;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
    public class LeaderboardDataService : ILeaderboardDataService
    {
        public LeaderboardDataModel LeaderboardData { get; }
        
        private const string LeaderboardFileName = "Leaderboard";

        public LeaderboardDataService()
        {
            var json = Resources.Load<TextAsset>(LeaderboardFileName);
            LeaderboardData = JsonConvert.DeserializeObject<LeaderboardDataModel>(json.text);
        }
    }
}