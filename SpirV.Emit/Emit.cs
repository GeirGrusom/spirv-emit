using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpirV.Emit
{
    public class Emit
    {
        private int _ip;
        private readonly List<int> _data;

        public const int SpirVMagic = 0x07230203;

        public Emit()
        {
            _data = new List<int>();
        }

        public void WriteHeader()
        {
            
        }

        public void Write(Instruction instruction)
        {
            
        }
    }
}
