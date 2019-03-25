using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    class BinarySearchRec<T>
    {
        public int BinarySearch (T[] array,T key , int left, int right)
        {
            
            int mid = left + (right - left) / 2;
            if (array[mid] == key)
                return mid;
            else if (array[mid] > key)
                return BinarySearch(array, key, left, mid);
            else
                return BinarySearch(array, key, mid+1 , right);
        }
    }
}
