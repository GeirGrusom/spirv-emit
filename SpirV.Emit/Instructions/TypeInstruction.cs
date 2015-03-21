using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit.Instructions
{
    public abstract class TypeInstruction : Instruction, IResultId
    {
        public uint ResultId { get { return GetWord(0); } }
        protected TypeInstruction(OpCode opCode, params uint[] words) : base(opCode, words)
        {
        }
    }
}
