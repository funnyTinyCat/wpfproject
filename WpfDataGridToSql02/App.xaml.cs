using Microsoft.EntityFrameworkCore;
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

namespace WpfDataGridToSql02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SomeDbContextFactory _someDbContextFactory;
        private readonly IGetAllSomeQuery _getAllSomeQuery;
        private readonly ICreateSomeCommand _createSomeCommand;
        private readonly IUpdateSomeCommand _updateSomeCommand;
        private readonly IDeleteSomeCommand _deleteSomeCommand;
        private readonly SomeStore _someStore;
        private readonly SelectedSomeStore _selectedSomeStore;

        public App()
        {
            // sqlLite
            //            string _connectionString = "Data Source=YouTubeViewers.db";
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Zadatak;";

            _modalNavigationStore = new ModalNavigationStore();

            _someDbContextFactory = new SomeDbContextFactory(
                new DbContextOptionsBuilder().UseSqlServer(connectionString).Options);

            _getAllSomeQuery = new GetAllSomeQuery(_someDbContextFactory);
            _createSomeCommand = new CreateSomeCommand(_someDbContextFactory);
            _updateSomeCommand = new UpdateSomeCommand(_someDbContextFactory);
            _deleteSomeCommand = new DeleteSomeCommand(_someDbContextFactory);

            _someStore = new SomeStore(
                _getAllSomeQuery, 
                _createSomeCommand, 
                _updateSomeCommand, 
                _deleteSomeCommand);

            _selectedSomeStore = new SelectedSomeStore(_someStore);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            // automaticaly acomplish migrations:
            //using(SomeDbContext context = _someDbContextFactory.Create())
            //{
            //    context.Database.Migrate();
            //}

            SomeViewViewModel someViewViewModel = SomeViewViewModel.LoadViewModel(
                _someStore, 
                _selectedSomeStore, 
                _modalNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modalNavigationStore, someViewViewModel) 
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
