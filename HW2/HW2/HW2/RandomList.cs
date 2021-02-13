// <copyright file="RandomList.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that has a list of random integers and can get the number of unique integers through 3 different methods.
    /// </summary>
    public class RandomList
    {
        private readonly List<int> list = new List<int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomList"/> class and fills
        /// a list with 10,000 random integers from 0 - 20,000.
        /// </summary>
        public RandomList()
        {
            Random num = new Random();

            // loop to add 10,000 integers into list
            for (int i = 1; i < 10000; i++)
            {
                this.list.Add(num.Next(0, 20000)); // add to list random integer from 0 - 20,000
            }
        }

        /// <summary>
        /// Getter method for the RandomList that was generated.
        /// </summary>
        /// <returns>
        /// The list of 10000 random integers from 0 - 20,000.
        /// </returns>
        public List<int> GetList()
        {
            return this.list;
        }

        /// <summary>
        /// Gets number of unique values from a list using a HashSet.
        /// </summary>
        /// <param name="list">
        /// The list of integers to try and get the number of unique values from.
        /// </param>
        /// <returns>
        /// The number of unique values from list.
        /// </returns>
        public int HashSetUnique(List<int> list)
        {
            HashSet<int> condensed = new HashSet<int>(list); // puts all values from list into hashset
            return condensed.Count; // return size of hashset
        }

        /// <summary>
        /// Gets number of unique values from a list without altering the list and keeoing storage complexity O(1).
        /// </summary>
        /// <param name="list">
        /// The list of integers to try and get the number of unique values from.
        /// </param>
        /// <returns>
        /// The number of unique values from list.
        /// </returns>
        public int O1StorageUnique(List<int> list)
        {
            int count = 0; // initialize count

            // loop through range of possible values in random
            for (int i = 0; i <= 20000; i++)
            {
                // check if list contains the value i
                if (list.Contains(i))
                {
                    count++; // increase count if list cointains value
                }
            }

            return count;
        }

        /// <summary>
        /// Gets number of unique values from a list by first sorting the list then parsing through it.
        /// </summary>
        /// <param name="list">
        /// The list of integers to try and get the number of unique values from.
        /// </param>
        /// <returns>
        /// The number of unique values from list.
        /// </returns>
        public int SortedUnique(List<int> list)
        {
            int count = 0; // initialize count
            list.Sort(); // sort list from smallest to largest

            // check if list is empty
            if (list.Count() != 0)
            {
                // loop through size of list
                for (int i = 0; i < list.Count; i++)
                {
                    // check if start of list
                    if (i == 0)
                    {
                        count++; // increase count at start of list
                    }

                    // when past start of list
                    if (i > 0)
                    {
                        // check if previous index in list has same value
                        if (list[i].CompareTo(list[i - 1]) != 0)
                        {
                            count++; // increase count when previous value not the same
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Method for generating the string output for the window app.
        /// </summary>
        /// <returns>
        /// String output that talks about the 3 different methods for finding unique integers in a list, the amount
        /// of unique numbers found from each method, and their time complexities.
        /// </returns>
        public string StringOutput()
        {
            string hashSetOutput =
                "1. HashSet method: " + this.HashSetUnique(this.list) + " unique numbers " +
                "\r\n  Time complexity is O(N) for copying the list into a hashset as it needs to parse through the whole list" +
                "\r\n  and the time complexity is O(1) for returning the HashSet.Count. " +
                "\r\n  Overall  the O(N) would add up with the O(1) and result in O(N + 1) complexity which simplifies down to O(N).\r\n \r\n";

            string o1Output =
                "2. O(1) storage method: " + this.O1StorageUnique(this.list) + " unique numbers " +
                "\r\n  Time complexity is O(2N) for parsing as it parses through the range of possible integers which is double the size of list" +
                "\r\n  and the time complexity is O(N) for the List.Contains() method within the for loop. " +
                "\r\n  Overall because O(2N) simplifies down to O(N) and there is an O(N) within it the time complexity of the it all is O(N^2).\r\n \r\n";

            string sortedOutput =
                "3. Sorted method: " + this.SortedUnique(this.list) + " unique numbers " +
                "\r\n  Time complexity is O(N) as the List.Sort() can be ignored and there is one for loop parsing through the size of the list n.";

            return hashSetOutput + o1Output + sortedOutput;
        }
    }
}
