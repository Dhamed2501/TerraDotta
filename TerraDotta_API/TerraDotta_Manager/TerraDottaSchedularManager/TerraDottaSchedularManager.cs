using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraDotta_Repository.TerraDottaSchedularRepository;

namespace TerraDotta_Manager.TerraDottaSchedularManager
{
    public class TerraDottaSchedularManager : ITerraDottaSchedularManager
    {
        private ITerraDottaSchedularRepository _terradottaschedularrepository;
        public TerraDottaSchedularManager(ITerraDottaSchedularRepository terradottaschedularrepository)
        {
            this._terradottaschedularrepository = terradottaschedularrepository;
        }
        public string Test()
        {
            return _terradottaschedularrepository.Test();
        }
    }
}
