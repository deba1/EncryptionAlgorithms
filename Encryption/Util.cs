using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    static class Util
    {
        public static bool IsPrime(int n)
        {
            int i, m = 0;
            m = n / 2;
            for (i = 2; i <= m; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;  
        }
        public static int RandomPrime(int min,int max)
        {
            Random r = new Random();
            int random = min + r.Next(max-min);
            while (true)
            {
                if (IsPrime(random))
                    return random;
                else
                    random = min + r.Next(max-min);
            }
        }

        public static int GCD(int a, int b)
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

        public static int NegMod(int inp, int mod)
        {
            int div = inp / mod;
            return inp - (div - 1) * mod;
        }

        public static int InverseMod(int inp, int mod)
        {
            int m = 1;
            for (int i = 1; i < mod; i++)
            {
                if (inp * i % mod == 1)
                {
                    m = i;
                    break;
                }
            }
            return m;
        }
    }
}
