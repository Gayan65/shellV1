﻿using System.Runtime.CompilerServices;

namespace Shell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            do
            {
                
                Console.Write("$ ");
                string input = Console.ReadLine().ToUpper();
                string[] splitedInput = input.Split(' ');
                
                if (splitedInput.Count() > 1)
                {
                    if(splitedInput.Count() > 2)
                        Console.WriteLine("Invalid user input !");
                    else
                    {
                        string userInput = splitedInput[0];
                        string newDirectory = splitedInput[1];

                        while (!userInput.Equals("CD") && !Directory.Exists(newDirectory) && !input.Equals("LS") && !input.Equals("CLEAR") && !input.Equals("PWD") && !input.Equals("EXIT"))
                        {
                            Console.WriteLine("Invalid user input ! ");
                            Console.Write("$ ");
                            input = Console.ReadLine().ToUpper();
                            splitedInput = input.Split(' ');
                            if (splitedInput.Count() > 1)
                            {
                                userInput = splitedInput[0];
                                newDirectory = splitedInput[1];
                                if (userInput.Equals("CD"))
                                    ChangeDirectory(newDirectory);
                            }

                            
                        }
                        if (userInput.Equals("CD"))
                            ChangeDirectory(newDirectory);
                        else if (input.Equals("CLEAR"))
                            ConsoleClear();
                        else if (input.Equals("LS"))
                            ListDirectory();
                        else if (input.Equals("PWD"))
                            CurrentDirectory();
                        else if (input.Equals("EXIT"))
                            ExitFromConsole();
                        else
                            Console.WriteLine("Invalid user input !");
                    }

                    
                }
                else
                {
                    while (!input.Equals("LS") && !input.Equals("CLEAR") && !input.Equals("PWD") && !input.StartsWith("CD") && !input.Equals("EXIT"))
                    {
                        Console.WriteLine("Invalid user input ! ");
                        Console.Write("$ ");
                        input = Console.ReadLine().ToUpper();
                    }
                    
                    if (input.Equals("CLEAR"))
                        ConsoleClear();
                    else if (input.Equals("LS"))
                        ListDirectory();
                    else if (input.Equals("PWD"))
                        CurrentDirectory();
                    else if(input.Equals("EXIT"))
                        ExitFromConsole();
                    else
                    {
                        try
                        {
                            splitedInput = input.Split(' ');
                            string userInput = splitedInput[0];
                            string newDirectory = splitedInput[1];
                            if(userInput.Equals("CD"))
                                ChangeDirectory(newDirectory);
                            else
                                Console.WriteLine("Invalid user input ! ");
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Invalid user input ! ");
                        }
                    }
                }
 
            } while (true);
         }

        //CLEAR THE CONSOLE
        static void ConsoleClear()
        {
            Console.Clear();
        }

        //LIST DIRECTORY
        static void ListDirectory()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory());
            var directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
            foreach ( var directory in directories)
            {
                Console.WriteLine(directory);
            }
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }

        //CURRENT DIRECTORY
        static void CurrentDirectory()
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
        }

        //CHANGE DIRECTORY
        static void ChangeDirectory(string newDirectory)
        {
            try
            {
                Directory.SetCurrentDirectory(newDirectory);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        //EXIT FROM THE CONSOLE
        static void ExitFromConsole()
        {
            Environment.Exit(0);
        }
    }
}