using KeyedService.Application.Features.DataSync;
using Microsoft.Extensions.DependencyInjection;

namespace KeyedService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddDataSyncProcessors(this IServiceCollection services)
    {        
        // it would be good to use nameof(EntityName) structure instead of string
        // but we have no entity object because of scope of this blog post goes to show keyed services
        services.AddKeyedScoped<IDataSyncProcessor, StudentDataSyncProcessor>("Student");
        services.AddKeyedScoped<IDataSyncProcessor, TeacherDataSyncProcessor>("Teacher");
        //services.AddKeyedScoped<IDataSyncProcessor, TeacherDataSyncProcessor>("Student");

        return services;
    }
}
