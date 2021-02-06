// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW1
{
    using System;

    /// <summary>
    /// Main progam that takes user input and provides information about the tree.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method which will ask user for specified input, puts input into tree, and prints out tree info.
        /// </summary>
        /// <param name="args">
        /// args.
        /// </param>
        public static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree(); // initialize a tree.
            Console.WriteLine("Enter a collection in the range [0, 100], seperated by spaces"); // inform user of what to input and how to input.
            string input = Console.ReadLine();

            // for each string in the string array created by SplitString and the user input insert into tree.
            foreach (string s in tree.SplitString(input))
            {
                tree.Root = tree.Insert(tree.Root, Convert.ToInt32(s));
            }

            // print all of the tree info.
            Console.WriteLine("Sorted Order: " + tree.SortedOrder(tree.Root));
            Console.WriteLine("Number of Items: " + tree.Count(tree.Root));
            Console.WriteLine("Number of Levels: " + tree.Levels(tree.Root));
            Console.WriteLine("Minimum Levels: " + tree.MinLevels());
        }
    }
}
