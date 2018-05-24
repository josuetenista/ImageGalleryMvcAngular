using System.Threading.Tasks;
using Abp.Application.Services;
using Test.Test.Sessions.Dto;

namespace Test.Test.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
