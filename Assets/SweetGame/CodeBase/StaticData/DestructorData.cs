using System;
using UnityEngine;

namespace SweetGame.CodeBase.StaticData
{
    [Serializable]
    public class DestructorData
    {
        public string DestructorId;
        public Vector3 Position;

        public DestructorData(string destructorId, Vector3 position)
        {
            DestructorId = destructorId;
            Position = position;
        }
    }
}