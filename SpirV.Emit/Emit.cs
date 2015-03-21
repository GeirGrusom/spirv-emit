using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit
{
    public partial class Emit
    {
        private uint _id;
        private int _ip;
        private readonly List<uint> _data;
        public const uint SpirVMagic = 0x07230203;
        private readonly Header _header;

        public uint GeneratorMagic { get { return _header.GeneratorMagic; } }
        public uint Version { get { return _header.Version; } }

        public int CurrentOffset { get { return _ip; } }

        protected uint AllocateId()
        {
            return ++_id;
        }

        public Emit(Header header)
        {
            if(header.InstructionSchema != 0)
                throw new NotSupportedException("InstructionSchema is reserved.");

            _data = new List<uint>
            {
                0, // Magic
                0, // Version
                0, // Generator magic
                0, // Bounds
                0,  // Reserved
            };
            _header = header;
            _ip = 5;
        }

        public void WriteHeader()
        {
            _data[0] = SpirVMagic;
            _data[1] = _header.Version;
            _data[2] = _header.GeneratorMagic;
            _data[3] = _id;
            _data[4] = 0; // Reserved for instruction schema.
        }

        protected void Write(Instruction instruction)
        {
            _ip += instruction.CopyTo(_data);
        }
    }
}
