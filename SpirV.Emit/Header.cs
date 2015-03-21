using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit
{
    public struct Header
    {
        public uint GeneratorMagic;
        public uint Version;
        public uint InstructionSchema;
    }
}
