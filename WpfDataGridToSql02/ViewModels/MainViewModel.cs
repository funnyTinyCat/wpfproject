using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDataGridToSql02.Stores;


namespace WpfDataGridToSql02.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public SomeViewViewModel SomeViewViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, SomeViewViewModel someViewViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            SomeViewViewModel = someViewViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;

            //_modalNavigationStore.CurrentViewModel = new AddSomeViewModel();
            //_modalNavigationStore.CurrentViewModel = new EditSomeViewModel();
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
