using System;

namespace DAGStore.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        /// <summary>
        ///  Primarily for releasing unmanaged resources
        ///  Implement IDisposable when call Dispose
        ///  Document: https://github.com/AliakseiFutryn/dotnet-design-patterns-samples/tree/master/Behavioral/Dispose
        /// </summary>

        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }
}