namespace DAGStore.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Interface help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development
        /// </summary>

        void Commit();
    }
}