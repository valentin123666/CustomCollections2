using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    class CustomComparer<T>:IComparer<T>
    { 
        public int Compare(T x1,T x2)
        {
            var item1 = x1 as IComparable;
            var item2 = x2 as IComparable;
            if (item1 == null || item2 == null)
                throw new AggregateException(String.Format("{0} does't implement IComparable<> interfac,comparing culd not  be performed", typeof(T)));

            return item1.CompareTo(item2);
        }
    }
}
