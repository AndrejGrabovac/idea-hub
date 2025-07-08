using IdeaHub.Data;
using IdeaHub.Services;
using IdeaHub.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace IdeaHub
{
    internal static class Program
    {   
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataSeeder.Seed();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();

            Application.Run(new Helpers.AppContext(ServiceProvider));
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ISuggestionService, SuggestionService>();
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
