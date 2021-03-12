// <copyright file="ValueNode.cs" company="PlaceholderCompany">
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
    /// Node class for values.
    /// </summary>
    public class ValueNode : TreeNode
    {
        private double value;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueNode"/> class.
        /// </summary>
        /// <param name="value">
        /// The value of this node.
        /// </param>
        public ValueNode(double value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets value.
        /// </summary>
        public double Value { get => this.value; }
    }
}
