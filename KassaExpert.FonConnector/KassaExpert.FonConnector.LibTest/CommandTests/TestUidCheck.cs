using FluentAssertions;
using KassaExpert.FonConnector.Lib.Session.Impl;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.LibTest.CommandTests
{
    [TestFixture]
    public class TestUidCheck
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
        public async Task TestUid()
        {
            var result = await _session.CheckUid(Environment.GetEnvironmentVariable("HERSTELLER_UID"));
            result.IsSuccessful.Should().BeTrue();
        }
    }
}