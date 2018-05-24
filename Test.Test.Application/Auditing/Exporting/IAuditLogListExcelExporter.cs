using System.Collections.Generic;
using Test.Test.Auditing.Dto;
using Test.Test.Dto;

namespace Test.Test.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
