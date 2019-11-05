using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    public class HillCipher
    {
        private int[,] key;

        public void SetKey(int k1, int k2, int k3, int k4)
        {
            key = new int[2, 2] { {k1,k2},{k3,k4} };
        }
        private int LetterToInt(char input)
        {
            var op = input.ToString().ToUpper();
            var letter = op[0];
            return (int)letter-65;
        }
        private char IntToLetter(int input)
        {
            return (char)(input + 65);
        }
        private char[,] Encrypt(int p1, int p2)
        {
            var raw = new int[2,1] {{key[0,0]*p1+key[0,1]*p2},{key[1,0]*p1+key[1,1]*p2}};
            raw[0, 0] %= 26;
            raw[1, 0] %= 26;
            var op = new char[2, 1] {{IntToLetter(raw[0,0])},{IntToLetter(raw[1,0])}};
            return op;
        }
        private int[,] AdjK()
        {
            return new int[,] { {key[1,1],-key[0,1]},{-key[1,0],key[0,0]} };
        }
        private int ModK()
        {
            var adj = key[0, 0] * key[1, 1] - key[1, 0] * key[0, 1];
            int mod = 1;
            for (int i = 1; i < 28; i++)
            {
                if (adj*i%26==1)
                {
                    mod = i;
                    break;
                }
            }
            return mod;
        }
        private int NegMod26(int inp)
        {
            int div = inp / 26;
            return inp - (div - 1) * 26;
        }
        private char[,] Decrypt(int c1, int c2)
        {
            var adjk = AdjK();
            var mk = ModK();
            var raw = new int[2, 1] { { adjk[0, 0] * c1 + adjk[0, 1] * c2 }, { adjk[1, 0] * c1 + adjk[1, 1] * c2 } };
            if (raw[0, 0] < 0)
                raw[0, 0] = NegMod26(raw[0, 0] * mk);
            else
                raw[0, 0] = raw[0, 0] * mk % 26;
            if (raw[1, 0] < 0)
                raw[1, 0] = NegMod26(raw[1, 0] * mk);
            else
                raw[1, 0] = raw[1, 0] * mk % 26;
            return new char[2, 1] { { IntToLetter(raw[0, 0]) }, { IntToLetter(raw[1, 0]) } };
        }
        public string Encrypt(string plainText)
        {
            var op = "";
            plainText = plainText.Replace(" ", String.Empty);
            plainText = plainText.ToUpper();
            if (plainText.Length % 2 != 0)
                plainText += "X";
            for (int i = 0; i < plainText.Length; i += 2)
            {
                var iter = Encrypt(LetterToInt(plainText[i]), LetterToInt(plainText[i + 1]));
                op += iter[0, 0];
                op += iter[1, 0];
            }
                return op;
        }
        public string Decrypt(string cipherText)
        {
            var op = "";
            cipherText = cipherText.Replace(" ", String.Empty);
            cipherText = cipherText.ToUpper();
            if (cipherText.Length % 2 != 0)
                return "Invalid Cipher Text";
            for (int i = 0; i < cipherText.Length; i += 2)
            {
                var iter = Decrypt(LetterToInt(cipherText[i]), LetterToInt(cipherText[i + 1]));
                op += iter[0, 0];
                op += iter[1, 0];
            }
            return op;
        }
    }
}
