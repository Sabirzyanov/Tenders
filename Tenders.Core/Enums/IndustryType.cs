using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tenders.Core.Enums;

[DefaultValue(Unspecified)]
public enum IndustryType
{
    [Display(Name="Водоснабжение")]
    WaterSupply,
    [Display(Name="Газоснабжение")]
    GasSupply,
    [Display(Name="Не задано")]
    Unspecified
}