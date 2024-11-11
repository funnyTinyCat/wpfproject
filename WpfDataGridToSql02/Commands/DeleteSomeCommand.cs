using Somes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridToSql02.Stores;
using WpfDataGridToSql02.ViewModels;

namespace WpfDataGridToSql02.Commands
{
    public class DeleteSomeCommand : AsyncCommandBase
    {

        private readonly ListingItemViewViewModel _listingItemViewViewModel;
        private readonly SomeStore _someStore;

        public DeleteSomeCommand(
            ListingItemViewViewModel listingItemViewViewModel,
            SomeStore someStore)
        {
            _listingItemViewViewModel = listingItemViewViewModel;
            _someStore = someStore;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            _listingItemViewViewModel.ErrorMessage = null;
            _listingItemViewViewModel.IsDeleting = true;

            Some some = _listingItemViewViewModel.Some;

            try
            {
                await _someStore.Delete(some.Id);
            }
            catch (Exception) 
            {
                _listingItemViewViewModel.ErrorMessage = "Failed to delete YouTube viewer. Please try again later.";
            }
            finally
            {
                _listingItemViewViewModel.IsDeleting = false; 
            }

        }
    }
}
