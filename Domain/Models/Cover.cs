using System.ComponentModel;

namespace Domain.Models
{
    public enum Cover
    {
        [Description("Surgery")]
        Surgery = 1,
        [Description("Dental")]
        Dental = 2,
        [Description("Hospitalization")]
        Hospitalization = 3,
    }
}