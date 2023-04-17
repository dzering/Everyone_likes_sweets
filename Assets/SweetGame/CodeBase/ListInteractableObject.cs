using System.Collections;
using SweetGame.CodeBase.Abstractions;

namespace SweetGame.CodeBase
{
    internal sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveObject[] interactableObjects;
        private int index = -1;

        public object Current => interactableObjects[index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public bool MoveNext()
        {
            if(index == interactableObjects.Length - 1)
            {
                Reset();
                return false;
            }

            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
