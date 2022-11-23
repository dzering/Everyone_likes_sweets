using UnityEngine;

namespace SweetGame.Game.Utility
{
    public static class Measurer
    {
        public static bool CheckDistance(Vector3 _target, Vector3 _subject, float distance)
        {
            var spacing = Vector2.Distance(_target, _subject);
            if (spacing <= distance)
                return true;

            return false;
        }
    }
}
