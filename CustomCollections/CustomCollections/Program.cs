using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[] { 2, 3, 1, 4 };
            var f = new int[] { 5, 8, 4, };

            var _dinamical = new DinamicalArrey<int>();

            
            _dinamical.Add(22);
            _dinamical.Add(26);
            _dinamical.Add(25);
            _dinamical.Add(24);
            _dinamical.Insert(2,777 ); 
            _dinamical.AddRange(v);
            _dinamical.InsertRange(3, f);
            _dinamical.InsertRange(6, f);

            //  _dinamical.IndexOf(22);
            //   _dinamical.Contains(22);
            // _dinamical.Reverse2();
            
            Console.WriteLine(_dinamical.BinarySearch(1));


            foreach (var g in _dinamical)
            {
                Console.WriteLine(g);
                
            }
             
            Console.ReadKey();

        }
    }
}
