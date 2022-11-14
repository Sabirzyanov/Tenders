using System.ComponentModel.DataAnnotations;

namespace Tenders.Data;

public enum UserType
{
    [Display(Name="Заказчик")]
    Customer,
    [Display(Name="Проектировщик")]
    Architect,
    [Display(Name="Застройщик")]
    Builder,
}