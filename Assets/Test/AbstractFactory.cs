using System;
using UnityEngine;

namespace Test
{
    public abstract class AbstractEnemy
	{
		public State State;

		public abstract void DoSomthing();

		public virtual void Search(Triger triger)
		{
			State.HandleTriger(this, triger);
		}
	}

	public class Tank : AbstractEnemy
	{
		public Tank()
		{
			State = new Neutral();
		}

        public override void DoSomthing()
        {
			Debug.Log("Fire on");
        }
    }

	public class Aircraft : AbstractEnemy
	{
        public override void DoSomthing()
        {
			Debug.Log("Missels attak by " + nameof(Aircraft));
        }
    }

	public abstract class AbstractFactory
	{
        public abstract AbstractEnemy CreateProduct();
	}

    public class TankFactory : AbstractFactory
    {
        public override AbstractEnemy CreateProduct()
        {
			return new Tank();
        }
    }

	public class AircraftFactory : AbstractFactory
	{
        public override AbstractEnemy CreateProduct()
        {
			return new Aircraft();
        }
    }

    public class Client
	{
		private AbstractEnemy enemy;

		public Client(AbstractFactory factory)
		{
			enemy = factory.CreateProduct();
		}

		public void Run()
		{
			enemy.DoSomthing();
		}
	}

}

