using System;
using System.IO;
using System.Windows.Forms;
using FormApplication.Contracts;
using FormApplication.Presenters;
using FormApplication.Services;
using FormApplication.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FormApplication
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IHostBuilder builder = new HostBuilder()
                .ConfigureHostConfiguration(configurationBuilder => configurationBuilder.AddEnvironmentVariables())
                .ConfigureAppConfiguration((hostContext, builder) =>
                {
                    var hostingEnv = hostContext.HostingEnvironment.EnvironmentName;

                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json", true);
                    builder.AddJsonFile($"appsettings.{hostingEnv}.json",true);
                    builder.AddEnvironmentVariables();
                    builder.AddCommandLine(args);
                })
                .ConfigureServices((_, services) =>
                {
                    services
                        .AddTransient<IMainPresenter, MainPresenter>()
                        .AddTransient<IUserPresenter, UserPresenter>()
                        .AddTransient<Func<IMainPresenter, IMainView>>(_ =>
                        {
                            return presenter => new MainForm(presenter);
                        })
                        .AddTransient<Func<IUserPresenter, IUserView>>(_ =>
                        {
                            return presenter => new UserView(presenter);
                        })
                        .AddTransient<Func<Type, IPresenter>>(provider =>
                        {
                            return type => (IPresenter) provider.GetRequiredService(type);
                        })
                        .AddScoped<IUserService, UserService>();

                    services.AddLogging();
                })
                .ConfigureLogging((_, configLogging) => { configLogging.AddConsole(); });

            IHost host = builder.Build();

            using (IServiceScope serviceScope = host.Services.CreateScope())
            {
                IServiceProvider serviceProvider = serviceScope.ServiceProvider;

                try
                {
                    var mainForm = serviceProvider.GetRequiredService<IMainPresenter>();
                    Application.Run(mainForm.View as MainForm);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
