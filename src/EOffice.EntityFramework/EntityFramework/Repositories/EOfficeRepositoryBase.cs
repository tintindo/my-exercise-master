using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace EOffice.EntityFramework.Repositories
{
    public abstract class EOfficeRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EOfficeDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EOfficeRepositoryBase(IDbContextProvider<EOfficeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EOfficeRepositoryBase<TEntity> : EOfficeRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected EOfficeRepositoryBase(IDbContextProvider<EOfficeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
