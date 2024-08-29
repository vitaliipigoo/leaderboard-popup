using Cysharp.Threading.Tasks;
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
            SetAvatar().Forget();
            SetUsername(dataModel.Name);
            SetScore(dataModel.Score);
            SetType(dataModel.Type);
        }

        private async UniTask SetAvatar()
        {
            // await SetImage
            //loadingText.SetActive(false);
        }

        private void SetUsername(string uName) => username.text = uName;

        private void SetScore(int uScore) => score.text = uScore.ToString();

        private void SetType(string uType) => type.text = uType;
    }
}