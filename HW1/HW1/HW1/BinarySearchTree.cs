// <copyright file="BinarySearchTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace HW1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Binary Search Tree class used that has nodes inserted into it to organize values.
    /// </summary>
    public class BinarySearchTree
    {
        private Node root; // the root node of the tree.

        /// <summary>
        /// Initializes a new instance of the <see cref="BinarySearchTree"/> class.
        /// </summary>
        public BinarySearchTree()
        {
            this.root = null;
        }

        /// <summary>
        /// Splits up all of the numbers listed by the user.
        /// </summary>
        /// <param name="userInput">
        /// the user input string of numbers.
        /// </param>
        /// <returns>
        /// the broken up list of numbers.
        /// </returns>
        public string[] SplitString(string userInput)
        {
            string[] items = userInput.Split(' ');
            return items;
        }

        /// <summary>
        /// Inserts node into tree if a node of that value doesnt exist already.
        /// </summary>
        /// <param name="root">
        /// the root of the tree.
        /// </param>
        /// <param name="value">
        /// the value of a node being inserted into the tree.
        /// </param>
        /// <returns>
        /// the <paramref name="root"/> of the tree after the insertion was made.
        /// </returns>
        public Node Insert(Node root, int value)
        {
            Node item = new Node(value); // new node getting inserted.
            Node current = root; // the current position in the tree.
            bool inserted = false; // boolean to loop deeper into the tree.

            if (current != null)
            {
                // loop deeper into the tree until the node is inserted or until it is found that you have a duplicate value.
                while (!inserted)
                {
                    // check if value is less than current nodes value.
                    if (value < current.Value)
                    {

                        // if left child exists move down to that child and set that as the current.
                        if (current.LeftChild != null)
                        {
                            current = current.LeftChild;
                        }

                        // if no left child exists set left child to item.
                        else
                        {
                            current.LeftChild = item;
                            inserted = true;
                        }
                    }

                    // check if value is greater than current nodes value.
                    else if (value > current.Value)
                    {
                        // if right child exists move down to that child and set that as the current.
                        if (current.RightChild != null)
                        {
                            current = current.RightChild;
                        }

                        // if no right child exists set right child to item.
                        else
                        {
                            current.RightChild = item;
                            inserted = true;
                        }
                    }

                    // if value is equal to the current nodes value exit out of loop.
                    else
                    {
                        inserted = true;
                    }
                }
            }

            // if root is null then set root to item.
            else
            {
                this.root = item;
            }

            return root;
        }
    }
}
