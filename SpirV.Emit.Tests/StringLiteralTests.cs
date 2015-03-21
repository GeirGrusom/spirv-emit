using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SpirV.Emit.Tests
{
    [TestFixture]
    public class StringLiteralTests
    {
        [Test]
        public void Create_EmptyString_Returns0()
        {
            var results = StringLiteral.Create("");

            Assert.That(results, Is.EquivalentTo(new uint[] { 0 }));
        }

        [Test]
        public void Create_NullString_ThrowsArgumentNullException()
        {
            Assert.That(() => StringLiteral.Create(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Create_Foo_LittleEndian_ReturnsAsciiFoo()
        {
            var results = StringLiteral.Create("Foo", LiteralConversionType.LittleEndian);

            Assert.That(results, Is.EquivalentTo(new[] {unchecked((uint) ('F' | 'o' << 8 | 'o' << 16))}));
        }

        [Test]
        // Strings are null-terminated for some reason.
        public void Create_Foob_LittleEndian_ReturnsAsciiFoob_FollowedByZero()
        {
            var results = StringLiteral.Create("Foob", LiteralConversionType.LittleEndian);

            Assert.That(results, Is.EquivalentTo(new[] { unchecked((uint)('F' | 'o' << 8 | 'o' << 16 | 'b' << 24)), 0u }));
        }


        [Test]
        public void Create_Foo_BigEndian_ReturnsAsciiFoo()
        {
            var results = StringLiteral.Create("Foo", LiteralConversionType.BigEndian);

            Assert.That(results, Is.EquivalentTo(new[] { unchecked((uint)('F' << 24 | 'o' << 16 | 'o' << 8)) }));
        }

    }
}
