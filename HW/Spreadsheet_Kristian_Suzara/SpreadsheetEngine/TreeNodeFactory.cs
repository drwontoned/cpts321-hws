// <copyright file="TreeNodeFactory.cs" company="PlaceholderCompany">
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
    public class TreeNodeFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeFactory"/> class.
        /// </summary>
        public TreeNodeFactory()
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

            // Create a variable node if the string starts with a letter
            else if (char.IsLetter(node[0]))
            {
                return new VariableNode(node);
            }

            // Create an operator node if it does not start with a digit or letter.
            return new OperatorNode(node[0]);
        }
    }
}
