using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpirV.Emit.Instructions;

namespace SpirV.Emit
{
    public abstract class Instruction : IEquatable<Instruction>
    {
        private readonly OpCode _opCode;
        private readonly uint[] _words;

        public OpCode OpCode { get { return _opCode; } }

        public uint GetHeader()
        {
            return unchecked((unchecked((uint)_words.Length + 1) << 16  | (uint) _opCode));
        }

        public int CopyTo(IList<uint> target)
        {
            target.Add(GetHeader());
            foreach (var word in _words)
            {
                target.Add(word);
            }
            return _words.Length + 1;
        }

        protected uint GetWord(int index)
        {
            if(index >= _words.Length || index < 0)
                throw new ArgumentOutOfRangeException("index");

            return _words[index];
        }

        protected Instruction(OpCode opCode, params uint[] words)
        {
            _opCode = opCode;
            _words = words;
        }

        public bool Equals(Instruction other)
        {
            return other._opCode == _opCode && _words.SequenceEqual(other._words);
        }

        protected virtual string ParametersToString()
        {
            var skip = 0;
            if (this is IResultId)
                ++skip;
            if (!(this is IResultType))
                return string.Join(" ", _words.Skip(skip));

            return GetWord(0) + " " + string.Join(" ", _words.Skip(skip + 1));
        }

        public override string ToString()
        {
            var resultId = this as IResultId;
            string output = "";
            if (resultId != null)
                output += resultId.ResultId + ":\t";
            else
                output = "\t\t";


            output += OpCode + " ";

            output += ParametersToString();

            return output;
        }
    }
}
