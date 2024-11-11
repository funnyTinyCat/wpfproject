using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDataGridToSql02.Commands;
using WpfDataGridToSql02.Stores;

namespace WpfDataGridToSql02.ViewModels
{
    public class SomeViewViewModel : ViewModelBase
    {
        public ListingViewViewModel ListingViewViewModel { get; }
        public DetailsViewViewModel DetailsViewViewModel { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set 
            { 
                _isLoading = value; 
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand LoadSomeCommand { get; }
        public ICommand AddSomeCommand { get; }
        
        public SomeViewViewModel(
            SomeStore someStore, 
            SelectedSomeStore selectedSomeStore, 
            ModalNavigationStore modalNavigationStore)
        {
            ListingViewViewModel = new ListingViewViewModel(someStore, selectedSomeStore, modalNavigationStore);
            DetailsViewViewModel = new DetailsViewViewModel(selectedSomeStore);

            LoadSomeCommand = new LoadSomeCommand(this, someStore);
            AddSomeCommand = new OpenAddSomeCommand(someStore, modalNavigationStore);
        }

        public static SomeViewViewModel LoadViewModel(
                    SomeStore someStore,
                    SelectedSomeStore selectedSomeStore,
                    ModalNavigationStore modalNavigationStore)
        {
            SomeViewViewModel someViewModel = new SomeViewViewModel(someStore, selectedSomeStore, modalNavigationStore);

            someViewModel.LoadSomeCommand.Execute(null);

            return someViewModel;
        }

        private string _errorMessage;
        public string ErrorMessage 
        { 
            get { return _errorMessage; }
                        
            set 
            { 
                _errorMessage = value; 
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        
    }
}
