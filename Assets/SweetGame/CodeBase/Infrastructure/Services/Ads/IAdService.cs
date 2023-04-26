using System;

namespace SweetGame.CodeBase.Infrastructure.Services.Ads
{
    public interface IAdService : IService
    {
        bool IsRewardedVideoReady { get; }
        int Reward { get;}
        void ShowRewardedAds(Action onVideoFinished);
        void Initialize();
        event Action OnRewardedVideoReady;
    }
}