using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class DiffieHellman
    {
        int p, g, xa, ya, xb, yb, k;
        public void SetAttr(int p, int g, int xa, int xb) {
            this.p = p;
            this.g = g;
            this.xa = xa;
            this.xb = xb;
        }
        public void KeyGen()
        {
            ya = (int) Math.Pow(g,xa) % p;
            yb = (int)Math.Pow(g, xb) % p;
            k = (int)Math.Pow(yb, xa) % p;
            Console.WriteLine("Private Key of A: {0}", xa);
            Console.WriteLine("Public Key of A: {0}", ya);
            Console.WriteLine("Private Key of B: {0}", xb);
            Console.WriteLine("Public Key of B: {0}", yb);

            Console.WriteLine("k = {0}", k);
        }
    }
}
