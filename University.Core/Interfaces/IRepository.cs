using System;
using System.Collections.Generic;
using System.Text;
using University.Core.Interfaces;

namespace University.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }

}
