// <copyright file="ExpressionTree.cs" company="PlaceholderCompany">
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
    /// Expression Tree class which is a string expression thrown into a tree.
    /// </summary>
    public class ExpressionTree
    {
        private readonly TreeNode root;
        private readonly Dictionary<string, double> variableDictionary = new Dictionary<string, double>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">
        /// the expression being thrown into the tree.
        /// </param>
        public ExpressionTree(string expression)
        {

        }
    }
}
