using System;

namespace SweetGame.CodeBase.Tools.Reaction
{
    internal interface IReadOnlySubscriptionProperty<out TValue>
    {
        TValue Value { get;}

        void SubscribeOnChange(Action<TValue> subscriptionAction);
        void UnsubscribeOnChange(Action<TValue> unsubscriptionAction);

    }
}
