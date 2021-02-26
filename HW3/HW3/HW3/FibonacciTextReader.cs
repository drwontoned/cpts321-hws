// <copyright file="FibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Fibonacci class that inherits from TextReader.
    /// </summary>
    public class FibonacciTextReader : TextReader
    {

        private BigInteger first = 0; // first value in Fibonacci sequence
        private BigInteger second = 1; // second value in Fibonacci sequence
        private BigInteger current = 0; // placeholder that will get updated based on the first and second value
        private int position = 1; // current line within the Fibonacci sequence
        private int size = 0; // size of the Fibonacci

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Constructor that makes a Fibonacci sequence based on a size parameter.
        /// </summary>
        /// <param name="size">
        /// int size is the maximum number of lines available.
        /// </param>
        public FibonacciTextReader(int size)
        {
            this.size = size;
        }

        /// <summary>
        /// Overriden ReadLine Function that delivers the next number in the Fibonacci sequence.
        /// </summary>
        /// <returns>
        /// a string that is a line of the fibonacci sequence.
        /// </returns>
        public override string ReadLine()
        {
            // initialize output string
            string output;

            // first 2 numbers handled as special cases and output is set accordingly
            if (this.position == 1)
            {
                output = this.position + ": " + this.first;
                this.position++;
            }
            else if (this.position == 2)
            {
                output = this.position + ": " + this.second;
                this.position++;
            }

            // after passing the first 2 numbers the fibonacci formula used to calculate
            // the next value and adds it to the output
            else
            {
                this.current = this.first + this.second;
                output = this.position + ": " + this.current;
                this.position++;
                this.first = this.second;
                this.second = this.current;
            }

            return output;
        }

        /// <summary>
        /// Overriden ReadToEnd Function.
        /// </summary>
        /// <returns>
        /// a string of the full fibonacci sequence based on size given by constructor.
        /// </returns>
        public override string ReadToEnd()
        {
            // StringBuilder for appending line into a single string
            StringBuilder builder = new StringBuilder();

            // loop size amount of times to generate the Fibonacci sequence
            for (int i = 0; i < this.size; i++)
            {
                builder.AppendLine(this.ReadLine());
            }

            // reset first, second, and current value after the size amount of calls to the Readline method.
            this.first = 0;
            this.second = 1;
            this.current = 0;

            // return a string of the Fibonacci sequence
            return builder.ToString();
        }

    }
}
