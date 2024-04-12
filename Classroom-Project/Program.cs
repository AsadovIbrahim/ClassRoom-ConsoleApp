using Classroom_Project.Enums;
using Classroom_Project.Exceptions;
using Classroom_Project.Models;
using static Classroom_Project.Functions.Function;

namespace Classroom_Project
{
    public class Program
    {
        static void Main(string[] args)
        {

            bool status = true;
            dynamic key;
            int choose = 0;
            Classroom students=null;
            while (status)
            {
                Console.Clear();
                Logo();

                if (choose == 0)
                {
                    Console.SetCursorPosition(50, 10);
                    SetConsoleColor("->CREATE CLASSROOM<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 10);
                    Console.WriteLine("CREATE CLASSROOM");
                }

                if (choose == 1)
                {
                    Console.SetCursorPosition(50, 11);
                    SetConsoleColor("->CREATE STUDENT<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 11);
                    Console.WriteLine("CREATE STUDENT");
                }

                if (choose == 2)
                {
                    Console.SetCursorPosition(50, 12);
                    SetConsoleColor("->SHOW ALL STUDENTS<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 12);
                    Console.WriteLine("SHOW ALL STUDENTS");
                }
                if (choose == 3)
                {
                    Console.SetCursorPosition(50, 13);
                    SetConsoleColor("->FIND STUDENT<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 13);
                    Console.WriteLine("FIND STUDENT");
                }
                if (choose == 4)
                {
                    Console.SetCursorPosition(50, 14);
                    SetConsoleColor("->REMOVE STUDENT<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 14);
                    Console.WriteLine("REMOVE STUDENT");
                }
                if (choose == 5)
                {
                    Console.SetCursorPosition(50, 15);
                    SetConsoleColor("->EXIT<-");

                }
                else
                {
                    Console.SetCursorPosition(50, 15);
                    Console.WriteLine("EXIT");
                }



                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (choose != 0) choose--;
                        else choose = 5;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choose != 5) choose++;
                        else choose = 0;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (choose == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Enter Class Name:");
                            string fullName = Console.ReadLine()!;

                            Console.Write("\nEnter Student Type (BackEnd, FrontEnd):");
                            TypeStudent typeStudent;
                            if (!Enum.TryParse(Console.ReadLine(), out typeStudent))
                            {
                                Console.WriteLine("Invalid student type!");
                                PressAnyKey();
                            }

                            try
                            {
                                students = new Classroom(fullName!, typeStudent);
                                Console.WriteLine("Classroom created successfully!");
                                PressAnyKey();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                PressAnyKey();
                            }
                        }
                        else if (choose == 1)
                        {
                            if (students == null) 
                            {
                                Console.WriteLine("Classroom has not been created yet!");
                                PressAnyKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Enter Student Name:");
                                string name = Console.ReadLine()!;
                                Console.WriteLine("Enter Student Surname:");
                                string surname = Console.ReadLine()!;
                                students.AddStudent(new Student(name, surname));
                                Console.WriteLine("Student Created Successfully...");
                                PressAnyKey();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if(choose == 2)
                        {
                            if (students == null) 
                            {
                                Console.WriteLine("Classroom has not been created yet!");
                                PressAnyKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                students.ShowAllStudents();
                                PressAnyKey();
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else if (choose == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Which Student Do You Want To Find?:");
                            int id=Convert.ToInt32(Console.ReadLine());
                            students.FindId(id);
                            PressAnyKey();
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                }
            }
        }
    }
}
