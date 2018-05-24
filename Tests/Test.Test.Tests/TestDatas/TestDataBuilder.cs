using EntityFramework.DynamicFilters;
using Test.Test.EntityFramework;

namespace Test.Test.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly TestDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(TestDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();

            _context.SaveChanges();
        }
    }
}
