using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDataGridToSql02.Stores;
using WpfDataGridToSql02.ViewModels;

namespace WpfDataGridToSql02.Commands
{
    public class LoadSomeCommand : AsyncCommandBase
    {
        private readonly SomeStore _someStore;
        private readonly SomeViewViewModel _someViewModel;

        // SomeViewViewModel someViewModel,
        public LoadSomeCommand(SomeViewViewModel someViewModel, SomeStore someStore)
        {
            _someViewModel = someViewModel;
            _someStore = someStore;
        }

        public override async Task ExecuteAsync(object? parameter)         
        {
            _someViewModel.ErrorMessage = null;
            _someViewModel.IsLoading = true;

            try
            {
                await _someStore.Load();
            } 
            catch (Exception) 
            {
                _someViewModel.ErrorMessage = "Failed to load YouTube viewers. Please restart the application.";
                throw;
            }
            finally 
            {
                _someViewModel.IsLoading = false;
            }
        }
    }
}
