namespace ConsoleWithEFCore.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// The skill.
    /// </summary>
    public class Skill : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public virtual ICollection<EmployeeSkill> Employees { get; set; } = new List<EmployeeSkill>();
    }
}
