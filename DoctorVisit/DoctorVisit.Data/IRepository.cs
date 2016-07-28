using DoctorVisit.Core.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Data
{
    /// <summary>
    /// Repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }
    }

    public partial interface IDoctorVisitRepository<T> : IRepository<T> where T : BaseEntity { }
}
