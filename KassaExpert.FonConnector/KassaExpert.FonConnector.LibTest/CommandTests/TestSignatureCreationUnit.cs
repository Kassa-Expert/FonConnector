using FluentAssertions;
using KassaExpert.FonConnector.Lib.Enum;
using KassaExpert.FonConnector.Lib.Session.Impl;
using KassaExpert.Util.Lib.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.LibTest.CommandTests
{
    [TestFixture]
    public class TestSignatureCreationUnit
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

        [Test]
        public async Task TestRegistration()
        {
            await _session.SignatureCreationUnitCommand.Register(new Lib.Command.Impl.SignatureCreationUnit.RegisterPayload(SignatureCreationUnitType.HSM_DIENSTLEISTER, TrustProvider.TEST, "12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestCheck()
        {
            var result = await _session.SignatureCreationUnitCommand.Check(new Lib.Command.Impl.SignatureCreationUnit.CheckPayload("12345678"));
            result.Payload.Should().BeTrue();
        }

        [Test]
        public async Task TestDecommission()
        {
            await _session.SignatureCreationUnitCommand.Decommission(new Lib.Command.Impl.SignatureCreationUnit.DecommissioningPayload(SignatureCreationUnitDecommissioningType.REV_ERROR, "12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestRecommission()
        {
            await _session.SignatureCreationUnitCommand.Recommission(new Lib.Command.Impl.SignatureCreationUnit.RecommissioningPayload("12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestDecommissionAbsolute()
        {
            await _session.SignatureCreationUnitCommand.Decommission(new Lib.Command.Impl.SignatureCreationUnit.DecommissioningPayload(SignatureCreationUnitDecommissioningType.INV_PLANNED, "12345678"));
            Assert.Pass();
        }

        [Test]
        public async Task TestFlow()
        {
            await _session.SignatureCreationUnitCommand.Register(new Lib.Command.Impl.SignatureCreationUnit.RegisterPayload(SignatureCreationUnitType.HSM_DIENSTLEISTER, TrustProvider.TEST, "12345678"));

            var result1 = await _session.SignatureCreationUnitCommand.Check(new Lib.Command.Impl.SignatureCreationUnit.CheckPayload("12345678"));
            result1.Payload.Should().BeTrue();

            await _session.SignatureCreationUnitCommand.Decommission(new Lib.Command.Impl.SignatureCreationUnit.DecommissioningPayload(SignatureCreationUnitDecommissioningType.REV_ERROR, "12345678"));

            //NOT WORKING, API ALWAYS RETURNS IN_BETRIEB
            var result2 = await _session.SignatureCreationUnitCommand.Check(new Lib.Command.Impl.SignatureCreationUnit.CheckPayload("12345678"));
            result2.Payload.Should().BeFalse();

            await _session.SignatureCreationUnitCommand.Recommission(new Lib.Command.Impl.SignatureCreationUnit.RecommissioningPayload("12345678"));

            var result3 = await _session.SignatureCreationUnitCommand.Check(new Lib.Command.Impl.SignatureCreationUnit.CheckPayload("12345678"));
            result3.Payload.Should().BeTrue();

            await _session.SignatureCreationUnitCommand.Decommission(new Lib.Command.Impl.SignatureCreationUnit.DecommissioningPayload(SignatureCreationUnitDecommissioningType.INV_PLANNED, "12345678"));

            //NOT WORKING, API ALWAYS RETURNS IN_BETRIEB
            var result4 = await _session.SignatureCreationUnitCommand.Check(new Lib.Command.Impl.SignatureCreationUnit.CheckPayload("12345678"));
            result4.Payload.Should().BeFalse();
        }
    }
}