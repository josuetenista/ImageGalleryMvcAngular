using Abp.Application.Services;
using Test.Test.Dto;
using Test.Test.Logging.Dto;

namespace Test.Test.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
