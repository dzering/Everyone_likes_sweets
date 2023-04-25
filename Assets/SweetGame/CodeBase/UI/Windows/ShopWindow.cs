using TMPro;

namespace SweetGame.CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        public TextMeshProUGUI HeartText;

        protected override void SubscribeUpdate() => 
            PlayerProgress.WordData.LootData.ChangeLoot += RefreshHeartText;

        protected override void CleanUp()
        {
            base.CleanUp();
            PlayerProgress.WordData.LootData.ChangeLoot -= RefreshHeartText;
        }

        protected override void Initialize() =>
            RefreshHeartText();

        private void RefreshHeartText() => 
            HeartText.text = PlayerProgress.WordData.LootData.Collected.ToString();
    }
}