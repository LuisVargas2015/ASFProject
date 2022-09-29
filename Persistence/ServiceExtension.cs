using Application.Interfaces;

using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;


namespace Persistence
{
    public static class ServiceExtension
    {
        public static void AddInfraestructurePersistence(this IServiceCollection service)
        {
            service.AddTransient(typeof(IEmployeeRepository), typeof(EmployeeRepository));
         
            

        }
    }
}
