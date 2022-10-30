using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAGStore.Data.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        List<Brand> GetAllBrand();
    }

    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public List<Brand> GetAllBrand()
        {
            return DbContext.Database.SqlQuery<Brand>("SelectAllBrand").ToList();
        }
    }
}
