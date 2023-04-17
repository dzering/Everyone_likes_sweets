using System;

namespace SweetGame.CodeBase.Tools.Reaction
{
    public sealed class SubscriptionProperty<T> : IReadOnlySubscriptionProperty<T>
    {
        private T value;
        private event Action<T> OnChange;
        public T Value {
            get => value;
            set
            {
                this.value = value;
                OnChange?.Invoke(value);
            }
        }

        public void SubscribeOnChange(Action<T> subscriptionAction)
        {
            OnChange += subscriptionAction;
        }

        public void UnsubscribeOnChange(Action<T> unsubscriptionAction)
        {
            OnChange -= unsubscriptionAction;
        }
    }
}
