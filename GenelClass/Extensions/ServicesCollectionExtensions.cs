using GeneralClass.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralClass.Extensions
{
    public static class ServicesCollectionExtensions
    {
        //This yazarak neyi genişletmek istediğimizi seçtik. Parametre için This yazmadık
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection servicescollection, IGeneralClassModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(servicescollection);
            }
            return ServiceTool.Create(servicescollection);
        }
    }
}
