using AroundTheWorld.Application.Helpers.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public static class Configure
{
    public static void ConfigureApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(UserMapper));
        services.AddAutoMapper(typeof(TripMapper));
    }
}
