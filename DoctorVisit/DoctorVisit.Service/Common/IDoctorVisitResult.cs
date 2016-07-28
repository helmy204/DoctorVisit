using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorVisit.Service.Common
{
    /// <summary>
    /// Doctor Visit result interface
    /// </summary>
    public interface IDoctorVisitResult
    {
        /// <summary>
        /// Gets a value indicting whether request has been completed successfully
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Add error
        /// </summary>
        /// <param name="error">Error</param>
        void AddError(string error);

        /// <summary>
        /// Errors
        /// </summary>
        IList<string> Errors { get; }
    }
}
