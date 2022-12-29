using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface ISuggestProductRepository : IRepository<SuggestProduct>
    {
    }

    public class SuggestProductRepository : RepositoryBase<SuggestProduct>, ISuggestProductRepository
    {
        public SuggestProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //public bool DeleteSuggestProduct(int idSuggest,int idProduct)
        //{

        //}
    }
}
