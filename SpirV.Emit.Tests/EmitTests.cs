using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpirV.Emit.Tests
{
    [TestFixture]
    public class EmitTests
    {
        [Test]
        public void MagicNumberIsSpecificConstant()
        {
            Assert.That(Emit.SpirVMagic, Is.EqualTo(0x07230203));
        }
    }
}
