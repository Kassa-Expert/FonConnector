using FluentAssertions;
using KassaExpert.FonConnector.Lib.Util;
using NUnit.Framework;

namespace KassaExpert.FonConnector.LibTest.UtilTests
{
    [TestFixture]
    public class UidUtilTest
    {
        [TestCase("nonono")]
        [TestCase("1234567890abcdefg")]
        [TestCase("Atu12345678")]
        [TestCase("ATU 12 345 678")]
        [TestCase("ATU12345678 ")]
        [TestCase("ATU12345678")]
        public void TestInvalidUid(string invalidUid)
        {
            UidUtil.IsValidUid(invalidUid).Should().BeFalse();
        }

        [TestCase("ATU73952234")]
        [TestCase("ATU73519007")]
        public void TestValidUid(string validUid)
        {
            UidUtil.IsValidUid(validUid).Should().BeTrue();
        }
    }
}