using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit
{
    public static class Endianness
    {
        public static unsafe T Flip<T>(T value)
            where T : struct
        {

            int sizeOf = Marshal.SizeOf<T>();
            var v = stackalloc byte[sizeOf];
            var result = stackalloc byte[sizeOf];

            Marshal.StructureToPtr(value, new IntPtr(v), false);

            for (int i = 0; i < sizeOf; i++)
            {
                result[i] = v[sizeOf - i - 1];
            }

            return Marshal.PtrToStructure<T>(new IntPtr(result));
        }

        public static unsafe void Flip<T>(T[] array)
            where T : struct 
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Flip(array[i]);
            }
        }
    }
}
