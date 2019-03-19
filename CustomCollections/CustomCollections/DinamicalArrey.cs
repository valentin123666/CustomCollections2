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

        public void IndexOf(T x)
        {
            var e = -1;            
            for (int i = 0; i < Count; i++)
            {  
                if (x.Equals(_internalArray[i]))
                {
                    e = i;
                    break;
                    Console.WriteLine(e);
                    
                } 
            }
            Console.WriteLine(e);
            Console.ReadKey();
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

        public void Contains(T x)
        {
            var flag = false;
            
          
              for(var i = 0; i < Count; i++)
            {
              if (x.Equals(_internalArray[i]))
            {
                flag = true;
               break;
                    Console.WriteLine(flag);             
             }
             }
            Console.WriteLine(flag);
            Console.ReadKey();
         }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > -Count)
                    throw new IndexOutOfRangeException(nameof(index));
                return _internalArray[index];
            }
            set
            {
                if (index < 0 || index > -Count)
                    throw new IndexOutOfRangeException(nameof(index));
                _internalArray[index] = value;
            }
        }
                  
            public void Reverse2()
        {
            T x;       
           for(var i=0; i<Count/2; i++)
            {
                x = _internalArray[i];
                _internalArray[i] = _internalArray[(Count) - i -1];
                _internalArray[(Count-2) - i + 1] = x;
                //    if (i>=Count/2)
                //  _internalArray[i] = _internalArray[(Count-2) - i + 1];               
            }                                 
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
