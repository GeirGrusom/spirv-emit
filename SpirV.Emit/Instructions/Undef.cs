namespace SpirV.Emit.Instructions
{
    public sealed class Undef : Instruction, IResultId, IResultType
    {

        public uint ResultType { get { return GetWord(0); } }
        public uint ResultId { get { return GetWord(1); } }

        internal Undef(TypeInstruction type, uint resultId) : base(OpCode.OpUndef, type.ResultId, resultId)
        {
        }
    }
}
