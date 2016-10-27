using System;
using System.Collections.Generic;

namespace SafetyRecorder.Web.Models
{
    /// <summary>
    /// Model representing a view of a safety observation
    /// </summary>
    public class SafetyObservationViewModel
    {
        /// <summary>
        /// Gets or sets the observer.
        /// </summary>
        public string Observer { get; set; }

        /// <summary>
        /// Gets or sets the observed on.
        /// </summary>
        public DateTime ObservedOn { get; set; }

        /// <summary>
        /// Gets or sets the colleague.
        /// </summary>
        public string Colleague { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the outcomes.
        /// </summary>
        public IList<string> Outcomes { get; set; }
    }
}
