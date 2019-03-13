using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    public class DinamicalArrey<T> : IEnumerable<T>
    {
        private T[] _internalArray;     

        private void ThrowIfInvalid(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        private const int DefauultCapacity = 100;

        private int Capacity;        

        public DinamicalArrey(int _capacity = DefauultCapacity)  
        {
            Capacity = _capacity;
            _internalArray = new T[_capacity];           
        }

        public int Count { get; private set; }
        private void Resize()
        {
            Capacity += DefauultCapacity;
            T[] array = new T[Capacity];
            for (int i = 0; i < Count; i++)
            {
                array[i] = _internalArray[i];
            }
            _internalArray = array;
        }

        public void Insert ( int index, T x )
        {
            InsertInto(index - 1, x);
        }
        private void InsertInto(int index, T x)
        {
            if (_internalArray.Length == Count)
            {
                Resize();
            }
            for (var i = Count; i > index; i--)
            {
                _internalArray[i] = _internalArray[i - 1];
            }
            _internalArray[index] = x;
            Count++;
        }

        public void Add(T item)
        {            
            if (_internalArray.Length == Count)
            {
                Resize();
            }

            _internalArray[Count] = item;
            Count++;
            
        }

        public void RemoveAt(int index)
        {
            ThrowIfInvalid(index);
            for (var i = index; i < Count - 1; i++)
            {
                _internalArray[i] = _internalArray[i + 1];
            }
            _internalArray[Count - 1] = default(T);
            Count--;
        }

        public int IndexOf(T x)
        {
            for (int i = 0; i < Count; i++)
            {
                if (x.Equals(_internalArray[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        public void AddRange(IEnumerable<T> addArrey)   
        {
            var addingCount = addArrey.Count();
            
            if (addingCount >= Capacity)
            {
                Array.Resize(ref _internalArray,(_internalArray.Length+DefauultCapacity*2)+addingCount);
            }
            var newCount = Count + addingCount;
            
            foreach(var addingItem in addArrey)
            { 
                
                _internalArray[Count++] = addingItem;
            }          
        }
        public void InsertRange(int index , IEnumerable<T> addArrey)
        {
            var addingCount = addArrey.Count();
            
            if (addingCount >= Capacity)
            {
                Array.Resize(ref _internalArray, (_internalArray.Length + DefauultCapacity * 2) + addingCount);
            }
            var newCount = Count + addingCount;
            foreach (var addingItem in addArrey.Reverse())
            {
                InsertInto(index-1, addingItem);               
            }            
            newCount++;           
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _internalArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
