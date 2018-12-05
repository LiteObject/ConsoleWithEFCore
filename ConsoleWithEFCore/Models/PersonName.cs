namespace ConsoleWithEFCore.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The person name.
    /// </summary>
    public class PersonName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonName"/> class.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        public PersonName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="PersonName"/> class from being created.
        /// Only reflection will see this. EF Core needs it.
        /// </summary>
        private PersonName()
        {
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The full name.
        /// </summary>
        public string FullName => $"{this.FirstName} {this.LastName}";

        /// <summary>
        /// The full name reverse.
        /// </summary>
        public string FullNameReverse => $"{this.LastName}, {this.FirstName}";

        /// <summary>
        /// The ==.
        /// </summary>
        /// <param name="name1">
        /// The name 1.
        /// </param>
        /// <param name="name2">
        /// The name 2.
        /// </param>
        /// <returns>
        /// The boolean value.
        /// </returns>
        public static bool operator ==(PersonName name1, PersonName name2)
        {
            return EqualityComparer<PersonName>.Default.Equals(name1, name2);
        }

        /// <summary>
        /// The !=.
        /// </summary>
        /// <param name="name1">
        /// The name 1.
        /// </param>
        /// <param name="name2">
        /// The name 2.
        /// </param>
        /// <returns>
        /// The boolean value.
        /// </returns>
        public static bool operator !=(PersonName name1, PersonName name2)
        {
            return !(name1 == name2);
        }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            var name = obj as PersonName;
            return name != null && this.FirstName == name.FirstName && this.LastName == name.LastName;
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.FirstName, this.LastName);
        }
    }
}
