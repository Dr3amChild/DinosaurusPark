using System;

namespace DinosaursPark.DataAccess.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        protected BaseRepository(DinosaursContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DinosaursContext Context { get; }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}