using DoctorVisit.Core.Basis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Data
{
    public interface IDbContext
    {
        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Save changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }

    public interface IDbDoctorVisitContext : IDbContext { }

}
