namespace InheritanceLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("WHAT");

            string[] testFileLines = File.ReadAllLines("res/employees.txt");

            foreach (string line in testFileLines) {
                Console.WriteLine(line);
            }
            Console.ReadLine();
        }
    }
}
