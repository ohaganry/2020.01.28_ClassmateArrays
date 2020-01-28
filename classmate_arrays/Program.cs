using System;

namespace classmate_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            bool choice = true;
            bool repeat = true;
            int student = 1;
            string[] names = {"Andy Serkis", "Michael Fassbender", "Hugo Weaving", "Sir Patrick Stewart", "Sir Ian McKellen"};

            string[] hometown;
            hometown = new string[5];

            hometown[0] = "Middlesex, England";
            hometown[1] = "Heidelberg, Baden-Württemberg, West Germany";
            hometown[2] = "Ibadan, Nigeria";
            hometown[3] = "Mirfield, Yorkshire, England";
            hometown[4] = "Burnley, Lancashire, England";

            string[] projects;
            projects = new string[5];

            projects[0] = "LotR Trilogy, Hobbit Trilogy, Planet of the Apes films, Avengers: Age of Ultron, Black Panther";
            projects[1] = "300, (new) X-MEN films, Prometheus, Alien Covenant, Inglourious Basterds, MacBeth, 12 Years a Slave";
            projects[2] = "LotR Trilogy, Hobbit Trilogy, Matrix Trilogy, Captain America, V for Vendetta, The Wolfman";
            projects[3] = "Star Trek TNG, X-MEN films, Moby Dick, Star Trek: Picard, The Lion in Winter, A Christmas Carol";
            projects[4] = "LotR Trilogy, Hobbit Trilogy, X-MEN films, Othello, The Da Vinci Code, Beauty and the Beast";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to our stage acting class!"); 
            while(repeat)
            {
                Console.WriteLine("Class Directory:");
                Console.ResetColor();
                for(int i = 0; i < names.Length; i++)
                    {
                        Console.WriteLine($"{i+1}. {names[i]}");
                    }
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                student = CheckRange(int.Parse(GetUserInput("Which class member would you like to learn more about? (input 1-5)")), 1, 5);
                Console.WriteLine($"Student {student} is {names[student - 1]}.");

                while(choice)
                    {
                        string category = GetUserInput($"What would you like to know about {names[student-1]}? (hometown or overview)").ToLower();
                        switch(category)
                            {
                                case "hometown":
                                Console.WriteLine($"{names[student-1]} was born in {hometown[student-1]}.");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                choice = ValidateInput("Would you like to learn more? (y/n)");
                                Console.ResetColor();
                                break;

                                case "overview":
                                Console.WriteLine($"Here is an overview of {names[student-1]}'s filmography:");
                                Console.WriteLine(projects[student-1]);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                choice = ValidateInput("Would you like to learn more? (y/n)");
                                Console.ResetColor();
                                break;

                                default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("That data doesn't exist. Please enter hometown or overview");
                                Console.ResetColor();
                                break;
                            }
                    }
                    choice = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    repeat = ValidateInput("Would you like to learn about another student? (y/n)");
            }
           
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static bool ValidateInput(string message)
        {
            string usertInput = GetUserInput(message).ToLower();
            if(usertInput == "y")
            {
                Console.WriteLine("\n===================================");
                return true;
            }
            else if(usertInput == "n")
            {
                return false;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input");
                Console.ResetColor();
                return ValidateInput(message);
            }
        }

        public static int CheckRange(int number, int rangeLower, int rangeUpper)
        {
            if(number >= rangeLower && number <= rangeUpper)
            {
                return number;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Invalid Input. Input must be {rangeLower}-{rangeUpper}");
                Console.ResetColor();
                number = int.Parse(Console.ReadLine());
                return CheckRange(number, rangeLower, rangeUpper);
            }
        }
    }
}
