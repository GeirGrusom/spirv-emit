using SpirV.Emit.Instructions;

namespace SpirV.Emit
{
    public partial class Emit
    {
        public Nop EmitNop()
        {
            Write(Nop.Instance);
            return Nop.Instance;
        }

        public Undef EmitUndef(TypeInstruction type)
        {
            var ins = new Undef(type, AllocateId());
            Write(ins);
            return ins;
        }
    }
}
