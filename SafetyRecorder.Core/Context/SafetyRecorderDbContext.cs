﻿using SafetyRecorder.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SafetyRecorder.Core
{
    /// <summary>
    /// Entity Framework database context for the Safety Recorder
    /// </summary>
    /// <seealso cref="DbContext" />
    public class SafetyRecorderDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet representing the Person table.
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Outcomes table.
        /// </summary>
        public DbSet<Outcome> Outcomes { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Safety Observation table
        /// </summary>
        public DbSet<SafetyObservation> SafetyObservations { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Prevent table names from being pluralized
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Cascade delete the outcomes for a safety observation
            modelBuilder.Entity<Outcome>()
                .HasRequired(o => o.SafetyObservation)
                .WithMany(so => so.Outcomes)
                .HasForeignKey(w => w.SafetyObservationId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<SafetyObservation>().HasRequired(p => p.Observer)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SafetyObservation>().HasRequired(p => p.OtherParticipant)
                .WithRequiredDependent()
                .WillCascadeOnDelete(false);
        }
    }
}