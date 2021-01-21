using System.Threading.Tasks;

namespace KassaExpert.FonConnector.Lib.Command
{
    public interface ICommand<in TRegister, in TCheck, in TDecommissioning, in TRecommissioning>
        where TRegister : class
        where TCheck : class
        where TDecommissioning : class
        where TRecommissioning : class
    {
        Task<CommandResult> Register(TRegister commandPayload);

        Task<CommandPayloadResult<bool>> Check(TCheck commandPayload);

        Task<CommandResult> Decommission(TDecommissioning commandPayload);

        Task<CommandResult> Recommission(TRecommissioning commandPayload);
    }
}