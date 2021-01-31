using KassaExpert.FonConnector.Lib.Command;
using System;
using System.Threading.Tasks;
using KassaExpert.FonConnector.Lib.SessionService;
using KassaExpert.FonConnector.Lib.Enum;
using KassaExpert.FonConnector.Lib.Util;
using KassaExpert.FonConnector.Lib.Exception;
using KassaExpert.FonConnector.Lib.UidAbfrageService;
using KassaExpert.FonConnector.Lib.RegKassaService;
using KassaExpert.Util.Lib.Date;
using KassaExpert.Util.Lib.Validation;

namespace KassaExpert.FonConnector.Lib.Session.Impl
{
    public sealed class FonSession : ISession
    {
        private readonly IDate _dateUtil = IDate.GetInstance();
        private readonly IValidation _validationUtil = IValidation.GetInstance();

        /// <summary>
        /// When _sessionId is null → currenly no valid Session open → throw error to client error instead of calling without Session
        /// </summary>
        private string? _sessionId;

        private bool _isTestSession = false;

        private readonly string _teilnehmerId;
        private readonly string _benutzerId;
        private readonly string _pin;

        public void SetTestSession(bool isTestSession)
        {
            _isTestSession = isTestSession;
        }

        /// <summary>
        /// used to prevent multiple events from happening at the same time
        /// </summary>
        private readonly TaskQueue _taskQueue = new TaskQueue();

        private bool _loginTried = false;

        internal Task<string> GetSessionId()
        {
            return _taskQueue.Enqueue(async () =>
            {
                if (!_loginTried)
                {
                    _loginTried = true;
                    await Login();
                }

                if (_sessionId is not null)
                {
                    return _sessionId;
                }

                throw new NoSessionException();
            });
        }

        public FonSession(string teilnehmerId, string benutzerId, string pin)
        {
            _teilnehmerId = teilnehmerId;
            _benutzerId = benutzerId;
            _pin = pin;

            SignatureCreationUnitCommand = new Command.Impl.SignatureCreationUnit.CommandImpl(this);
            CashRegisterCommand = new Command.Impl.CashRegister.CommandImpl(this);
        }

        internal Task<(CommandResult CommandResult, result Response)> ExecuteRkdbCommand(object command)
        {
            var request = new rkdb
            {
                Items = new object[] { command },
                paket_nr = RandomUtil.GetRandomNumberString(),
                ts_erstellung = _dateUtil.GetMezNow()
            };

            return ExecutePlainCommand(request);
        }

        internal async Task<(CommandResult CommandResult, result Response)> ExecutePlainCommand(object command)
        {
            var request = new rkdbRequest1
            {
                rkdbRequest = new rkdbRequest
                {
                    tid = _teilnehmerId,
                    benid = _benutzerId,
                    id = await GetSessionId(),
                    art_uebermittlung = _isTestSession ? art_uebermittlung.T : art_uebermittlung.P,
                    erzwinge_asynchron = false,
                    Item = command
                }
            };

            var clt = new rkdbServicePortClient();

            await clt.OpenAsync();

            var response = await clt.rkdbAsync(request);

            await clt.CloseAsync();

            var status = FonRegKassaServiceReturnCodes.GetByFonReturnCode(response.rkdbResponse.result[0].rkdbMessage[0].rc);

            if (!status.Success)
            {
                return (new CommandResult(false, status.ErrorMessage), response.rkdbResponse.result[0]);
            }

            return (new CommandResult(true, status.ErrorMessage), response.rkdbResponse.result[0]);
        }

        internal async Task Login()
        {
            var clt = new sessionServicePortClient();

            await clt.OpenAsync();

            var response = await clt.loginAsync(new loginRequest
            {
                Body = new loginRequestBody
                {
                    benid = _benutzerId,
                    herstellerid = Environment.GetEnvironmentVariable("HERSTELLER_UID"),
                    pin = _pin,
                    tid = _teilnehmerId
                }
            });

            await clt.CloseAsync();

            var status = FonSessionServiceReturnCodes.GetByFonReturnCode(response.Body.rc);

            if (!status.Success)
            {
                throw new NoSessionException(status.ErrorMessage);
            }

            _sessionId = response.Body.id;
        }

        internal async Task Logout()
        {
            if (_sessionId is null)
                return;

            var clt = new sessionServicePortClient();

            await clt.OpenAsync();

            var response = await clt.logoutAsync(new logoutRequest
            {
                Body = new logoutRequestBody
                {
                    tid = _teilnehmerId,
                    benid = _benutzerId,
                    id = _sessionId
                }
            });

            await clt.CloseAsync();

            var status = FonSessionServiceReturnCodes.GetByFonReturnCode(response.Body.rc);

            if (!status.Success)
            {
                throw new SessionException(status.ErrorMessage);
            }

            _sessionId = null;
        }

        public ICommand<Command.Impl.SignatureCreationUnit.RegisterPayload, Command.Impl.SignatureCreationUnit.CheckPayload, Command.Impl.SignatureCreationUnit.DecommissioningPayload, Command.Impl.SignatureCreationUnit.RecommissioningPayload> SignatureCreationUnitCommand { get; }

        public ICommand<Command.Impl.CashRegister.RegisterPayload, Command.Impl.CashRegister.CheckPayload, Command.Impl.CashRegister.DecommissioningPayload, Command.Impl.CashRegister.RecommissioningPayload> CashRegisterCommand { get; }

        public async Task<CommandResult> CheckSignature(string maschinenlesbarerCode)
        {
            var beleghcheck = new belegpruefung();
            beleghcheck.beleg = maschinenlesbarerCode;
            beleghcheck.satznr = RandomUtil.GetRandomNumberString();

            return (await ExecuteRkdbCommand(beleghcheck)).CommandResult;
        }

        public async Task<CommandResult> CheckUid(string uid)
        {
            if (!_validationUtil.IsValidUid(uid))
            {
                return new CommandResult(false, "UID ist keine gültige ATU Nummer (muss ohne Leerzeichen sein, Prüfziffer wird überprüft)");
            }

            var request = new uidAbfrageServiceRequest
            {
                Body = new uidAbfrageServiceRequestBody
                {
                    tid = _teilnehmerId,
                    benid = _benutzerId,
                    id = await GetSessionId(),
                    uid_tn = Environment.GetEnvironmentVariable("HERSTELLER_UID"),
                    stufe = "1",
                    uid = uid,
                }
            };

            var clt = new uidAbfragePortClient();

            await clt.OpenAsync();

            var response = await clt.uidAbfrageAsync(request);

            await clt.CloseAsync();

            var status = FonUidAbfrageServiceReturnCodes.GetByFonReturnCode(response.Body.rc);

            return new CommandResult(status.Success, status.ErrorMessage);
        }

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
                Task.Run(async () => await Logout()).Wait();
            }

            _disposed = true;
        }

        #endregion IDisposable
    }
}