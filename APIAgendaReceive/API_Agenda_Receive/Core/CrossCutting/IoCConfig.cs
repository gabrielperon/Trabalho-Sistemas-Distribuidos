using Core.Application;
using Core.Application.Interface;
using Core.Data.Contracts;
using Core.Data.Repository;
using Core.Service;
using Core.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCutting
{
    public class IoCConfig  
    {
        public static void Config(IServiceCollection services)
        {
            services.AddTransient<IContatoService, ContatoService>();
            services.AddTransient<IContatoApp, ContatoApp>();
            services.AddTransient<IContatoRepositorio, ContatoRepositorio>();
        }
    }
}
