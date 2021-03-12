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
        private TreeNodeFactory factory = new TreeNodeFactory();
        private string expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression">
        /// the expression being thrown into the tree.
        /// </param>
        public ExpressionTree(string expression)
        {
            this.expression = expression;
            if (expression == string.Empty)
            {
                this.root = null;
            }
        }

        /// <summary>
        /// Method for breaking up the expression into a list of smaller strings that can be looked at with the factory to create TreeNodes.
        /// </summary>
        /// <param name="expression">
        /// The expression getting broken down.
        /// </param>
        /// <returns>
        /// A list of strings representing values, variables, and operators.
        /// </returns>
        public List<string> SplitExpression(string expression)
        {
            List<string> nodeStringList = new List<string>();
            string nodeString = string.Empty;
            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];
                if (current == '+' || current == '-' || current == '*' || current == '/')
                {
                    if (nodeString != string.Empty)
                    {
                        nodeStringList.Add(nodeString);
                    }

                    nodeString = string.Empty;
                    nodeStringList.Add(current.ToString());
                }
                else
                {
                    nodeString += current;
                }
            }

            return nodeStringList;
        }
    }
}
