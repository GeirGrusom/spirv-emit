using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace SpirV.Emit.Tests
{
    public class InstructionTests
    {

        public class FooInstruction : Instruction
        {
            public FooInstruction(OpCode opCode, params int[] words) : base(opCode, words)
            {
            }
        }

        [Test]
        public void GetHeader_WordCount_And_OpCode_Encoded()
        {
            var instruction = new FooInstruction((OpCode) 1, 123);

            // Upper 16-bits includes the word count. This includes the header word.
            // REF: WordCount: The number of words taken by an instruction, including the instruction’s opcode and optional operands. That is, the
            // total space taken by the instruction.

            Assert.That(instruction.GetHeader(), Is.EqualTo(0x00020001));
        }
    }
}
