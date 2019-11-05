using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class RSA
    {
        int p, q, n, fn, e, d;
        public RSA(int p, int q, int e)
        {
            this.p = p;
            this.q = q;
            this.e = e;
            this.n = p * q;
            this.fn = (p - 1) * (q - 1);
            for (int i = 1; i < fn + 1; i++)
            {
                if (e*i%fn==1)
                {
                    this.d = i;
                    break;
                }
            }
        }
        public RSA(int p, int q)
        {
            this.p = p;
            this.q = q;
            this.n = p * q;
            this.fn = (p - 1) * (q - 1);
            for (int i = 1; i < fn; i++)
            {
                if (GCD(i, fn) == 1)
                {
                    this.e = i;
                    break;
                }
                    
            }
                for (int i = 1; i < fn + 1; i++)
                {
                    if (e * i % fn == 1)
                    {
                        this.d = i;
                        break;
                    }
                }
        }

        private int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }
        public int Encrypt(int m)
        {
            return (int) Math.Pow((double)m,(double)e) % n;
        }
        public int Decrypt(int c)
        {
            return (int)Math.Pow((double)c, (double)d) % n;
        }
    }
}
