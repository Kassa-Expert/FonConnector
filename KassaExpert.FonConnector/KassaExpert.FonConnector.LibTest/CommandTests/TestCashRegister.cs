using FluentAssertions;
using KassaExpert.FonConnector.Lib.Enum;
using KassaExpert.FonConnector.Lib.Session.Impl;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.LibTest.CommandTests
{
    [TestFixture]
    public class TestCashRegister
    {
        private static readonly string? _tid = Environment.GetEnvironmentVariable("TID_TEST");
        private static readonly string? _bid = Environment.GetEnvironmentVariable("BID_TEST");
        private static readonly string? _pin = Environment.GetEnvironmentVariable("PIN_TEST");

        private FonSession _session;

        [SetUp]
        public void Setup()
        {
            _tid.Should().NotBeNullOrEmpty("SET ENVIRONMENT-VARIABLES");
            _bid.Should().NotBeNullOrEmpty("SET ENVIRONMENT-VARIABLES");
            _pin.Should().NotBeNullOrEmpty("SET ENVIRONMENT-VARIABLES");

            _session = new FonSession(_tid!, _bid!, _pin!);
            _session.SetTestSession(true);
        }

        [TearDown]
        public void Cleanup()
        {
            _session.Dispose();
        }

        public static string GenerateAes256Key()
        {
            using (var aesKey = new AesManaged())
            {
                aesKey.KeySize = 256;
                aesKey.GenerateKey();

                return Convert.ToBase64String(aesKey.Key);
            }
        }

        [Test]
        public async Task TestRegistration()
        {
            await _session.CashRegisterCommand.Register(new Lib.Command.Impl.CashRegister.RegisterPayload("12345678", GenerateAes256Key()));
            Assert.Pass();
        }

        [Test]
        public async Task TestCheck()
        {
            var result = await _session.CashRegisterCommand.Check(new Lib.Command.Impl.CashRegister.CheckPayload("12345678"));
            result.IsSuccessful.Should().BeTrue();
            result.Payload.Should().BeTrue();
        }

        [Test]
        public async Task TestDecommission()
        {
            await _session.CashRegisterCommand.Decommission(new Lib.Command.Impl.CashRegister.DecommissioningPayload(SignatureCreationUnitDecommissioningType.REV_ERROR, "12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestRecommission()
        {
            await _session.CashRegisterCommand.Recommission(new Lib.Command.Impl.CashRegister.RecommissioningPayload("12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestDecommissionAbsolute()
        {
            await _session.CashRegisterCommand.Decommission(new Lib.Command.Impl.CashRegister.DecommissioningPayload(SignatureCreationUnitDecommissioningType.INV_PLANNED, "12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestFlow()
        {
            await _session.CashRegisterCommand.Register(new Lib.Command.Impl.CashRegister.RegisterPayload("12345678", GenerateAes256Key()));

            var result1 = await _session.CashRegisterCommand.Check(new Lib.Command.Impl.CashRegister.CheckPayload("12345678"));
            result1.IsSuccessful.Should().BeTrue();
            result1.Payload.Should().BeTrue();

            await _session.CashRegisterCommand.Decommission(new Lib.Command.Impl.CashRegister.DecommissioningPayload(SignatureCreationUnitDecommissioningType.REV_ERROR, "12345678"));

            //NOT WORKING, API ALWAYS RETURNS IN_BETRIEB
            var result2 = await _session.CashRegisterCommand.Check(new Lib.Command.Impl.CashRegister.CheckPayload("12345678"));
            result2.IsSuccessful.Should().BeTrue();
            result2.Payload.Should().BeFalse();

            await _session.CashRegisterCommand.Recommission(new Lib.Command.Impl.CashRegister.RecommissioningPayload("12345678"));

            var result3 = await _session.CashRegisterCommand.Check(new Lib.Command.Impl.CashRegister.CheckPayload("12345678"));
            result3.IsSuccessful.Should().BeTrue();
            result3.Payload.Should().BeTrue();

            await _session.CashRegisterCommand.Decommission(new Lib.Command.Impl.CashRegister.DecommissioningPayload(SignatureCreationUnitDecommissioningType.INV_PLANNED, "12345678"));

            //NOT WORKING, API ALWAYS RETURNS IN_BETRIEB
            var result4 = await _session.CashRegisterCommand.Check(new Lib.Command.Impl.CashRegister.CheckPayload("12345678"));
            result4.IsSuccessful.Should().BeTrue();
            result4.Payload.Should().BeFalse();
        }
    }
}