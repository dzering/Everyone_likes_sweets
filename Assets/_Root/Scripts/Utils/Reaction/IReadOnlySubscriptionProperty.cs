using System;

namespace SweetGame.Utils.Reaction
{
    internal interface IReadOnlySubscriptionProperty<out TValue>
    {
        TValue Value { get;}

        void SubscribeOnChange(Action<TValue> subscriptionAction);
        void UnsubscribeOnChange(Action<TValue> unsubscriptionAction);

    }
}
