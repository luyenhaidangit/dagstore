using System;

namespace DAGStore.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        /// <summary>
        /// Interface that implement connection string
        /// </summary>

        DAGStoreDbContext Init();
    }
}