using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Test.Test.Auditing.Dto;
using Test.Test.Dto;

namespace Test.Test.Auditing
{
    public interface IAuditLogAppService : IApplicationService
    {
        Task<PagedResultDto<AuditLogListDto>> GetAuditLogs(GetAuditLogsInput input);

        Task<FileDto> GetAuditLogsToExcel(GetAuditLogsInput input);
    }
}