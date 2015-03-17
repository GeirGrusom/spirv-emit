using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit
{
    public abstract class Instruction
    {
        private readonly OpCode _opCode;
        private readonly int[] _words;

        public OpCode OpCode { get { return _opCode; } }

        public int GetHeader()
        {
            return unchecked((int)(unchecked((ushort) _words.Length + 1) << 16  | (uint) _opCode));
        }

        protected int GetWord(int index)
        {
            if(index >= _words.Length || index < 0)
                throw new ArgumentOutOfRangeException("index");

            return _words[index];
        }

        protected Instruction(OpCode opCode, params int[] words)
        {
            _opCode = opCode;
            _words = words;
        }
    }
}
