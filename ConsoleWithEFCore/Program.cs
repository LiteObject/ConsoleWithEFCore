namespace ConsoleWithEFCore
{
    using System;
    using System.Diagnostics;

    using ConsoleWithEFCore.DataStore;

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
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            using (var db = new EmployeeContext())
            {
                db.Database.EnsureCreated();
                db.ChangeTracker.DetectChanges();                
            }

            stopWatch.Stop();
            Console.WriteLine($"\nPress any key to exit. Elapsed: {stopWatch.Elapsed} s.");
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
