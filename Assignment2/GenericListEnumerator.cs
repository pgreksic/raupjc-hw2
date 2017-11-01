using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> _internalEnumenatorList;
        private int listCurrentIndex;
        private X listValue;

        public GenericListEnumerator(GenericList<X> list)
        {
            _internalEnumenatorList = list;
            listCurrentIndex = -1;
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            //Dispose(true);
            // Suppress finalization.
            //GC.SuppressFinalize(this);
            //Preuzeto sa:
            //https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
            //Test zadatka tri nije prolazio sve dok nisam maknu defaultnu implementaciju:
            //throw new NotImplementedException(); 
            
        }

        public bool MoveNext()
        {
            listCurrentIndex++;
            if (listCurrentIndex >= _internalEnumenatorList.Count)
            {
                return false;
            }
            else
            {
                listValue = _internalEnumenatorList.GetElement(listCurrentIndex);
                return true;
            }

        }

        public void Reset()
        {
            listCurrentIndex = -1;
        }

        public X Current
        {
            get { return listValue;  }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
