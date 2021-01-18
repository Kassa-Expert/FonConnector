using FluentAssertions;
using KassaExpert.FonConnector.Lib.Util;
using NUnit.Framework;

namespace KassaExpert.FonConnector.LibTest.UtilTests
{
    [TestFixture]
    public class SerialUtilTest
    {
        [Test]
        public void TestInvalidSerial()
        {
            SerialUtil.IsValidHexSerial("nonono").Should().BeFalse();
        }
    }
}