using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Test.Test.EntityFramework;

namespace Test.Test.Migrator
{
    [DependsOn(typeof(TestDataModule))]
    public class TestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<TestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}