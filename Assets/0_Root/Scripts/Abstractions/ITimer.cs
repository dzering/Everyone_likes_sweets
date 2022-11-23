using System;


namespace SweetGame.Abstractions
{
    public interface ITimer
    {
        public event Action OnAlarm;
        void ChangeInterval(float newTimeCheckingPeriod);
        void Execute();
    }
}

