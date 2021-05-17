using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace GeneralClass.Utilities.IoC
{
    public interface IGeneralClassModule
    {
        void Load(IServiceCollection servicecollection);
    
    }
}
