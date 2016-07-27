using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Core.Basis
{
    /// <summary>
    /// Base Auditable Entities class
    /// </summary>
    public abstract partial class AuditableEntity : BaseEntity
    {
        /// <summary>
        /// System's entity creation date time.
        /// </summary>
        public DateTime InsertedOn { get; set; }

        /// <summary>
        /// Id for user who created the entity.
        /// </summary>
        public Nullable<int> InsertedBy { get; set; }

        /// <summary>
        /// System's entity update date time.
        /// </summary>
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        /// <summary>
        /// Id for user who updated the entity.
        /// </summary>
        public Nullable<int> UpdatedBy { get; set; }
    }
}
