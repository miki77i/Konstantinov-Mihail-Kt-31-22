using KonstantinovMihailKt_31_22.Interfaces.CafedraInterfase;

namespace KonstantinovMihailKt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICafedraService, CafedraService>();
            services.AddScoped<INagruzkaService, NagruzkaService>();

            return services;
        }

    }
}
