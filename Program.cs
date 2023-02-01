// UsingEntityFramework, Martin Qvarnström SUT22
// Interacting with a database through Entity Framework
// Using repository and unit of work pattern
// Program.cs, where app runs and menu logic is handled

namespace UsingEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Controllers.MainController.RunMainMenu();
        }
    }
}