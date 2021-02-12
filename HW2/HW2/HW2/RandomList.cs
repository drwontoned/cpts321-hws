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
    }
}
