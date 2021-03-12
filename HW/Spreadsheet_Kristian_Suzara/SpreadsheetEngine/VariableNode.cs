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
        private string variable;

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="variable">
        /// The variable name of this node.
        /// </param>
        public VariableNode(string variable)
        {
            this.variable = variable;
        }

        /// <summary>
        /// Gets Variable name.
        /// </summary>
        public string Variable { get => this.variable; }
    }
}
