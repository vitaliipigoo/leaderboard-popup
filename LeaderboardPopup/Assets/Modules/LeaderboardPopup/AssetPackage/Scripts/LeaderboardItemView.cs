using Cysharp.Threading.Tasks;
using Models.Leaderboard;
using UnityEngine;
using UnityEngine.Networking;
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
            SetAvatar(dataModel.Avatar).Forget();
            SetUsername(dataModel.Name);
            SetScore(dataModel.Score);
            SetType(dataModel.Type);
        }

        private async UniTask SetAvatar(string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            await request.SendWebRequest();

            if (request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error downloading image: {request.error}");
                return;
            }
            
            var texture = DownloadHandlerTexture.GetContent(request);
            var sprite = ConvertTextureToSprite(texture);

            avatar.sprite = sprite;
            loadingText.gameObject.SetActive(false);
        }

        private Sprite ConvertTextureToSprite(Texture2D texture)
        {
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Vector2 pivot = new Vector2(0.5f, 0.5f);

            return Sprite.Create(texture, rect, pivot);
        }

        private void SetUsername(string uName) => username.text = uName;

        private void SetScore(int uScore) => score.text = uScore.ToString();

        private void SetType(string uType) => type.text = uType;
    }
}