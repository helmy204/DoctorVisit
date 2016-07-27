using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Core.Basis
{
    /// <summary>
    /// Base class for all entities
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>
        /// Gets or sets entity id
        /// </summary>
        public int Id { get; set; }
    }
}
