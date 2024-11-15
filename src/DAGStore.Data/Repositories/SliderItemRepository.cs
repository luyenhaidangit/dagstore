using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface ISliderItemRepository : IRepository<SliderItem>
    {
    }

    public class SliderItemRepository : RepositoryBase<SliderItem>, ISliderItemRepository
    {
        public SliderItemRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
