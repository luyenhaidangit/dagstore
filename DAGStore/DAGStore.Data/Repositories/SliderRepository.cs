using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface ISliderRepository : IRepository<Slider>
    {
    }

    public class SliderRepository : RepositoryBase<Slider>, ISliderRepository
    {
        public SliderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
