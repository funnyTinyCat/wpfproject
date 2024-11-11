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
    public class EditSomeCommand : AsyncCommandBase
    {
        private readonly EditSomeViewModel _editSomeViewModel;
        private readonly SomeStore _someStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditSomeCommand(
            EditSomeViewModel editSomeViewModel, 
            SomeStore someStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _editSomeViewModel = editSomeViewModel;
            _someStore = someStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            DetailsFormViewModel detailsFormViewModel = _editSomeViewModel.DetailsFormViewModel;

            detailsFormViewModel.ErrorMessage = null;
            detailsFormViewModel.IsSubmitting = true;

            Some some = new Some(
                _editSomeViewModel.SomeId,
                detailsFormViewModel.Username,
                detailsFormViewModel.IsSubscribed,
                detailsFormViewModel.IsMember);

            try
            {
                // add youtube viewer to the database
                await _someStore.Update(some);

                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                detailsFormViewModel.ErrorMessage = "Failed to update YouTube viewer. Please try again later.";
            }
            finally
            {
                detailsFormViewModel.IsSubmitting = false;
            }

        }
    }
}
