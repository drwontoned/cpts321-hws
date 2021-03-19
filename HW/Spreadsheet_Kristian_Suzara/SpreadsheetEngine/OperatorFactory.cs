// <copyright file="OperatorFactory.cs" company="PlaceholderCompany">
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
    /// Factory class for generating the different types of operator node.
    /// </summary>
    public class OperatorFactory
    {
        private Dictionary<string, int> operatorDictionary = new Dictionary<string, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OperatorFactory"/> class.
        /// </summary>
        public OperatorFactory()
        {
            this.operatorDictionary.Add("+", 1);
            this.operatorDictionary.Add("-", 1);
            this.operatorDictionary.Add("*", 2);
            this.operatorDictionary.Add("/", 2);
        }

        /// <summary>
        /// Method for creating the different types of TreeNodes.
        /// </summary>
        /// <param name="op">
        /// The string that will be looked at and converted to a node.
        /// </param>
        /// <returns>
        /// A type of TreeNode based on the string input.
        /// </returns>
        public OperatorNode CreateOperatorNode(string op)
        {
            if (op == "+")
            {
                return new AdditionOperator(operatorDictionary[op]);
            }
            else if (op == "-")
            {
                return new SubtractionOperator(operatorDictionary[op]);
            }
            else if (op == "*")
            {
                return new MultiplicationOperator(operatorDictionary[op]);
            }
            else
            {
                return new DivisionOperator(operatorDictionary[op]);
            }
        }

        /// <summary>
        /// Class that represents an addition operator and inherits from OperatorNode.
        /// </summary>
        private class AdditionOperator : OperatorNode
        {
            public AdditionOperator(int precedence)
            {
                this.Precedence = precedence;
            }

            public override double Evaluate()
            {
                return this.LeftChild.Evaluate() + this.RightChild.Evaluate();
            }
        }

        /// <summary>
        /// Class that represents an subtraction operator and inherits from OperatorNode.
        /// </summary>
        private class SubtractionOperator : OperatorNode
        {
            public SubtractionOperator(int precedence)
            {
                this.Precedence = precedence;
            }

            public override double Evaluate()
            {
                return this.LeftChild.Evaluate() - this.RightChild.Evaluate();
            }
        }

        /// <summary>
        /// Class that represents an multiplication operator and inherits from OperatorNode.
        /// </summary>
        private class MultiplicationOperator : OperatorNode
        {
            public MultiplicationOperator(int precedence)
            {
                this.Precedence = precedence;
            }

            public override double Evaluate()
            {
                return this.LeftChild.Evaluate() * this.RightChild.Evaluate();
            }
        }

        /// <summary>
        /// Class that represents an division operator and inherits from OperatorNode.
        /// </summary>
        private class DivisionOperator : OperatorNode
        {
            public DivisionOperator(int precedence)
            {
                this.Precedence = precedence;
            }

            public override double Evaluate()
            {
                return this.LeftChild.Evaluate() / this.RightChild.Evaluate();
            }
        }
    }
}
