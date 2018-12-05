namespace ConsoleWithEFCore.Models
{
    using System;

    /// <summary>
    /// The base entity.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the updated.
        /// </summary>
        public DateTime Updated { get; set; }
    }
}
