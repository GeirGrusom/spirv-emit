using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SpirV.Emit
{
    public enum LiteralConversionType
    {
        Default,
        BigEndian,
        LittleEndian
    }

    public class StringLiteral
    {
        private static readonly uint[] Empty = { 0 };
        public unsafe static uint[] Create(string input, LiteralConversionType endianness = LiteralConversionType.Default)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            if (input == "")
                return Empty;

            var result = new uint[(bytes.Length + 4) / 4];
            var text = Encoding.UTF8.GetBytes(input);


            fixed (uint* ptr = result)
            {
                Marshal.Copy(text, 0, new IntPtr(ptr), text.Length);
            }

            if (BitConverter.IsLittleEndian &&
                (endianness == LiteralConversionType.BigEndian || endianness == LiteralConversionType.Default))
            {
                Endianness.Flip(result);
            }


            return result;
        }

        public static unsafe string Read(IEnumerable<uint> input, LiteralConversionType endianness = LiteralConversionType.Default)
        {
            var bytes = input.ToArray();

            if (BitConverter.IsLittleEndian && (endianness ==  LiteralConversionType.BigEndian || endianness == LiteralConversionType.Default))
            {
                Endianness.Flip(bytes);
            }

            fixed (uint* inputPtr = bytes)
            {
                return new string((sbyte*)inputPtr, 0, bytes.Length, Encoding.UTF8).TrimEnd('\0');
            }
        }
    }
}
