// <copyright file="VariableNode.cs" company="PlaceholderCompany">
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
    /// Node class for variables.
    /// </summary>
    public class VariableNode : TreeNode
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="value">
        /// The variable name of this node.
        /// </param>
        public VariableNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets variable value.
        /// </summary>
        public double Value { get => this.value; set => this.value = value; }

        /// <summary>
        /// Method that evaluates this node.
        /// </summary>
        /// <returns>
        /// the value of this node.
        /// </returns>
        public override double Evaluate()
        {
            return this.Value;
        }
    }
}
