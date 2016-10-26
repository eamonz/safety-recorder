namespace SafetyRecorder.Entities
{
    /// <summary>
    /// Represents an outcome of a safety observation
    /// </summary>
    public class Outcome : BaseEntity
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the safety observation identifier.
        /// </summary>
        public int SafetyObservationId { get; set; }

        /// <summary>
        /// Gets or sets the safety observation.
        /// </summary>
        public SafetyObservation SafetyObservation { get; set; }
    }
}