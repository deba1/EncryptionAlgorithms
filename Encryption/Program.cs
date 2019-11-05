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
            Console.WriteLine("Enter an Option:\n\t1. Hill Cipher\n\t2. RSA\n\t~. Exit");
            switch (Console.ReadLine())
            {
                case "1":

                    HillCipher hs = new HillCipher();
                    Console.WriteLine("Enter Key (2x2 Matrix):");
                    hs.SetKey(Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()), Int32.Parse(Console.ReadLine()));
                    Console.WriteLine("Enter an Option:\n\t1. Encrypt\n\t2. Decrypt\n\t~. Exit");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter Plain Text:");
                            Console.WriteLine("Cipher Text:\n"+hs.Encrypt(Console.ReadLine()));
                            break;
                        case "2":
                            Console.WriteLine("Enter Cipher Text:");
                            Console.WriteLine("Plain Text:\n"+hs.Decrypt(Console.ReadLine()));
                            break;
                        default:
                            System.Environment.Exit(1);
                            break;
                    }
                    break;
                case "2":
                    int p, q, e;
                    Console.WriteLine("Enter Values of p, q and e:");
                    p = Int32.Parse(Console.ReadLine());
                    q = Int32.Parse(Console.ReadLine());
                    e = Int32.Parse(Console.ReadLine());
                    RSA rsa = new RSA(p,q,e);
                    Console.WriteLine("Enter an Option:\n\t1. Encrypt\n\t2. Decrypt\n\t~. Exit");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.WriteLine("Enter Plain Text(int):");
                            Console.WriteLine("Cipher Text:\n" + rsa.Encrypt(Int32.Parse(Console.ReadLine())));
                            break;
                        case "2":
                            Console.WriteLine("Enter Cipher Text(int):");
                            Console.WriteLine("Plain Text:\n" + rsa.Decrypt(Int32.Parse(Console.ReadLine())));
                            break;
                        default:
                            System.Environment.Exit(1);
                            break;
                    }
                    break;
                default:
                    System.Environment.Exit(1);
                    break;
            }
        }
    }
}
