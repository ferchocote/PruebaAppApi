using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using PruebaAppApi.DataAccess.Entities;
using PruebaAppApi.DataAccess.DataAccess;
using AplicationServices.ScopeService;
using AplicationServices.Application.Contracts.Category;
using AplicationServices.Application.Category;
using DomainServices.Domain.Contracts.Category;
using DomainServices.Domain.Category;
using AplicationServices.Application.Contracts.Product;
using AplicationServices.Application.Product;
using DomainServices.Domain.Product;
using DomainServices.Domain.Contracts.Product;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.Helpers.Logger;


namespace PruebaAppApi.DI
{
    /// <summary>
    /// Provee la carga de los perfiles de inyección de dependencias
    /// de toda la solución
    /// </summary>
    public static class DependencyInjectionProfile
    {
        public static void RegisterProfile(IServiceCollection services, IConfiguration configuration)
        {
            #region Context

            CustomDbSettings val = new CustomDbSettings();


            services.AddDbContextFactory<PruebaTiendaContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            #endregion Context

            #region Application

            services.AddTransient<ICategoryServices, CategoryAppServices>();
            services.AddTransient<IProductServices, ProductAppServices>();


            #endregion

            #region Domain

            services.AddTransient<ICategoryDomain, CategoryDomain>();
            services.AddTransient<IProductDomain, ProductDomain>();

            #endregion Domain

            #region Others
            services.AddTransient<IServiceScopeDI, ServiceScope>();
            services.AddTransient<IServiceProvider, ServiceProvider>();
            //services.AddTransient<ILoggerServices, LoggerService>();
            #endregion
        }

    }
}
