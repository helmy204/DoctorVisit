using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Common
{
    /// <summary>
    /// Doctor Visit result
    /// </summary>
    public class DoctorVisitResult : IDoctorVisitResult
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public DoctorVisitResult()
        {
            this.Errors = new List<string>();
        }

        /// <summary>
        /// Gets a value indicting whether request has been completed successfully
        /// </summary>
        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        /// <summary>
        /// Errors
        /// </summary>
        public IList<string> Errors { get; private set; }
    }
}
