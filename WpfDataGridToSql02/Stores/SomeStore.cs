using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Somes.Domain.Commands;
using Somes.Domain.Models;
using Somes.Domain.Queries;

namespace WpfDataGridToSql02.Stores
{
    public class SomeStore
    {
        private readonly IGetAllSomeQuery _getAllSomeQuery;
        private readonly ICreateSomeCommand _createSomeCommand;
        private readonly IUpdateSomeCommand _updateSomeCommand;
        private readonly IDeleteSomeCommand _deleteSomeCommand;
        private readonly List<Some> _somes;

        public IEnumerable<Some> Somes => _somes;

        public event Action SomesLoaded;
        public event Action<Some> SomeAdded;
        public event Action<Some> SomeUpdated;
        public event Action<Guid> SomeDeleted;

        public SomeStore(
            IGetAllSomeQuery getAllSomeQuery, 
            ICreateSomeCommand createSomeCommand,
            IUpdateSomeCommand updateSomeCommand,
            IDeleteSomeCommand deleteSomeCommand)
        {
            _getAllSomeQuery = getAllSomeQuery;
            _createSomeCommand = createSomeCommand;
            _updateSomeCommand = updateSomeCommand; 
            _deleteSomeCommand = deleteSomeCommand;  

            _somes = new List<Some>();
        }

        public async Task Load()
        {
            IEnumerable<Some> somes = await _getAllSomeQuery.Execute();

            _somes.Clear();
            _somes.AddRange(somes); 

            SomesLoaded?.Invoke();
        }

        public async Task Add(Some some)
        {
            await _createSomeCommand.Execute(some);

            _somes.Add(some);

            SomeAdded?.Invoke(some);
        }

        public async Task Update(Some some)
        {
            await _updateSomeCommand.Execute(some);

            int currentIndex = _somes.FindIndex(y =>  y.Id == some.Id);

            if (currentIndex != -1) 
            {
                _somes[currentIndex] = some;
            }
            else
            {
                _somes.Add(some);
            }

            SomeUpdated?.Invoke(some);
        }

        public async Task Delete(Guid id)
        {
            await _deleteSomeCommand.Execute(id); 

            _somes.RemoveAll(y => y.Id == id);

            SomeDeleted?.Invoke(id); 
        }
    }
}
