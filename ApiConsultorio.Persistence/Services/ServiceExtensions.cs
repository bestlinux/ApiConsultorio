using ApiConsultorio.Domain.Interfaces;
using ApiConsultorio.Persistence.Context;
using ApiConsultorio.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsultorio.Persistence.Services
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistenceApp(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                     options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ApiConsultorio")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IMangaRepository, MangaRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();

        }
    }
}
