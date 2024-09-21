using StepanovAlexandrKt_41_21.Interfaces.StudentsInterfaces;

namespace StepanovAlexandrKt_41_21.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
