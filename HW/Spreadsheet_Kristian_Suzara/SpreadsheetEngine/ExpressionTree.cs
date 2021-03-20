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
        private readonly Dictionary<string, VariableNode> variableDictionary = new Dictionary<string, VariableNode>();
        private readonly ValueVariableFactory factory = new ValueVariableFactory();
        private readonly OperatorFactory opFactory = new OperatorFactory();
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
                Stack<TreeNode> nodeStack = new Stack<TreeNode>();

                // Loop through the list of strings that are in postfix.
                for (int i = 0; i < nodeStringList.Count; i++)
                {
                    string current = nodeStringList.ElementAt(i);

                    // If the first char of the string is a letter or digit then we know its a variable or value.
                    if (char.IsLetterOrDigit(current[0]))
                    {
                        // If it is a value.
                        if (char.IsDigit(current[0]))
                        {
                            // Create a ValueNode based on current string.
                            ValueNode thisValue = this.factory.CreateNode(current) as ValueNode;

                            // Push node in to the stack.
                            nodeStack.Push(thisValue);
                        }

                        // Otherwise it is a variable.
                        else
                        {
                            // Create a VariableNode based on current string
                            VariableNode thisVariable = this.factory.CreateNode(current) as VariableNode;

                            // Push node in to the stack.
                            nodeStack.Push(thisVariable);

                            // If the dictionary does not already contain this variable.
                            if (!this.variableDictionary.ContainsKey(current))
                            {
                                // Then add this variable to the dictionary.
                                this.variableDictionary.Add(current, thisVariable);
                            }
                        }
                    }

                    // Otherwise we know it is an operator.
                    else
                    {
                        // Set current OperatorNode
                        OperatorNode currentOperator = this.opFactory.CreateOperatorNode(current);

                        // Pop out a Tree node from the stack and set current OperatorNodes right child.
                        currentOperator.RightChild = nodeStack.Pop() as TreeNode;

                        // Pop out a Tree node from the stack and set current OperatorNodes left child.
                        currentOperator.LeftChild = nodeStack.Pop() as TreeNode;

                        // Push the operator into the stack.
                        nodeStack.Push(currentOperator);
                    }
                }

                // Set this ExpressionTrees root to the node at the top of the stack.
                this.root = nodeStack.Peek();
            }
        }

        /// <summary>
        /// Gets a string expression.
        /// </summary>
        public string Expression { get => this.expression; }

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

                // If current char is a letter or digit.
                if (char.IsLetterOrDigit(current))
                {
                    // Add current char to the nodeString.
                    nodeString += current;
                }

                // otherwise it is an operator, parenthesis or space.
                else
                {
                    // If current char is not a space.
                    if (current != ' ')
                    {
                        // If the nodeString is not empty.
                        if (nodeString != string.Empty)
                        {
                            // Add the string (which should be a variable or value) to the list.
                            nodeStringList.Add(nodeString);
                        }

                        // Reset the nodeString.
                        nodeString = string.Empty;

                        // Add the current char as a string to the list.
                        nodeStringList.Add(current.ToString());
                    }
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

                // If the first char of the string is a letter or digit then we know its a variable or value.
                if (char.IsLetterOrDigit(current[0]))
                {
                    // Add the string to the list.
                    nodeStringList.Add(current);
                }

                // If the string is a left parenthesis then just push to stack
                else if (current == "(")
                {
                    operatorStack.Push(current);
                }

                // If the string is a right parenthesis
                else if (current == ")")
                {
                    // While stack is not empty and the top of the stack is not a left parenthesis.
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        // Pop from stack and add to list.
                        nodeStringList.Add(operatorStack.Pop());
                    }

                    // If stack is not empty and the top of the stack is not a left parenthesis.
                    if (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        // Return a new list.
                        return new List<string>();
                    }

                    // Otherwise pop from the stack.
                    else
                    {

                        operatorStack.Pop();
                    }
                }

                // Otherwise we know it is an operator.
                else
                {
                    // While the stack is not empty and the precedence of the current operator is less than or equal to what is at the top of the stack.
                    while (operatorStack.Count > 0 && this.CheckPrecedence(current[0]) <= this.CheckPrecedence(operatorStack.Peek()[0]))
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

        /// <summary>
        /// Gets value from dictionary based on the variable key.
        /// </summary>
        /// <param name="variableName">
        /// The key for the dictionary value.
        /// </param>
        /// <returns>
        /// The double value from the dictionary.
        /// </returns>
        public double GetVariableValue(string variableName)
        {
            return this.variableDictionary[variableName].Value;
        }

        /// <summary>
        /// Method for setting the variable value in the dictionary.
        /// </summary>
        /// <param name="variableName">
        /// The variable name and key.
        /// </param>
        /// <param name="variableValue">
        /// The variable value.
        /// </param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.variableDictionary[variableName].Value = variableValue;
        }

        /// <summary>
        /// Method that evaluates the expression by going down and evaluating each node in the tree starting from the root.
        /// </summary>
        /// <returns>
        /// The evaluated value of the ExpressionTree.
        /// </returns>
        public double Evaluate()
        {
            return this.root.Evaluate();
        }

        /// <summary>
        /// Method that returns an int value that represents the level of precedence.
        /// </summary>
        /// <param name="operatorType">
        /// The char that is an operator.
        /// </param>
        /// <returns>
        /// The int value that corresponds with the operators precedence level.
        /// </returns>
        public int CheckPrecedence(char operatorType)
        {
            // If an operator return the precedence.
            if(opFactory.InDictionary(operatorType.ToString()))
            {
                return opFactory.CreateOperatorNode(operatorType.ToString()).Precedence;
            }
            // Otherwise return -1;
            return -1;
        }
    }
}
