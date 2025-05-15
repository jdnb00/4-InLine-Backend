using IntranetProxy.Domain.Nucleo.DocumentosLaborales;
using IntranetProxy.Domain.Nucleo.Empleadas;
using IntranetProxy.Domain.Nucleo.Horarios;
using IntranetProxy.Domain.Nucleo.Tiendas;
using IntranetProxy.Domain.Nucleo.Zonas;
using IntranetProxy.Domain.Nucleo.Mensajeria;
using IntranetProxy.Infrastructure.Nucleo;
using IntranetProxy.Infrastructure.NucleoConnection;
using Microsoft.Data.SqlClient;
using System.Data;
using IntranetProxy.Domain.Rrhh.DocumentosLaborales;
using IntranetProxy.Infrastructure.Rrhhv5Connection;
using IntranetProxy.Domain.Labor.Usuarios;
using IntranetProxy.Infrastructure.LaborConnection;
using System.Diagnostics.CodeAnalysis;
using IntranetProxy.Domain.Navision.Mensajeria;
using IntranetProxy.Infrastructure.NavisionConnection;
using IntranetProxy.Domain.Rrhh.Usuarios;
using _4_InLine_Backend.Domain.Interfaces;
using _4_InLine_Backend.Infrastructure.Repositories;

namespace _4_InLine_Backend.Host.Extensions
{
  [ExcludeFromCodeCoverage]
  public static class InfrastructureExtensions
  {
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
      services
        .AddScoped<IJuegoRepository, JuegoRepository>()
      
      ;
  }
}

