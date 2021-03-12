// <copyright file="OperatorNode.cs" company="PlaceholderCompany">
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
    /// Node class for operators.
    /// </summary>
    public abstract class OperatorNode : TreeNode
    {
        private TreeNode rightChild = null;
        private TreeNode leftChild = null;

        /// <summary>
        /// Gets or sets for RightChild.
        /// </summary>
        public TreeNode RightChild { get => this.rightChild; set => this.rightChild = value; }

        /// <summary>
        /// Gets or sets for LeftChild.
        /// </summary>
        public TreeNode LeftChild { get => this.leftChild; set => this.leftChild = value; }
    }
}
