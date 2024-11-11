using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Models;
using WpfDataGridToSql02.Stores;

namespace WpfDataGridToSql02.ViewModels
{
    public class DetailsViewViewModel : ViewModelBase
    {
        private readonly SelectedSomeStore _selectedSomeStore;
        private Some SelectedSome => _selectedSomeStore.SelectedSome;

        // maybe take care of this later?
        public bool HasSelectedSome => SelectedSome != null;
        public string Username => SelectedSome?.Username ?? "Unknown";
        public string IsSubscribedDisplay => (SelectedSome?.IsSubscribed ?? false) ? "Yes" : "No";
        public string IsMemberDisplay => (SelectedSome?.IsMember ?? false) ? "Yes" : "No";

        public DetailsViewViewModel(SelectedSomeStore selectedSomeStore) 
        {

            _selectedSomeStore = selectedSomeStore;

            _selectedSomeStore.SelectedSomeChanged += SelectedSomeStore_SelectedSomeChanged;
        }

        protected override void Dispose()
        {
            _selectedSomeStore.SelectedSomeChanged -= SelectedSomeStore_SelectedSomeChanged; 

            base.Dispose(); 
        }

        private void SelectedSomeStore_SelectedSomeChanged() 
        {
            OnPropertyChanged(nameof(HasSelectedSome));
            OnPropertyChanged(nameof(Username));
            OnPropertyChanged(nameof(IsSubscribedDisplay));
            OnPropertyChanged(nameof(IsMemberDisplay));
        }

    }
}
