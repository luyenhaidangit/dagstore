namespace DAGStore.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private DAGStoreDbContext dbContext;

        public DAGStoreDbContext Init()
        {
            return dbContext ?? (dbContext = new DAGStoreDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}