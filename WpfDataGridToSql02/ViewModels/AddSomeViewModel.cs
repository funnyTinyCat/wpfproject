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
    public class AddSomeViewModel : ViewModelBase
    {
        public DetailsFormViewModel DetailsFormViewModel { get; }

        public AddSomeViewModel(SomeStore someStore, ModalNavigationStore modalNavigationStore) 
        {
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore); 
            ICommand submitCommand = new AddSomeCommand(this, someStore, modalNavigationStore);

            DetailsFormViewModel = new DetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
