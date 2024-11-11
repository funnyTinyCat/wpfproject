using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Models;

namespace WpfDataGridToSql02.Stores
{
    public class SelectedSomeStore
    {
        private readonly SomeStore _someStore;
        private Some _selectedSome;

        public Some SelectedSome
        {
            get
            {
                return _selectedSome;
            }
            set 
            {
                _selectedSome = value;
                SelectedSomeChanged?.Invoke();
            }
        }

        public event Action SelectedSomeChanged;

        public SelectedSomeStore(SomeStore someStore)
        {
            _someStore = someStore;

            _someStore.SomeUpdated += SomeStore_SomeUpdated;
        }

        private void SomeStore_SomeUpdated(Some some)
        {
            if (some.Id == SelectedSome?.Id)
            {
                SelectedSome = some;
            }
        }
    }
}
