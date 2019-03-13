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
            int[] v = new int[] { 1, 2, 3, 4 };
            var f = new int[] { 5, 6, 7, };

            var _dinamical = new DinamicalArrey<int>();

            _dinamical.Add(22);
            _dinamical.Add(23);
            _dinamical.Add(24);
            _dinamical.Add(25);
            _dinamical.Insert(2,777 );
            _dinamical.AddRange(v);
            _dinamical.InsertRange(3, f);

            
            foreach (var g in _dinamical)
            {
                Console.WriteLine(g);
            }
             
            Console.ReadKey();

        }
    }
}
