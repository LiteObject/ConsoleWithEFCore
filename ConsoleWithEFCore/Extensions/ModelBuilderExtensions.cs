namespace ConsoleWithEFCore.Extensions
{
    using ConsoleWithEFCore.Models;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The model builder extensions.
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Company One" },
                new Company { Id = 2, Name = "Company Two" });

            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "Skill One" },
                new Skill { Id = 2, Name = "Skill Two" });

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "EmployeeOne", CompanyId = 1 },
                new Employee { Id = 2, Name = "EmployeeTwo", CompanyId = 2 },
                new Employee { Id = 3, Name = "EmployeeThree", CompanyId = 2 });

            modelBuilder.Entity<EmployeeSkill>().HasData(
                new EmployeeSkill { Id = 1, EmployeeId = 1, SkillId = 1 },
                new EmployeeSkill { Id = 2, EmployeeId = 1, SkillId = 2 },
                new EmployeeSkill { Id = 3, EmployeeId = 2, SkillId = 2 },
                new EmployeeSkill { Id = 4, EmployeeId = 3, SkillId = 1 });
        }
    }
}

