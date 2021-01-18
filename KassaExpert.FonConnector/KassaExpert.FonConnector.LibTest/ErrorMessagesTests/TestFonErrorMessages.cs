using FluentAssertions;
using KassaExpert.FonConnector.Lib.ErrorMessages;
using NUnit.Framework;
using System;
using System.Linq;

namespace KassaExpert.FonConnector.LibTest.ErrorMessagesTests
{
    [TestFixture]
    public class TestFonErrorMessages
    {
        [Test]
        public void TestListCount()
        {
            FonErrorMessages.List.Should().HaveCount(68);
        }

        [Test]
        public void TestNegativeReturnCodesCount()
        {
            FonErrorMessages.List.Where(e => e.ReturnCode.StartsWith('-')).Should().HaveCount(4);
        }

        [Test]
        public void Test_B_ReturnCodesCount()
        {
            FonErrorMessages.List.Where(e => e.ReturnCode.StartsWith('B')).Should().HaveCount(25);
        }

        [Test]
        public void Test_C_ReturnCodesCount()
        {
            FonErrorMessages.List.Where(e => e.ReturnCode.StartsWith('C')).Should().HaveCount(1);
        }

        [Test]
        public void Test_V_ReturnCodesCount()
        {
            FonErrorMessages.List.Where(e => e.ReturnCode.StartsWith('V')).Should().HaveCount(16);
        }

        [Test]
        public void TestUniqueErrorMessages()
        {
            FonErrorMessages.List.Select(e => e.ErrorMessage).Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void TestUniqueReturnCodes()
        {
            FonErrorMessages.List.Select(e => e.ReturnCode).Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void TestEveryReturnCodeGetsSameItem()
        {
            foreach (var expectedError in FonErrorMessages.List)
            {
                var response = FonErrorMessages.GetByFonReturnCode(expectedError.ReturnCode);

                response.Should().Be(expectedError);
            }
        }

        [Test]
        public void TestNotFoundKey()
        {
            Action act = () => FonErrorMessages.GetByFonReturnCode("SOME RANDOM STRING");
            act.Should().Throw<InvalidOperationException>();
        }
    }
}