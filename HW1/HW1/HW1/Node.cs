// <copyright file="Node.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Node class that generates Nodes that have specific values to
    /// be used in a binary search tree.
    /// </summary>
    public class Node
    {
        private int value; // integer value of the node
        private Node leftChild = null; // left child of the node that should have a lesser value
        private Node rightChild = null; // right child of the node that should have a greater value

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="value">
        /// integer value the node created node will have.
        /// </param>
        public Node(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets or sets Value of the Node.
        /// </summary>
        public int Value { get => this.value; set => this.value = value; }

        /// <summary>
        /// Gets or sets left child of the Node.
        /// </summary>
        public Node LeftChild { get => this.leftChild; set => this.leftChild = value; }

        /// <summary>
        /// Gets or sets right child of the Node.
        /// </summary>
        public Node RightChild { get => this.rightChild; set => this.rightChild = value; }
    }
}
