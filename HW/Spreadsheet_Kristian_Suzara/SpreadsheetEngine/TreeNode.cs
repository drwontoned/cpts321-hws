// <copyright file="TreeNode.cs" company="PlaceholderCompany">
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
    /// Abstract node class that all of the nodes in the ExpressionTree will inherit from.
    /// </summary>
    public abstract class TreeNode
    {
        /// <summary>
        /// Abstract method for evaluating a node.
        /// </summary>
        /// <returns>
        /// A double value.
        /// </returns>
        public abstract double Evaluate();
    }
}
