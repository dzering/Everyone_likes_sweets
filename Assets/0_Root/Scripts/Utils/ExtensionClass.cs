using System;
using SweetGame.Game.Sweets;

namespace SweetGame.Utils.Extension
{
    public static class ExtensionClass
    {
        public static SweetType Next(this SweetType value)
        {
            int length = Enum.GetNames(typeof(SweetType)).Length;
            int playerTypeValue = (int)value + 1;
            if(playerTypeValue == length)
                playerTypeValue = 0;
            
            return (SweetType)playerTypeValue;
        }

        public static SweetType Previous(this SweetType value)
        {
            int length = Enum.GetNames(typeof(SweetType)).Length;
            int playerTypeValue = (int)(value - 1);
            if(playerTypeValue < 0)
                playerTypeValue = length - 1;
            return (SweetType)playerTypeValue;
        }
    }
}
