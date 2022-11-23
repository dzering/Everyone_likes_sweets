using UnityEngine;
using System;
using SweetGame.Abstractions;


namespace SweetGame.Game.Utility
{
    public sealed class Timer : ITimer
    {
        public event Action OnAlarm;

        private float _interval;
        private float _time;

        public Timer(float timeCheckingPeriod)
        {
            _interval = timeCheckingPeriod;
        }

        public void ChangeInterval(float newTimeCheckingPeriod)
        {
            _interval = newTimeCheckingPeriod;
        }

        public void Execute()
        {
            _time += Time.deltaTime;
            if (_time < _interval)
            {
                return;
            }
            OnAlarm?.Invoke();
            _time = 0;
        }  
    }
}

