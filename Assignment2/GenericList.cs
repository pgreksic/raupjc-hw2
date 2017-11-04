using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
   public class GenericList<X> : IGenericList<X>,IEnumerable<X>
   {
        private X[] _internalStorage;
        private int lastElementIndex;
        readonly private int DEFAULT_ARRAY_SIZE = 4;

        //konstruktor bez parametara
       public GenericList()
       {
           _internalStorage = new X[DEFAULT_ARRAY_SIZE];
           lastElementIndex = -1;

       }

        //konstruktor koji prima pocetnu velicinu genericke liste
       public GenericList(int initialSize)
       {
           _internalStorage = new X[initialSize];
           lastElementIndex = -1;
       }

        public void Add(X item)
        {
            if (_internalStorage.Length <= lastElementIndex + 1)
            {
                X[] temp = new X[_internalStorage.Length * 2];
                for (int i = 0; i < _internalStorage.Length; ++i)
                {
                    temp[i] = _internalStorage[i];
                }

                _internalStorage = temp;

            }
            _internalStorage[++lastElementIndex] = item;
        }

        public bool Remove(X item)
        {
            int index = IndexOf(item);
            if (index.Equals(-1))
            {
                return false;
            }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index > lastElementIndex)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < lastElementIndex; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            lastElementIndex--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index <= lastElementIndex)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i <= lastElementIndex; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;  //default return value if element isn't found
        }

       public int Count
       {
           get { return lastElementIndex + 1; }
       }

        public void Clear()
        {
            _internalStorage = new X[_internalStorage.Length];
            lastElementIndex = -1;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       public IEnumerator<X> GetEnumerator()
       {
           return new GenericListEnumerator<X>(this);
       }

        IEnumerator IEnumerable.GetEnumerator()
       {
           return GetEnumerator();
       }
    }
}
