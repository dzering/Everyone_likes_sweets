using System;
using System.Collections;
using System.Collections.Generic;
using SweetGame.Abstractions;
using Object = UnityEngine.Object;

namespace SweetGame
{
    public sealed class ListExecutiveObject : IEnumerator, IEnumerable, IDisposable
    {
        private IExecute[] executiveObjects;
        private int position = -1;
        public int Length => executiveObjects.Length;

        public ListExecutiveObject()
        {
            //IExecute[] list = Object.FindObjectsOfType<InteractiveObject>();
            //for (int i = 0; i < list.Length; i++)
            //{
            //    AddExecuteObject(list[i]);
            //}
        }

        public IExecute this[int index]
        {
            get { return executiveObjects[index]; }
            set { executiveObjects[index] = value; }
        }

        public void ClearList()
        {
            executiveObjects = null;
        }

        public void AddExecuteObject(IExecute execute)
        {
            if(executiveObjects == null)
            {
                executiveObjects = new IExecute[] { execute };
                return;
            }

            Array.Resize(ref executiveObjects, executiveObjects.Length + 1);
            executiveObjects[executiveObjects.Length - 1] = execute;
        }

        public void RemoveExecuteObject(IExecute execute)
        {
            IExecute[] executes = new IExecute[executiveObjects.Length-1];
            int j = 0;
            for (int i = 0; i < executiveObjects.Length; i++)
            {
                if(  Object.ReferenceEquals(executiveObjects[i], execute))
                {
                    executes[j] = execute;
                    j++;
                }
            }
            executiveObjects = executes;
        }

        bool IEnumerator.MoveNext()
        {
            if(position < executiveObjects.Length - 1)
            {
                position++;
                return true;
            }
            return false;
        }
        void IEnumerator.Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get { return executiveObjects[position]; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }
    }
}
