using Microsoft.Extensions.DependencyInjection;
using Scheduling.Lib.Rules;

namespace Scheduling.Lib.ServiceConfiguration
{
    /// <summary>
    ///  The DI Services configurations
    /// </summary>
    public static class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<ISchedularService, SchedularService>();
            services.AddSingleton<IEmployeeService, DummyEmployeeService>();
            services.AddSingleton<IValidationRuleConfigurator, ValidationRuleConfigurator>();
            services.AddSingleton<IDateService, DateService>();
        }
    }
}
