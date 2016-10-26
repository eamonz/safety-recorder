using System;
using System.Collections.Generic;

namespace SafetyRecorder.Entities
{
    /// <summary>
    /// Represents a safety observation captured by employees
    /// </summary>
    public class SafetyObservation : BaseEntity
    {
        /// <summary>
        /// Gets or sets the observer identifier.
        /// </summary>
        public int ObserverId { get; set; }

        /// <summary>
        /// Gets or sets the observer.
        /// </summary>
        public Person Observer { get; set; }

        /// <summary>
        /// Gets or sets the observed on.
        /// </summary>
        public DateTime ObservedOn { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the other participant identifier.
        /// </summary>
        public int OtherParticipantId { get; set; }

        /// <summary>
        /// Gets or sets the other participant.
        /// </summary>
        public Person OtherParticipant { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the outcomes.
        /// </summary>
        public IList<Outcome> Outcomes { get; set; }
    }
}