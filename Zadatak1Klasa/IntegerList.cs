using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integerlist 
{
    public class IntegerList:IIntegerList
    {
        private int[] _internalStorage;
        private int storageSize;
        private int maxSize;

        public IntegerList()
        {
            _internalStorage = new int[4];
            storageSize = 0;
            maxSize = 4;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize >= 0)
            {
                _internalStorage = new int[initialSize];
                storageSize = 0;
                maxSize = initialSize;
            }
            else
            {
                _internalStorage = new int[-1 * initialSize];
                storageSize = 0;
                maxSize = -1 * initialSize;
            }

        }
        public void Add(int x)
        {
            if (storageSize == maxSize)
            {
                int[] newArray = new int[2 * maxSize];
                for (int i = 0; i < maxSize; i++)
                {
                    newArray[i] = _internalStorage[i];
                }
                maxSize = 2 * maxSize;
                _internalStorage = newArray;
            }
            storageSize++;
            _internalStorage[storageSize-1] = x;
            return;
        }
        public bool RemoveAt(int index)
        {
            if (index >= storageSize || index < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            storageSize--;
            for (int i = index; i < storageSize; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
        public bool Remove(int x)
        {
            int index = IndexOf(x);
            return RemoveAt(index);
        }
        public int GetElement(int index)
        {
            if (index >= storageSize || index < 0)
            {
                throw new System.IndexOutOfRangeException();
            }
            return _internalStorage[index];
        }
        public int IndexOf(int x)
        {
            int index = -1;
            for (int i = 0; i < storageSize; i++)
            {
                if (_internalStorage[i] == x)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public void Clear()
        {
            storageSize = 0;
            return;
        }
        public int Count
        {
            get { return storageSize; }
        }
        public bool Contains(int item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
