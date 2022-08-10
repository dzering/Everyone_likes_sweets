using System;
using SweetGame.Player;

namespace SweetGame.Utils.Extension
{
    public static class ExtensionClass
    {
        public static PlayerType Next(this PlayerType value)
        {
            int length = Enum.GetNames(typeof(PlayerType)).Length;
            int playerTypeValue = (int)value + 1;
            if(playerTypeValue == length)
                playerTypeValue = 0;

            return (PlayerType)playerTypeValue;
        }

        public static PlayerType Previous(this PlayerType value)
        {
            int length = Enum.GetNames(typeof(PlayerType)).Length;
            int playerTypeValue = (int)(value - 1);
            if(playerTypeValue == 0)
                playerTypeValue = length - 1;
            return (PlayerType)playerTypeValue;
        }
    }
}
