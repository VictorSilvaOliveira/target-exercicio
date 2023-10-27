using System.ComponentModel;

namespace Target.App
{
    public enum Status
    {
        [Description("Válido")]
        Valido,
        [Description("Cancelado")]
        Cancelado
    }
}