using FluentAssertions.Common;
using GeneralClass.Caching.Microsoft;
using GeneralClass.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.DependencyResolvers
{
    public class GeneralClassModule : IGeneralClassModule
    {
        public void Load(IServiceCollection servicecollection)
        {
            servicecollection.AddMemoryCache();
            servicecollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            servicecollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            servicecollection.AddSingleton<Stopwatch>();
        }
    }
}
