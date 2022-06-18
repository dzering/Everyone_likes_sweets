using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetGame.Tools
{
    internal class SubscriptionProperty<TValue>
    {
        private TValue value;

        private Action<TValue> OnChange;

        public TValue Value
        {
            get => this.value;
            set 
            {
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }

        public void SubscribeOnChange(Action<TValue> subscriptionAction)
        {
            OnChange += subscriptionAction;
        }

        public void UnsubscribeOnChange(Action<TValue> insubscriptionAction)
        {
            OnChange -= insubscriptionAction;
        }
    }
}
