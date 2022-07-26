using System;
using System.Collections;
using System.Collections.Generic;
using SweetGame.Abstractions;

namespace SweetGame
{
    internal sealed class ListExecutiveObject : IEnumerator, IEnumerable, IDisposable
    {
        private IExecute[] executiveObjects;
        private int position = -1;

        public IExecute this[int index]
        {
            get { return executiveObjects[index]; }
            set { executiveObjects[index] = value; }
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
