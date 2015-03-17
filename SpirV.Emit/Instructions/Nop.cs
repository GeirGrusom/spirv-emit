using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit.Instructions
{
    public sealed class Nop : Instruction
    {
        internal static readonly Nop Instance = new Nop();
        internal Nop() : base(OpCode.OpNop)
        {
        }
    }
}
