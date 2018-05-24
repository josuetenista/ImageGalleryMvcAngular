using System.Threading.Tasks;
using Abp.Configuration;

namespace Test.Test.Timing
{
    public interface ITimeZoneService
    {
        Task<string> GetDefaultTimezoneAsync(SettingScopes scope, int? tenantId);
    }
}
