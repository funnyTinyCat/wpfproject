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
    public class OpenAddSomeCommand : CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SomeStore _someStore;

        public OpenAddSomeCommand(SomeStore someStore, ModalNavigationStore modalNavigationStore)
        {
            _someStore = someStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override void Execute(object? parameter)
        {
            AddSomeViewModel addSomeViewModel = new AddSomeViewModel(_someStore, _modalNavigationStore);

            _modalNavigationStore.CurrentViewModel = addSomeViewModel;
        }
    }
}
