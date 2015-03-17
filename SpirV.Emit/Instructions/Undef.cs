using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit.Instructions
{
    public sealed class Undef : Instruction, IResultId
    {

        public int TypeId { get { return GetWord(0); } }
        public int ResultId { get { return GetWord(1); } }

        internal Undef(TypeInstruction type, int resultId) : base(OpCode.OpUndef, type.ResultId, resultId)
        {
        }
    }
}
