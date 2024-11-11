using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Models;
using WpfDataGridToSql02.Stores;
using WpfDataGridToSql02.ViewModels;

namespace WpfDataGridToSql02.Commands
{
    public class AddSomeCommand : AsyncCommandBase
    {
        private readonly AddSomeViewModel _addSomeViewModel;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly SomeStore _someStore;

        public AddSomeCommand(
            AddSomeViewModel addSomeViewModel, 
            SomeStore someStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _addSomeViewModel = addSomeViewModel;
            _someStore = someStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            DetailsFormViewModel detailsFormViewModel = _addSomeViewModel.DetailsFormViewModel;

            detailsFormViewModel.ErrorMessage = null;
            detailsFormViewModel.IsSubmitting = true;

            Some some = new Some(
                Guid.NewGuid(), 
                detailsFormViewModel.Username, 
                detailsFormViewModel.IsSubscribed, 
                detailsFormViewModel.IsMember);

            try
            {
                // add youtube viewer to the database
                await _someStore.Add(some);

                _modalNavigationStore.Close();
            } catch (Exception) 
            {
                detailsFormViewModel.ErrorMessage = "Failed to add YouTube viewer. Please try again later.";
             }
            finally
            {
                detailsFormViewModel.IsSubmitting = false;
            }


        }
    }
}
