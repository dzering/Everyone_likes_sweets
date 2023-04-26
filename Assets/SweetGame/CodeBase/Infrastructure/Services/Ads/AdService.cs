using System;
using UnityEngine;
using UnityEngine.Advertisements;
using Application = UnityEngine.Application;

namespace SweetGame.CodeBase.Infrastructure.Services.Ads
{
    public class AdService : IUnityAdsListener, IAdService
    {
        private string _gameId;
        private const string IOS_GAME_ID = "5259008";
        private const string ANDROID_GAME_ID = "5259009";
        private const string REWARDED_VIDEO_PLACEMENT_ID = "Rewarded_iOS";

        public bool IsRewardedVideoReady => Advertisement.IsReady(REWARDED_VIDEO_PLACEMENT_ID);
        public int Reward => 23;

        public event Action OnRewardedVideoReady;
        private Action _onVideoFinished;

        public void ShowRewardedAds(Action onVideoFinished)
        {
            Advertisement.Show(REWARDED_VIDEO_PLACEMENT_ID);
            _onVideoFinished = onVideoFinished;
        }
        
        public void Initialize()
        {
            switch (Application.platform)
            {
                case RuntimePlatform.Android:
                    _gameId = ANDROID_GAME_ID;
                    break;
                case RuntimePlatform.IPhonePlayer:
                    _gameId = IOS_GAME_ID;
                    break;
                case RuntimePlatform.OSXEditor:
                    _gameId = IOS_GAME_ID;
                    break;
                default:
                    Debug.Log("Unsupported platform for ads");
                    break;
            }
            Advertisement.AddListener(this);
            Advertisement.Initialize(_gameId);
        }
        
        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log($"OnUnityAdsReady {placementId}");
            if (placementId == REWARDED_VIDEO_PLACEMENT_ID)
                OnRewardedVideoReady?.Invoke();
        }

        public void OnUnityAdsDidError(string message) => 
            Debug.LogError($"OnUnityAdsDidError {message}");

        public void OnUnityAdsDidStart(string placementId) => 
            Debug.Log("OnUnityAdsDidStart");

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.LogError($"OnUnityAdsDidFinish {showResult}");
                    break;
                case ShowResult.Skipped:
                    Debug.Log($"OnUnityAdsDidFinish {showResult}");
                    break;
                case ShowResult.Finished:
                    _onVideoFinished?.Invoke();
                    break;
                default:
                    Debug.Log($"OnUnityAdsDidFinish {showResult}");
                    break;
            }
            
            _onVideoFinished = null;
        }
    }
}