using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit.Instructions
{
    public abstract class TypeInstruction : Instruction, IResultId
    {
        public int ResultId { get { return GetWord(0); } }
        protected TypeInstruction(OpCode opCode, params int[] words) : base(opCode, words)
        {
        }
    }
}
