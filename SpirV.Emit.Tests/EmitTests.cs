using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpirV.Emit.Instructions;

namespace SpirV.Emit.Tests
{
    [TestFixture]
    public class EmitTests
    {
        public const int HeaderSize = 5;

        public class UndefType : TypeInstruction
        {
            public UndefType() : base((OpCode)short.MaxValue, 5)
            {
            }
        }

        [Test]
        public void MagicNumberIsSpecificConstant()
        {
            Assert.That(Emit.SpirVMagic, Is.EqualTo(0x07230203));
        }

        [Test]
        public void Nop_ReturnsNopInstruction()
        {
            var emit = new Emit(new Header());

            // Act
            var ins = emit.EmitNop();

            Assert.That(ins.OpCode, Is.EqualTo(OpCode.OpNop));
            Assert.That(emit.CurrentOffset, Is.EqualTo(HeaderSize + 1));
        }

        [Test]
        public void Undef_ReturnsUndefInstruction()
        {
            var emit = new Emit(new Header());
            var type = new UndefType();

            // Act
            var result = emit.EmitUndef(type);

            Assert.That(result.OpCode, Is.EqualTo(OpCode.OpUndef));
            Assert.That(result.ResultType, Is.EqualTo(5));
            Assert.That(result.ResultId, Is.EqualTo(1));
        }
    }
}
