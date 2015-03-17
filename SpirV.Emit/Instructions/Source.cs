using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit.Instructions
{
    public class Source : Instruction
    {
        public Source(SourceLanguage source, int version) : base(OpCode.OpSource, (int)source, version)
        {
        }
    }
}
