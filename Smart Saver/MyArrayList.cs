using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Smart_Saver
{
    class MyArrayList : IEnumerable
    {
        object[] m_items = null;
        int freeIndex = 0;

        public MyArrayList()
        {
            m_items = new object[100];

        }
        public void Add(object item)
        {
            m_items[freeIndex] = item;
            freeIndex++;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (object o in m_items)
            {
                if(o == null)
                {
                    break;
                }
                yield return o;
            }
        }
    }
}
