using System.Collections;
using System;
using UnityEngine;

namespace Test
{

    public class StateMachine : MonoBehaviour
    {
        Enemy enemy;
        /*Описать пространство состояний
            1) Нейтральное
            2) Патрулирование
            3) Нападение
            4) Преследование

        - Описать набор входных сигналов (Тригеры)
            1) Видит врага
            2) Не видит врага 

        - Описать набор выходных функций
            1) Ничего не делает
            2) Двигается прямо
            3) Двигается быстро в сторону противника
            4) Окружает противника
        */

        private void Start()
        {
            enemy = new Enemy();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
                enemy.Search(Triger.SeeingEnemy);
            if (Input.GetKeyDown(KeyCode.N))
                enemy.Search(Triger.None);
        }
    }



    public enum Triger
    {
        None = 0,
        SeeingEnemy = 1
    }

    public class Enemy : AbstractEnemy
    {
        public Enemy()
        {
            State = new Neutral();
        }

        public override void DoSomthing()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class State
    {
        public virtual void HandleTriger(AbstractEnemy enemy, Triger triger)
        {
            ChangeState(enemy, triger);
        }
        protected abstract void ChangeState(AbstractEnemy enemy, Triger triger);
    }


    public class Neutral : State
    {
        public Neutral()
        {
            DoNothing();
        }
        public void DoNothing() => Debug.Log("I am do nothing");

        protected override void ChangeState(AbstractEnemy enemy, Triger triger)
        {
            switch (triger)
            {
                case Triger.None:
                    {
                        break;
                    }
                case Triger.SeeingEnemy:
                    {
                        enemy.State = new Attack();
                        break;
                    }
                default:
                    break;
            }

        }
    }
    public class Attack : State
    {
        public Attack() => Attacking();

        public void Attacking() => Debug.Log("I am attacking.");

        protected override void ChangeState(AbstractEnemy enemy, Triger triger)
        {
            switch (triger)
            {
                case Triger.None:
                    {
                        enemy.State = new Pattrol();
                        break;
                    }
                case Triger.SeeingEnemy:
                    break;

                default:
                    break;
            }
        }
    }
    public class Pattrol : State
    {
        public Pattrol() => Pattroling();
        public void Pattroling() => Debug.Log("I am patrolling");

        protected override void ChangeState(AbstractEnemy enemy, Triger triger)
        {
            switch (triger)
            {
                case Triger.None:
                    break;
                case Triger.SeeingEnemy:
                    enemy.State = new Chasing();
                    break;

                default:
                    break;
            }
        }
    }
    public class Chasing : State
    {
        public Chasing() => FastMoving();
        public void FastMoving() => Debug.Log("I am moving fast.");

        protected override void ChangeState(AbstractEnemy enemy, Triger triger)
        {
            switch (triger)
            {
                case Triger.None:
                    enemy.State = new Pattrol();
                    break;
                case Triger.SeeingEnemy:
                    enemy.State = new Attack();
                    break;

                default:
                    break;
            }
        }
    }
}
