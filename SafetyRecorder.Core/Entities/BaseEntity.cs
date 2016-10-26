
using System;
using System.ComponentModel.DataAnnotations;

namespace SafetyRecorder.Entities
{
    /// <summary>
    /// Base entity for the system
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// The changed by username
        /// </summary>
        private string changedBy = "System";

        /// <summary>
        /// The changed on date/time
        /// </summary>
        private DateTime changedOn = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the changed by.
        /// </summary>
        [Required]
        [StringLength(200)]
        public string ChangedBy
        {
            get
            {
                return this.changedBy;
            }
            set
            {
                this.changedBy = value;
            }
        }

        /// <summary>
        /// Gets or sets the changed on.
        /// </summary>
        public DateTime ChangedOn
        {
            get
            {
                return this.changedOn;
            }
            set
            {
                this.changedOn = value;
            }
        }
    }
}
