using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigInteger
{
    
    //Задаем знак число + или -
    public enum Sign
    {
        Minus = -1,
        Plus = 1
    }

    public class LongNumber
    {
        private readonly List<byte> digits = new List<byte>();

        public LongNumber(List<byte> bytes)
        {
            digits = bytes.ToList();
            RemoveNulls();
        }

        public LongNumber(Sign sign, List<byte> bytes)
        {
            Sign = sign;
            digits = bytes;
            RemoveNulls();
        }

        public LongNumber(string s)
        {
            if (s.StartsWith("-"))
            {
                Sign = Sign.Minus;
                s = s.Substring(1);
            }

            foreach (var c in s.Reverse())
            {
                digits.Add(Convert.ToByte(c.ToString()));
            }

            RemoveNulls();
        }

        public LongNumber(uint x) => digits.AddRange(GetBytes(x));

        public LongNumber(int x)
        {
            if (x < 0)
            {
                Sign = Sign.Minus;
            }

            digits.AddRange(GetBytes((uint)Math.Abs(x)));
        }

        private List<byte> GetBytes(uint num)
        {
            var bytes = new List<byte>();
            do
            {
                bytes.Add((byte)(num % 10));
                num /= 10;
            } while (num > 0);

            return bytes;
        }

        private void RemoveNulls()
        {
            for (var i = digits.Count - 1; i > 0; i--)
            {
                if (digits[i] == 0)
                {
                    digits.RemoveAt(i);
                }
                else
                {
                    break;
                }
            }
        }

        public static LongNumber Exp(byte val, int exp)
        {
            var bigInt = Zero;
            bigInt.SetByte(exp, val);
            bigInt.RemoveNulls();
            return bigInt;
        }

        public static LongNumber Zero => new LongNumber(0);
        public static LongNumber One => new LongNumber(1);

        // Длина числа
        public int Size => digits.Count;

        // Знак числа
        public Sign Sign { get; private set; } = Sign.Plus;

        // Получение цифры по индексу
        public byte GetByte(int i) => i < Size ? digits[i] : (byte)0;

        // Установка цифры по индексу
        public void SetByte(int i, byte b)
        {
            while (digits.Count <= i)
            {
                digits.Add(0);
            }

            digits[i] = b;
        }

        // Преобразование длинного числа в строку
        public override string ToString()
        {
            if (this == Zero) return "0";
            var s = new StringBuilder(Sign == Sign.Plus ? "" : "-");

            for (int i = digits.Count - 1; i >= 0; i--)
            {
                s.Append(Convert.ToString(digits[i]));
            }

            return s.ToString();
        }
        
        //Сравнение чисел если они одинаковы
        public int ifEqual(LongNumber a, LongNumber b)
        {
            if (a.Count == b. Count)
            {
                for (int i = 0; i < a.Count; i++)
                    if (a[i] != b[i])
                        return 0;
                return 1;
            }
            return 0;
        }
        
    }

    class Program
    {
        static void Main()
        {

         pochemu ne poluchaetsya   
        }
    }
}
