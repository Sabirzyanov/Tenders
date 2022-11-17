using Tenders.Core.Entities.Document;
using Tenders.Core.Enums;

namespace Tenders.Core.Entities.Documents;

public class WaterSupplyDocument : BaseDocument
{
    public WaterSupplyDocumentType Type { get; set; }

}