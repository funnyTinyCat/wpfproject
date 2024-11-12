using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Somes.Domain.Commands;
using Somes.Domain.Queries;
using Somes.EntityFramework;
using Somes.EntityFramework.Commands;
using Somes.EntityFramework.Queries;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfDataGridToSql02.Stores;
using WpfDataGridToSql02.ViewModels;
using WpfDataGridToSql02.HostBuilders;

namespace WpfDataGridToSql02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {
                    //                    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Zadatak;";

                    services.AddSingleton<IGetAllSomeQuery, GetAllSomeQuery>();
                    services.AddSingleton<ICreateSomeCommand, CreateSomeCommand>();
                    services.AddSingleton<IUpdateSomeCommand, UpdateSomeCommand>();
                    services.AddSingleton<IDeleteSomeCommand, DeleteSomeCommand>(); 

                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<SomeStore>();
                    services.AddSingleton<SelectedSomeStore>();

                    services.AddSingleton<MainViewModel>();
                    services.AddTransient<SomeViewViewModel>(CreateSomeViewModel );


                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })

                .Build();

            // sqlLite
            //            string _connectionString = "Data Source=YouTubeViewers.db";

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();


            // automaticaly acomplish migrations:
            // SomeDbContextFactory  someDbContextFactory = _host.Services.GetRequiredService<SomeDbContextFactory>();
            //using(SomeDbContext context = someDbContextFactory.Create())
            //{
            //    context.Database.Migrate();
            //}

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private SomeViewViewModel CreateSomeViewModel(IServiceProvider services)
        {
            return SomeViewViewModel.LoadViewModel(
                services.GetRequiredService<SomeStore>(),
                services.GetRequiredService<SelectedSomeStore>(),
                services.GetRequiredService<ModalNavigationStore>());
        }

    }

}
