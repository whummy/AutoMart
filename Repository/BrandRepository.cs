using Contracts;
using Entities;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PagedList<Brand>> GetAllBrandsAsync(BrandParameters brandParameters, bool trackChanges)
        {
            var brands = await FindAll(trackChanges)
                .Search(brandParameters.Search)
                .Sort(brandParameters.OrderBy)
                .ToListAsync();
                
             return PagedList<Brand>
            .ToPagedList(brands, brandParameters.PageNumber, brandParameters.PageSize);
        }

        public async Task<Brand> GetBrandAsync(Guid brandId, bool trackChanges) =>
             await FindByCondition(b => b.Id.Equals(brandId), trackChanges)
             .SingleOrDefaultAsync();
        public void CreateBrand( Brand brand)
        {
           
            Create(brand);
        }            
           
        public async Task<IEnumerable<Brand>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
          await FindByCondition(x => ids.Contains(x.Id), trackChanges)
          .ToListAsync();
        public void DeleteBrand(Brand brand)
        {
            Delete(brand);
        }

    }
}
