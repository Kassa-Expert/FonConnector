﻿using KassaExpert.FonConnector.Lib.Command;
using System;
using System.Collections.Generic;
using System.Text;
using KassaExpert.FonConnector.Lib.Command.Impl;

namespace KassaExpert.FonConnector.Lib.Session.Impl
{
    public sealed class FonSession : ISession
    {
        /// <summary>
        /// When _sessionId is null → currenly no valid Session open → throw error to client error instead of calling without Session
        /// </summary>
        private string? _sessionId;

        internal bool HasSession => _sessionId is not null;

        internal string? GetSessionId() => _sessionId;

        public FonSession(string teilnehmerId, string benutzerId, string pin)
        {
            SignatureCreationUnitCommand = new Command.Impl.SignatureCreationUnit.CommandImpl(this);
        }

        public ICommand<Command.Impl.SignatureCreationUnit.RegisterPayload, Command.Impl.SignatureCreationUnit.CheckPayload, Command.Impl.SignatureCreationUnit.DecommissioningPayload, Command.Impl.SignatureCreationUnit.RecommissioningPayload> SignatureCreationUnitCommand { get; }

        #region IDisposable

        private bool _disposed = false;

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }

        #endregion IDisposable
    }
}