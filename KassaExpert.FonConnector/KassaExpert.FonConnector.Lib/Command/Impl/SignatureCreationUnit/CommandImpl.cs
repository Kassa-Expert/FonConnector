using KassaExpert.FonConnector.Lib.RegKassaService;
using KassaExpert.FonConnector.Lib.Session.Impl;
using KassaExpert.FonConnector.Lib.Util;
using System.Threading.Tasks;

namespace KassaExpert.FonConnector.Lib.Command.Impl.SignatureCreationUnit
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
            if (!SerialUtil.IsValidHexSerial(commandPayload.HexSerial))
            {
                return new CommandPayloadResult<bool>(false, false, "HEX-SERIENNUMMER NICHT VALIDE (darf kein Präfix 0x haben)");
            }

            var sicherheitseinrichtung = new status_see();
            sicherheitseinrichtung.paket_nr = RandomUtil.GetRandomNumberString(9);
            sicherheitseinrichtung.satznr = RandomUtil.GetRandomNumberString(9);
            sicherheitseinrichtung.ts_erstellung = DateUtil.GetAustriaDateNow();

            sicherheitseinrichtung.zertifikatsseriennummer = new zertifikatsseriennummer
            {
                Value = commandPayload.HexSerial,
                hex = true,
                hexSpecified = true,
            };

            var response = await _session.ExecutePlainCommand(sicherheitseinrichtung);

            if (!response.CommandResult.IsSuccessful)
            {
                return new CommandPayloadResult<bool>(response.CommandResult, false);
            }

            return new CommandPayloadResult<bool>(response.CommandResult, response.Response.abfrage_ergebnis?.status == abfrage_ergebnisStatus.IN_BETRIEB);
        }

        public async Task<CommandResult> Decommission(DecommissioningPayload commandPayload)
        {
            if (!SerialUtil.IsValidHexSerial(commandPayload.HexSerial))
            {
                return new CommandResult(false, "HEX-SERIENNUMMER NICHT VALIDE (darf kein Präfix 0x haben)");
            }

            var sicherheitseinrichtung = new ausfall_se();

            sicherheitseinrichtung.zertifikatsseriennummer = new zertifikatsseriennummer
            {
                Value = commandPayload.HexSerial,
                hex = true,
                hexSpecified = true,
            };

            sicherheitseinrichtung.satznr = RandomUtil.GetRandomNumberString();

            if (commandPayload.Type.IsReversible)
            {
                sicherheitseinrichtung.Item = new ausfall
                {
                    beginn_ausfall = DateUtil.GetAustriaDateNow(),
                    begruendung = commandPayload.Type.Id
                };
            }
            else
            {
                sicherheitseinrichtung.Item = new ausserbetriebnahme
                {
                    begruendung = commandPayload.Type.Id
                };
            }

            return (await _session.ExecuteRkdbCommand(sicherheitseinrichtung)).CommandResult;
        }

        public async Task<CommandResult> Recommission(RecommissioningPayload commandPayload)
        {
            if (!SerialUtil.IsValidHexSerial(commandPayload.HexSerial))
            {
                return new CommandResult(false, "HEX-SERIENNUMMER NICHT VALIDE (darf kein Präfix 0x haben)");
            }

            var sicherheitseinrichtung = new wiederinbetriebnahme_se();

            sicherheitseinrichtung.satznr = RandomUtil.GetRandomNumberString();
            sicherheitseinrichtung.ende_ausfall = DateUtil.GetAustriaDateNow();
            sicherheitseinrichtung.zertifikatsseriennummer = new zertifikatsseriennummer
            {
                Value = commandPayload.HexSerial,
                hex = true,
                hexSpecified = true
            };

            return (await _session.ExecuteRkdbCommand(sicherheitseinrichtung)).CommandResult;
        }

        public async Task<CommandResult> Register(RegisterPayload commandPayload)
        {
            if (!SerialUtil.IsValidHexSerial(commandPayload.HexSerial))
            {
                return new CommandResult(false, "HEX-SERIENNUMMER NICHT VALIDE (darf kein Präfix 0x haben)");
            }

            var sicherheitseinrichtung = new registrierung_se();

            sicherheitseinrichtung.satznr = RandomUtil.GetRandomNumberString();
            sicherheitseinrichtung.art_se = commandPayload.Type.FonType;
            sicherheitseinrichtung.vda_id = commandPayload.Provider.FonString;

            sicherheitseinrichtung.Item = new zertifikatsseriennummer
            {
                Value = commandPayload.HexSerial,
                hex = true,
                hexSpecified = true
            };

            return (await _session.ExecuteRkdbCommand(sicherheitseinrichtung)).CommandResult;
        }
    }
}