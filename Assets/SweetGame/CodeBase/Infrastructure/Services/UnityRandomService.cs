using System;

namespace SweetGame.CodeBase.Infrastructure.Services
{
    public class UnityRandomService : IRandomService
    {
        private readonly Random _random;
        public UnityRandomService() => 
            _random = new Random();

        public int GetRandom(int min, int max) => 
            _random.Next(min, max);
    }
}