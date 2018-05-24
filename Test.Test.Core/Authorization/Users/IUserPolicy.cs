using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace Test.Test.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
