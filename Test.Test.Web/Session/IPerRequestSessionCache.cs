using System.Threading.Tasks;
using Test.Test.Sessions.Dto;

namespace Test.Test.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
