using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Elgamel
    {
        int p, x, y, alpha, k, m, r, s;
        public int M { get { return m; } set { m = value; } }

        public Elgamel()
        {

        }
        public void SetAttr(int p, int a, int? x, int? k)
        {
            this.p = p;
            if (x.HasValue)
            {
                this.x = x??0;
            }
            else
            {
                for (int i = 1; i < p; i++)
                {
                    if (Util.GCD(i, p - 1) == 1)
                    {
                        this.x = i;
                        break;
                    }
                }
            }
            this.alpha = a;
            if (k.HasValue)
            {
                this.k = k ?? 0;
            }
            else
            {
                for (int i = 1; i < p; i++)
                {
                    if (Util.GCD(i, p - 1) == 1)
                    {
                        this.k = i;
                        break;
                    }
                }
            }
        }
        public void KeyGen()
        {
            Console.WriteLine("Private Key: " + x);
            this.y = ((int) Math.Pow(alpha, x)) % p;
            Console.WriteLine("Public Key: {0}",y);
        }
        public void Sign()
        {
            this.r = ((int)Math.Pow(alpha, k)) % p;
            this.s = Util.InverseMod(k,p-1) * ((m - r * x) < 0 ? Util.NegMod(m - r * x,p-1):((m-r*x)%(p-1))) % (p-1);
            Console.WriteLine("Signed Message: [{0},({1},{2})]", m, r, s);
        }

        public bool Verify()
        {
            return Math.Pow(alpha, m) % p == Math.Pow(y, r) * Math.Pow(r, s) % p;
        }
    }
}
