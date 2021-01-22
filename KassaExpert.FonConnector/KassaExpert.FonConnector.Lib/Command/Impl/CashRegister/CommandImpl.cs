using KassaExpert.FonConnector.Lib.RegKassaService;
using KassaExpert.FonConnector.Lib.Session.Impl;
using KassaExpert.FonConnector.Lib.Util;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.Lib.Command.Impl.CashRegister
{
    internal sealed class CommandImpl : ICommand<RegisterPayload, CheckPayload, DecommissioningPayload, RecommissioningPayload>
    {
        private readonly FonSession _session;

        internal CommandImpl(FonSession session)
        {
            _session = session;
        }

        public async Task<CommandPayloadResult<bool>> Check(CheckPayload commandPayload)
        {
            var status = new status_kasse();

            status.paket_nr = RandomUtil.GetRandomNumberString(9);
            status.satznr = RandomUtil.GetRandomNumberString(9);
            status.ts_erstellung = DateUtil.GetAustriaDateNow();
            status.kassenidentifikationsnummer = commandPayload.IdentificationNumber;

            var response = await _session.ExecutePlainCommand(status);

            if (!response.CommandResult.IsSuccessful)
            {
                return new CommandPayloadResult<bool>(response.CommandResult, false);
            }

            return new CommandPayloadResult<bool>(response.CommandResult, response.Response.abfrage_ergebnis?.status == abfrage_ergebnisStatus.IN_BETRIEB);
        }

        public async Task<CommandResult> Decommission(DecommissioningPayload commandPayload)
        {
            var ausfall = new ausfall_kasse();

            ausfall.kassenidentifikationsnummer = commandPayload.IdentificationNumber;
            ausfall.satznr = RandomUtil.GetRandomNumberString();

            if (commandPayload.Type.IsReversible)
            {
                ausfall.Item = new ausfall
                {
                    beginn_ausfall = DateUtil.GetAustriaDateNow(),
                    begruendung = commandPayload.Type.Id
                };
            }
            else
            {
                ausfall.Item = new ausserbetriebnahme
                {
                    begruendung = commandPayload.Type.Id
                };
            }

            return (await _session.ExecuteRkdbCommand(ausfall)).CommandResult;
        }

        public async Task<CommandResult> Recommission(RecommissioningPayload commandPayload)
        {
            var wiederinbetriebnahme = new wiederinbetriebnahme_kasse();

            wiederinbetriebnahme.satznr = RandomUtil.GetRandomNumberString();
            wiederinbetriebnahme.kassenidentifikationsnummer = commandPayload.IdentificationNumber;
            wiederinbetriebnahme.ende_ausfall = DateUtil.GetAustriaDateNow();

            return (await _session.ExecuteRkdbCommand(wiederinbetriebnahme)).CommandResult;
        }

        public async Task<CommandResult> Register(RegisterPayload commandPayload)
        {
            var registrierung = new registrierung_kasse();

            registrierung.satznr = RandomUtil.GetRandomNumberString();
            registrierung.kassenidentifikationsnummer = commandPayload.IdentificationNumber;
            registrierung.benutzerschluessel = commandPayload.AesKeyBase64;

            return (await _session.ExecuteRkdbCommand(registrierung)).CommandResult;
        }
    }
}