using System.ComponentModel.DataAnnotations;

namespace Tenders.Core.Enums;

public enum GasSupplyDocumentTypes
{
    [Display(Name="Письмо-обращение на имя Президента")]
    LetterOfAppealToPresident,
    [Display(Name="Задача на проектирование")]
    ProjectionTask,
    [Display(Name="Акт обследования объекта")]
    ActResearchingObject,
    
    [Display(Name = "Ситуационный план")]
    SituationalPlan,
}