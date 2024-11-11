using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Somes.Domain.Models;
using WpfDataGridToSql02.Stores;
using WpfDataGridToSql02.ViewModels;

namespace WpfDataGridToSql02.Commands
{
    public class OpenEditSomeCommand : CommandBase
    {

        private readonly ListingItemViewViewModel _listingItemViewViewModel;
        private readonly SomeStore _someStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditSomeCommand(ListingItemViewViewModel listingItemViewViewModel, 
            SomeStore someStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _listingItemViewViewModel = listingItemViewViewModel;
            _someStore = someStore;
            _modalNavigationStore = modalNavigationStore;

        }

        public event EventHandler? CanExecuteChanged;


        public override void Execute(object? parameter)
        {
            Some some = _listingItemViewViewModel.Some;

            EditSomeViewModel editSomeViewModel = new EditSomeViewModel(some, _someStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = editSomeViewModel;
        }
    }
}
