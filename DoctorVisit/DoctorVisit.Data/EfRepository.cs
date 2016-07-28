using DoctorVisit.Core.Basis;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Data
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Insert(T entity)
        {
            try
            {
                if(entity==null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var message = string.Empty;

                foreach (var ValidationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var ValidationError in ValidationErrors.ValidationErrors)
                    {
                        message += string.Format("Property: {0} Error: {1}", ValidationError.PropertyName, ValidationError.ErrorMessage) + Environment.NewLine;
                    }
                }

                var fail = new Exception(message, dbEx);
                throw fail;
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        private IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

     

        #endregion Properties
    }

    public partial class EfDoctorVisitRepository<T> : EfRepository<T>, IDoctorVisitRepository<T> where T : BaseEntity
    {
        public EfDoctorVisitRepository(IDbDoctorVisitContext context)
            : base(context)
        {
        }
    }
}

