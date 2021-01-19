using FluentAssertions;
using KassaExpert.FonConnector.Lib.Enum;
using NUnit.Framework;
using System;
using System.Linq;

namespace KassaExpert.FonConnector.LibTest.ErrorMessagesTests
{
    [TestFixture]
    public class TestFonRegKassaServiceReturnCodes
    {
        [Test]
        public void TestListCount()
        {
            FonRegKassaServiceReturnCodes.List.Should().HaveCount(68);
        }

        [Test]
        public void TestNegativeReturnCodesCount()
        {
            FonRegKassaServiceReturnCodes.List.Where(e => e.ReturnCode.StartsWith('-')).Should().HaveCount(4);
        }

        [Test]
        public void Test_B_ReturnCodesCount()
        {
            FonRegKassaServiceReturnCodes.List.Where(e => e.ReturnCode.StartsWith('B')).Should().HaveCount(25);
        }

        [Test]
        public void Test_C_ReturnCodesCount()
        {
            FonRegKassaServiceReturnCodes.List.Where(e => e.ReturnCode.StartsWith('C')).Should().HaveCount(1);
        }

        [Test]
        public void Test_V_ReturnCodesCount()
        {
            FonRegKassaServiceReturnCodes.List.Where(e => e.ReturnCode.StartsWith('V')).Should().HaveCount(16);
        }

        [Test]
        public void TestUniqueErrorMessages()
        {
            FonRegKassaServiceReturnCodes.List.Select(e => e.ErrorMessage).Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void TestUniqueReturnCodes()
        {
            FonRegKassaServiceReturnCodes.List.Select(e => e.ReturnCode).Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void TestEveryReturnCodeGetsSameItem()
        {
            foreach (var expectedError in FonRegKassaServiceReturnCodes.List)
            {
                var response = FonRegKassaServiceReturnCodes.GetByFonReturnCode(expectedError.ReturnCode);

                response.Should().Be(expectedError);
            }
        }

        [Test]
        public void TestNotFoundKey()
        {
            Action act = () => FonRegKassaServiceReturnCodes.GetByFonReturnCode("SOME RANDOM STRING");
            act.Should().Throw<InvalidOperationException>();
        }
    }
}