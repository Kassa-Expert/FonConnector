using KassaExpert.FonConnector.Lib.Session.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
{
    internal sealed class CommandImpl : ICommand<RegisterPayload, CheckPayload, DecommissioningPayload, RecommissioningPayload>
    {
        private readonly FonSession _session;

        internal CommandImpl(FonSession session)
        {
            _session = session;
        }

        public CommandResult Check(CheckPayload commandPayload)
        {
            throw new NotImplementedException();
        }

        public CommandResult Decommission(DecommissioningPayload commandPayload)
        {
            throw new NotImplementedException();
        }

        public CommandResult Recommission(RecommissioningPayload commandPayload)
        {
            throw new NotImplementedException();
        }

        public CommandResult Register(RegisterPayload commandPayload)
        {
            throw new NotImplementedException();
        }
    }
}