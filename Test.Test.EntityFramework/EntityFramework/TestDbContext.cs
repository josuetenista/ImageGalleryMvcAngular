using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Test.Test.Authorization.Roles;
using Test.Test.Authorization.Users;
using Test.Test.Chat;
using Test.Test.Friendships;
using Test.Test.Images;
using Test.Test.MultiTenancy;
using Test.Test.Storage;

namespace Test.Test.EntityFramework
{
    /* Constructors of this DbContext is important and each one has it's own use case.
     * - Default constructor is used by EF tooling on design time.
     * - constructor(nameOrConnectionString) is used by ABP on runtime.
     * - constructor(existingConnection) is used by unit tests.
     * - constructor(existingConnection,contextOwnsConnection) can be used by ABP if DbContextEfTransactionStrategy is used.
     * See http://www.aspnetboilerplate.com/Pages/Documents/EntityFramework-Integration for more.
     */

    public class TestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */

        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }

        public virtual IDbSet<ChatMessage> ChatMessages { get; set; }
        public virtual IDbSet<Image> Images { get; set; }

        public TestDbContext()
            : base("Default")
        {
            
        }

        public TestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public TestDbContext(DbConnection existingConnection)
           : base(existingConnection, false)
        {

        }

        public TestDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
