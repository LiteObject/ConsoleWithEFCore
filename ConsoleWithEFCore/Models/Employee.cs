namespace ConsoleWithEFCore.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The employee.
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public PersonName Name { get; set; }

        /// <summary>
        /// Gets or sets the company id.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        public Company Company { get; set; }

        /// <summary>
        /// Gets or sets the skills.
        /// </summary>
        public virtual ICollection<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
    }
}