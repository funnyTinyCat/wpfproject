using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDataGridToSql02.Commands;
using Somes.Domain.Models;
using WpfDataGridToSql02.Stores;

namespace WpfDataGridToSql02.ViewModels
{
    public class ListingItemViewViewModel : ViewModelBase
    {
        public Some Some { get; private set; }
        public string Username => Some.Username;

        private bool _isDeleting;
        public bool IsDeleting
        {
            get 
            {  
                return _isDeleting;
            }
            set 
            { 
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
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

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ListingItemViewViewModel(Some some, SomeStore someStore, ModalNavigationStore modalNavigationStore)
        { 
            Some = some;

            EditCommand = new OpenEditSomeCommand(this, someStore, modalNavigationStore);
            DeleteCommand = new DeleteSomeCommand(this, someStore);
        }
         
        public void Update(Some some)
        {
            Some = some;

            OnPropertyChanged(nameof(Username));
        }


    }
}
