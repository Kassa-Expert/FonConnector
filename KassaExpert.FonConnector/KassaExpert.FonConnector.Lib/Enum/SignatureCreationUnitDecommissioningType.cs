using Enum.Ext;

namespace KassaExpert.FonConnector.Lib.Enum
{
    public sealed class SignatureCreationUnitDecommissioningType : TypeSafeEnum<SignatureCreationUnitDecommissioningType, int>
    {
        public static readonly SignatureCreationUnitDecommissioningType REV_LOST = new SignatureCreationUnitDecommissioningType(1, true, "1", "Diebstahl oder sonstiger Verlust");
        public static readonly SignatureCreationUnitDecommissioningType REV_ERROR = new SignatureCreationUnitDecommissioningType(2, true, "2", "Signatur- bzw. Siegelerstellung unmöglich oder fehlerhaft");
        public static readonly SignatureCreationUnitDecommissioningType REV_DIV = new SignatureCreationUnitDecommissioningType(3, true, "3", "Sonstiger Grund");

        public static readonly SignatureCreationUnitDecommissioningType INV_PLANNED = new SignatureCreationUnitDecommissioningType(6, false, "6", "Planmäßige Außerbetriebnahme");
        public static readonly SignatureCreationUnitDecommissioningType INV_BROKEN = new SignatureCreationUnitDecommissioningType(7, false, "7", "Außerbetriebnahme aufgrund eines irreparablen Ausfalls");

        private SignatureCreationUnitDecommissioningType(int id, bool isReversible, string fonString, string description) : base(id)
        {
            IsReversible = isReversible;
            FonString = fonString;
            Description = description;
        }

        public bool IsReversible { get; }

        public string FonString { get; }

        public string Description { get; }
    }
}