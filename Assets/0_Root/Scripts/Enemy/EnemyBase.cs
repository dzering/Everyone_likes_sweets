﻿using SweetGame.Enemy;
using UnityEngine;

namespace SweetGame.Abstractions
{
    public abstract class EnemyBase : InteractiveObject, IMove
    {
        public abstract void SetPosition(Vector3 position);
        public abstract void Move();
        public override void Execute()
        {
            Move();
        }
    }
}