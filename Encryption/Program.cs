using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            int p, a, x, k, m;
            Console.WriteLine("Enter Values of p, a, x and k:");
            p = Int32.Parse(Console.ReadLine());
            a = Int32.Parse(Console.ReadLine());
            x = Int32.Parse(Console.ReadLine());
            k = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Message:");
            m = Int32.Parse(Console.ReadLine());
            var el = new Elgamel();
            el.SetAttr(p, a, x, k);
            el.M = m;
            
            el.KeyGen();
            el.Sign();
            Console.WriteLine("Verification: " + (el.Verify() ? "Success" : "Failed"));
        }
    }
}
