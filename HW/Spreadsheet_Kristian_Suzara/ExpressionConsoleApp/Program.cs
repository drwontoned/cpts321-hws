// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ExpressionConsoleApp
{
    using System;
    using global::CptS321;

    /// <summary>
    /// Console app class.
    /// </summary>
    public class Program
    {
        private static ExpressionTree tree = new ExpressionTree("A1+B1+C1");
        /// <summary>
        /// Console apps main method.
        /// </summary>
        /// <param name="args">
        /// string array args.
        /// </param>
        public static void Main(string[] args)
        {
            
            Menu();
            string input = string.Empty;
            while (input != "0")
            {
                input = Console.ReadLine();
                if (input == "1")
                {
                    InputOne();
                }
                else if (input == "2")
                {
                    InputTwo();
                }
                else if (input == "3")
                {
                    InputThree();
                }
                else
                {
                    InputFour();
                }
            }

        }

        /// <summary>
        /// Method for printing out the menu.
        /// </summary>
        public static void Menu()
        {
            Console.WriteLine(
                "\r\n" +
                "Menu (current exprssion = " + tree.Expression + ")\r\n" +
                "  1 = Enter a new expression\r\n" +
                "  2 = Set a variable value\r\n" +
                "  3 = Evaluate tree\r\n" +
                "  4 = Quit\r\n");
        }

        /// <summary>
        /// Method for entering a new exprsssion.
        /// </summary>
        public static void InputOne()
        {
            Console.WriteLine("Enter a new expression: ");
            string expression = Console.ReadLine();
            tree = new ExpressionTree(expression);
            Menu();
        }

        /// <summary>
        /// Method for setting a variable value.
        /// </summary>
        public static void InputTwo()
        {
            string variableName;
            string variableValue;
            double value;
            Console.WriteLine("Enter variable name: ");
            variableName = Console.ReadLine();
            Console.WriteLine("Enter variable value: ");
            variableValue = Console.ReadLine();
            value = Convert.ToDouble(variableValue);
            tree.SetVariable(variableName, value);
            Menu();
        }

        /// <summary>
        /// Method for evaluating the tree.
        /// </summary>
        public static void InputThree()
        {
            Console.WriteLine(tree.Evaluate() + "\r\n");
            Menu();
        }

        /// <summary>
        /// Method for quitting out of the console app.
        /// </summary>
        public static void InputFour()
        {
            Console.WriteLine("Done");
            Environment.Exit(0);
        }
    }
}
