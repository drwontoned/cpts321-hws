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
            // Set the trees expression.
            this.expression = expression;

            // If the expression is nothing.
            if (expression == string.Empty)
            {
                // Then set root to null.
                this.root = null;
            }

            // Otherwise generate tree based on expression.
            else
            {
                List<string> nodeStringList = this.SplitExpression(expression); // Break up expression into a list of strings.
                nodeStringList = this.ToPostFix(nodeStringList); // Order the expression into postfix.
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

            // Loop through expression.
            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                // If current char is an operator.
                if (current == '+' || current == '-' || current == '*' || current == '/')
                {
                    // If the nodeString is not empty.
                    if (nodeString != string.Empty)
                    {
                        // Add the string (which should be a variable or value) to the list.
                        nodeStringList.Add(nodeString);
                    }

                    // Reset the nodeString.
                    nodeString = string.Empty;

                    // Add the current char(which should be an operator) as a string to the list.
                    nodeStringList.Add(current.ToString());
                }

                // If current char is not an operator.
                else
                {
                    // Add current char to the nodeString.
                    nodeString += current;
                }
            }

            // Add the final variable or value to the list
            if (nodeString != string.Empty)
            {
                nodeStringList.Add(nodeString);
            }

            // Return a list with strings that can be converted to nodes.
            return nodeStringList;
        }

        /// <summary>
        /// Method for ordering an Infix list of strings that is equivalent to an expression into postfix.
        /// </summary>
        /// <param name="list">
        /// The list getting reordered.
        /// </param>
        /// <returns>
        /// A reordered list of strings equivalent to a postfix expression.
        /// </returns>
        public List<string> ToPostFix(List<string> list)
        {
            List<string> nodeStringList = new List<string>();
            Stack<string> operatorStack = new Stack<string>();

            // Loop through the list of strings.
            for (int i = 0; i < list.Count; i++)
            {
                string current = list.ElementAt(i);

                // If the first char of the string is a letter or digit then we know its a variable or value
                if (char.IsLetterOrDigit(current[0]))
                {
                    // Add the string to the list.
                    nodeStringList.Add(current);
                }

                // Otherwise we know it is an operator.
                else
                {
                    // While the stack is not empty.
                    while (operatorStack.Count > 0)
                    {
                        // Pop an operator from the stack and add it the the list.
                        nodeStringList.Add(operatorStack.Pop());
                    }

                    // Push the current operator into the stack.
                    operatorStack.Push(current);
                }
            }

            // While the stack is not empty.
            while (operatorStack.Count > 0)
            {
                // Pop all the leftover operators from the stack and add it the the list.
                nodeStringList.Add(operatorStack.Pop());
            }

            // Return the new postfix expression list.
            return nodeStringList;
        }
    }
}
