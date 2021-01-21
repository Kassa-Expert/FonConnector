using Enum.Ext;

namespace KassaExpert.FonConnector.Lib.Enum
{
    public sealed class SignatureCreationUnitDecommissioningType : TypeSafeEnum<SignatureCreationUnitDecommissioningType, int>
    {
        public static readonly SignatureCreationUnitDecommissioningType REV_LOST = new SignatureCreationUnitDecommissioningType(1, true, "Diebstahl oder sonstiger Verlust");
        public static readonly SignatureCreationUnitDecommissioningType REV_ERROR = new SignatureCreationUnitDecommissioningType(2, true, "Signatur- bzw. Siegelerstellung unmöglich oder fehlerhaft");
        public static readonly SignatureCreationUnitDecommissioningType REV_DIV = new SignatureCreationUnitDecommissioningType(3, true, "Sonstiger Grund");

        public static readonly SignatureCreationUnitDecommissioningType INV_PLANNED = new SignatureCreationUnitDecommissioningType(6, false, "Planmäßige Außerbetriebnahme");
        public static readonly SignatureCreationUnitDecommissioningType INV_BROKEN = new SignatureCreationUnitDecommissioningType(7, false, "Außerbetriebnahme aufgrund eines irreparablen Ausfalls");

        private SignatureCreationUnitDecommissioningType(int id, bool isReversible, string description) : base(id)
        {
            IsReversible = isReversible;
            Description = description;
        }

        public bool IsReversible { get; }

        public string Description { get; }
    }
}