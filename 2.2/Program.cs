using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigInteger
{
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
        
        private static int Comparison(LongNumber a, LongNumber b, bool ignoreSign = false)
        {
            return CompareSign(a, b, ignoreSign);
        }

        private static int CompareSign(LongNumber a, LongNumber b, bool ignoreSign = false)
        {
            if (!ignoreSign)
            {
                if (a.Sign < b.Sign)
                {
                    return -1;
                }
                else if (a.Sign > b.Sign)
                {
                    return 1;
                }
            }

            return CompareSize(a, b);
        }

        private static int CompareSize(LongNumber a, LongNumber b)
        {
            if (a.Size < b.Size)
            {
                return -1;
            }
            else if (a.Size > b.Size)
            {
                return 1;
            }

            return CompareDigits(a, b);
        }

        private static int CompareDigits(LongNumber a, LongNumber b)
        {
            var maxLength = Math.Max(a.Size, b.Size);
            for (var i = maxLength; i >= 0; i--)
            {
                if (a.GetByte(i) < b.GetByte(i))
                {
                    return -1;
                }
                else if (a.GetByte(i) > b.GetByte(i))
                {
                    return 1;
                }
            }

            return 0;
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
    }

    class Program
    {
        static void Main()
        {

        }
    }
}
