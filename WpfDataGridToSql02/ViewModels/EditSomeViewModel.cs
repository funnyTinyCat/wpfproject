using Microsoft.Web.WebView2.Core;
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
    public class EditSomeViewModel : ViewModelBase
    {
        public Guid SomeId { get; }
        public DetailsFormViewModel DetailsFormViewModel { get; }

        public EditSomeViewModel(Some some, SomeStore someStore, ModalNavigationStore modalNavigationStore)
        {
            SomeId = some.Id;

            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            ICommand submitCommand = new EditSomeCommand(this, someStore, modalNavigationStore);

            DetailsFormViewModel = new DetailsFormViewModel(submitCommand, cancelCommand)
            {
                Username = some.Username,
                IsSubscribed = some.IsSubscribed,
                IsMember = some.IsMember
            };
        }
    }
}
