using SweetGame.CodeBase.Infrastructure.Services.Ads;
using SweetGame.CodeBase.Infrastructure.Services.PersistentProgress;
using TMPro;

namespace SweetGame.CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI HeartText;
        public RewardedAdItem RewardedAdItem;

        public void Construct(IAdService adService, IProgressService progressService)
        {
            base.Construct(progressService);
            RewardedAdItem.Construct(adService, progressService);
        }

        protected override void Initialize()
        {
            RewardedAdItem.Initialize();
            RefreshHeartText();
        }

        protected override void SubscribeUpdate()
        {
            RewardedAdItem.Subscribe();
            PlayerProgress.WordData.LootData.ChangeLoot += RefreshHeartText;
        }

        protected override void CleanUp()
        {
            base.CleanUp();
            RewardedAdItem.Cleanup();
            PlayerProgress.WordData.LootData.ChangeLoot -= RefreshHeartText;
        }

        private void RefreshHeartText() => 
            HeartText.text = PlayerProgress.WordData.LootData.Collected.ToString();
    }
}