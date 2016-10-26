namespace SafetyRecorder.Core.Migrations
{
    using System.Data.Entity.Migrations;
    using SafetyRecorder.Entities;

    /// <summary>
    /// Entity Framework configuration for the Safety Recorder db context
    /// </summary>
    /// <seealso cref="System.Data.Entity.Migrations.DbMigrationsConfiguration{SafetyRecorder.Core.SafetyRecorderDbContext}" />
    internal sealed class Configuration : DbMigrationsConfiguration<SafetyRecorder.Core.SafetyRecorderDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        /// <remarks>
        protected override void Seed(SafetyRecorder.Core.SafetyRecorderDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Persons.AddOrUpdate(x => x.Id,
                new Person { Id = 1, Name = "Eamon Gray" },
                new Person { Id = 2, Name = "Fernando Smith" },
                new Person { Id = 3, Name = "John Papadopolous" }                );
        }
    }
}
