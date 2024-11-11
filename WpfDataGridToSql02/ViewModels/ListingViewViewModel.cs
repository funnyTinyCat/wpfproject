using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDataGridToSql02.Commands;
using Somes.Domain.Models;
using WpfDataGridToSql02.Stores;
using System.Security.Cryptography.Xml;

namespace WpfDataGridToSql02.ViewModels
{
    public class ListingViewViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ListingItemViewViewModel> _listingItemViewViewModels;

        private readonly SelectedSomeStore _selectedSomeStore;

        private readonly ModalNavigationStore _modalNavigationStore;

        private readonly SomeStore _someStore;

        public IEnumerable<ListingItemViewViewModel> ListingItemViewViewModels => _listingItemViewViewModels;


        private ListingItemViewViewModel _selectedListingItemViewViewModel;

        public ListingItemViewViewModel SelectedListingItemViewViewModel
        {
            get
            {
                return _selectedListingItemViewViewModel;
            }
            set
            {
                _selectedListingItemViewViewModel = value;
                OnPropertyChanged(nameof(SelectedListingItemViewViewModel));

                _selectedSomeStore.SelectedSome = _selectedListingItemViewViewModel?.Some;
            }
        }

//        public ICommand LoadSomeCommand { get; }

        public ListingViewViewModel(
            SomeStore someStore, 
            SelectedSomeStore selectedSomeStore, 
            ModalNavigationStore modalNavigationStore)
        {
            _selectedSomeStore = selectedSomeStore;
            _listingItemViewViewModels = new ObservableCollection<ListingItemViewViewModel>();
            _someStore = someStore;
            _modalNavigationStore = modalNavigationStore;

//            LoadSomeCommand = new LoadSomeCommand(someStore);

            _someStore.SomesLoaded += SomeStore_SomesLoaded;
            _someStore.SomeAdded += SomeStore_SomeAdded;
            _someStore.SomeUpdated += SomeStore_SomeUpdated;
            _someStore.SomeDeleted += SomeStore_SomeDeleted;
        }

        //public static ListingViewViewModel LoadViewModel(
        //    SomeStore someStore,
        //    SelectedSomeStore selectedSomeStore,
        //    ModalNavigationStore modalNavigationStore)
        //{
        //    ListingViewViewModel listingViewModel = new ListingViewViewModel(someStore, selectedSomeStore, modalNavigationStore);

        //    listingViewModel.LoadSomeCommand.Execute(null);

        //    return listingViewModel; 
        //}

        protected override void Dispose()
        {
            _someStore.SomesLoaded -= SomeStore_SomesLoaded;
            _someStore.SomeAdded -= SomeStore_SomeAdded;
            _someStore.SomeUpdated -= SomeStore_SomeUpdated;
            _someStore.SomeDeleted -= SomeStore_SomeDeleted;

            base.Dispose();
        }

        private void SomeStore_SomesLoaded()
        {
            _listingItemViewViewModels.Clear();

            foreach(Some some in _someStore.Somes)
            {
                AddSome(some);
            }
        }

        private void SomeStore_SomeAdded(Some some)
        {
            AddSome(some);
        }

        private void SomeStore_SomeUpdated(Some some)
        {
            ListingItemViewViewModel someViewModel = _listingItemViewViewModels.FirstOrDefault(x => x.Some.Id == some.Id);

            if (someViewModel != null) {

                someViewModel.Update(some);
            }
        }

        private void SomeStore_SomeDeleted(Guid id)
        {
            ListingItemViewViewModel someViewModel = _listingItemViewViewModels.FirstOrDefault(y => y.Some?.Id == id);

            if (someViewModel != null)
            {
                _listingItemViewViewModels.Remove(someViewModel);
            }
        }

        private void AddSome(Some some)
        {
            ListingItemViewViewModel itemViewModel = new ListingItemViewViewModel(some, _someStore, _modalNavigationStore);

            _listingItemViewViewModels.Add(itemViewModel);
        }
    }
}
