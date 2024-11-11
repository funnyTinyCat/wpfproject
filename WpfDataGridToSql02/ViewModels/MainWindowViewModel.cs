using System.Collections.ObjectModel;
using WpfDataGridToSql02.Data;
using Somes.Domain.Models;
using WpfDataGridToSql02.MVVM;

namespace WpfDataGridToSql02.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<User> Users { get; set; }

        public RelayCommand AddCommand => new RelayCommand(execute => AddUser());
        public RelayCommand DeleteCommand => new RelayCommand(execute => DeleteUser(), canExecute => SelectedUser != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());
        public MainWindowViewModel()
        {

            Users = new ObservableCollection<User>();
/*            Users.Add(new User
            {
                Username="Product1",
                CreatedByUserId=1,
                ModifiedByUserId=1
            });
            Users.Add(new User
            {
                Username = "Product2",
                CreatedByUserId = 1,
                ModifiedByUserId = 1
            });
*/

        }

        private User selectedUser;
        public  User SelectedUser
        {
            get { return selectedUser; }
            set 
            { 
                selectedUser = value; 
                OnPropertyChanged();
            }
        }

        private void AddUser()
        {
            Users.Add(new User
            {
                Username = "NEW ITEM",
                CreatedByUserId = 1,
                ModifiedByUserId = 1
            });
        }

        private void DeleteUser()
        {
            Users.Remove(SelectedUser);
        }

        private void Save()
        {
            // save to file/db
        }

        private bool CanSave() 
        {
            return true;
        }


    }
}
