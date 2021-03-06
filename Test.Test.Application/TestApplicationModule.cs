﻿using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Test.Test.Authorization;

namespace Test.Test
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(typeof(TestCoreModule))]
    public class TestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper mappings
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                CustomDtoMapper.CreateMappings(mapper);
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
