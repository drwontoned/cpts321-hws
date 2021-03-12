// <copyright file="ValueVariableFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Factory class that creates different types of TreeNodes.
    /// </summary>
    public class ValueVariableFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueVariableFactory"/> class.
        /// </summary>
        public ValueVariableFactory()
        {
        }

        /// <summary>
        /// Method for creating the different types of TreeNodes.
        /// </summary>
        /// <param name="node">
        /// The string that will be looked at and converted to a node.
        /// </param>
        /// <returns>
        /// A type of TreeNode based on the string input.
        /// </returns>
        public TreeNode CreateNode(string node)
        {
            // Create a value node if the string starts with a digit.
            if (char.IsDigit(node[0]))
            {
                return new ValueNode(Convert.ToDouble(node));
            }

            // Create a variableNode otherwise.
            return new VariableNode(node);
        }
    }
}
