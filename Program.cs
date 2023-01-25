namespace UsingEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to school!\n\nMenu:");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. List all students in a certain class");
            Console.WriteLine("3. Add new staff");
            Console.WriteLine("4. List staff");
            Console.WriteLine("5. List grades set in the last month");
            Console.WriteLine("6. List grade statistics from all courses");
            Console.WriteLine("7. Add new student");
            Console.WriteLine("8. Exit");

            int menuInput;
            bool parseSuccess;
            do
            {
                Console.Write("\nEnter a valid number: ");
                parseSuccess = int.TryParse(Console.ReadLine(), out menuInput);
            } while (!parseSuccess || menuInput < 1 || menuInput > 8);
        }
    }
}