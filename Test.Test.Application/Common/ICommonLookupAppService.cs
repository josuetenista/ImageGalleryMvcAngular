using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Test.Test.Common.Dto;

namespace Test.Test.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<ComboboxItemDto>> GetEditionsForCombobox();

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        string GetDefaultEditionName();
    }
}