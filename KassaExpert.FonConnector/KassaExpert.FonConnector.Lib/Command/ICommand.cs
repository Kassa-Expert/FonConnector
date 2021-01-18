using System;
using System.Collections.Generic;
using System.Text;

namespace KassaExpert.FonConnector.Lib.Command
{
    public interface ICommand<in TRegister, in TCheck, in TDecommissioning, in TRecommissioning>
        where TRegister : class
        where TCheck : class
        where TDecommissioning : class
        where TRecommissioning : class
    {
        CommandResult Register(TRegister commandPayload);

        CommandResult Check(TCheck commandPayload);

        CommandResult Decommission(TDecommissioning commandPayload);

        CommandResult Recommission(TRecommissioning commandPayload);
    }
}