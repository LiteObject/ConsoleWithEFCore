namespace ConsoleWithEFCore
{
    using System;
    using System.Linq;

    using ConsoleWithEFCore.DataStore;
    using ConsoleWithEFCore.Services;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            using (var db = new EmployeeContext(true))
            {
                db.Database.EnsureCreated();
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.Read();
        }

        /// <summary>
        /// The print.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        private static void Print(string message) => Console.WriteLine(message);
    }
}
