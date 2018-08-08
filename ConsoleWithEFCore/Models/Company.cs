namespace ConsoleWithEFCore.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The company.
    /// </summary>
    public class Company : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public virtual List<Employee> Employees { get; set; }
    }
}
