using FluentAssertions;
using KassaExpert.FonConnector.Lib.Util;
using NUnit.Framework;

namespace KassaExpert.FonConnector.LibTest.UtilTests
{
    [TestFixture]
    public class SerialUtilTest
    {
        [TestCase("nonono")]
        [TestCase("1234567890abcdefg")]
        public void TestInvalidSerial(string invalidHex)
        {
            SerialUtil.IsValidHexSerial(invalidHex).Should().BeFalse();
        }

        [TestCase("1234567890abcdef")]
        public void TestValidSerial(string validHex)
        {
            SerialUtil.IsValidHexSerial(validHex).Should().BeTrue();
        }
    }
}