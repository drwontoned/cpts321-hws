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
    }
}
