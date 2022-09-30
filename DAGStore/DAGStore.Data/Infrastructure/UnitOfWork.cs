namespace DAGStore.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Help insulate your application from changes in the data store and can facilitate automated unit testing or test-driven development
        /// </summary>

        private readonly IDbFactory dbFactory;
        private DAGStoreDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public DAGStoreDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
    }
}