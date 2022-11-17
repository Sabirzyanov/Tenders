using Tenders.Core.Entities.Document;
using Tenders.Core.Enums;

namespace Tenders.Core.Entities.Documents;

public class GasSupplyDocument : BaseDocument
{
    public GasSupplyDocumentTypes Type { get; set; }
}