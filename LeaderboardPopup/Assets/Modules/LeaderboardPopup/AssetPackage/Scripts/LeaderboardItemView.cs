using Models.Leaderboard;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.LeaderboardPopup.AssetPackage.Scripts
{
    public class LeaderboardItemView : MonoBehaviour
    {
        [SerializeField] private Image avatar;
        [SerializeField] private GameObject loadingText;
        [SerializeField] private Text username;
        [SerializeField] private Text score;
        [SerializeField] private Text type;

        public void Init(LeaderboardItemDataModel dataModel)
        {
            
        }
    }
}