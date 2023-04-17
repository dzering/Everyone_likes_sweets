using System;

namespace SweetGame.CodeBase.Abstractions
{
    public interface ITimer
    {
        public event Action OnAlarm;
        void ChangeInterval(float newTimeCheckingPeriod);
        void Execute();
    }
}

