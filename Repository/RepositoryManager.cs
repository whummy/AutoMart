using Contracts;
using Entities;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICarRepository _carRepository;
        private IBrandRepository _brandRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IBrandRepository Brand
        {
            get
            {
                if (_brandRepository == null)
                    _brandRepository = new BrandRepository(_repositoryContext);
                return _brandRepository;
            }
        }
        public ICarRepository Car
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_repositoryContext);
                return _carRepository;
            }
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
