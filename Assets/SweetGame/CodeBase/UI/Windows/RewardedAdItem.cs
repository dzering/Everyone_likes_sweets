using SweetGame.CodeBase.Infrastructure.Services.Ads;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using UnityEngine.UI;

namespace SweetGame.CodeBase.UI.Windows
{
    public class RewardedAdItem : MonoBehaviour
    {
        public Button ShowAdButton;
        private IAdService _adService;

        public GameObject[] AdActiveObjects;
        public GameObject[] AdInactiveObjects;
        private IProgressService _progressService;

        public void Construct(IAdService adService, IProgressService progressService)
        {
            _adService = adService;
            _progressService = progressService;
        }

        public void Initialize()
        {
            ShowAdButton.onClick.AddListener(OnShowAdClicked);
            RefreshAvailableAd();
        }
        
        public void Subscribe() => 
            _adService.OnRewardedVideoReady += RefreshAvailableAd;

        private void RefreshAvailableAd()
        {
            bool isVideoReady = _adService.IsRewardedVideoReady;
            foreach (var adActiveObject in AdActiveObjects)
            {
                adActiveObject.SetActive(isVideoReady);
            }

            foreach (var adInactiveObject in AdInactiveObjects)
            {
                adInactiveObject.SetActive(!isVideoReady);
            }
        }

        public void Cleanup() => 
            _adService.OnRewardedVideoReady -= RefreshAvailableAd;

        private void OnShowAdClicked()
        {
            _adService.ShowRewardedAds(OnVideoFinished);
        }

        private void OnVideoFinished()
        {
            _progressService.PlayerProgress.WordData.LootData.Add(_adService.Reward);
        }
    }
}