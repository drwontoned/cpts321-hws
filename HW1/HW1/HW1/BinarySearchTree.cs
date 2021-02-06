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
        /// Gets or sets the root of the tree.
        /// </summary>
        public Node Root { get => this.root; set => this.root = value; }

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

        /// <summary>
        /// Recursive method that does an inorder traversal of the tree to generate a string.
        /// </summary>
        /// <param name="root">
        /// the root node of the tree.
        /// </param>
        /// <returns>
        /// A string of values in sorted order from the tree.
        /// </returns>
        public string SortedOrder(Node root)
        {
            string sortedOrder = string.Empty; // initialize empty string

            // if root not null then do an inorder traversal of tree
            if (root != null)
            {
                sortedOrder += this.SortedOrder(root.LeftChild); // traverse left sub tree generating in order string.
                sortedOrder += root.Value + " "; // add root to string.
                sortedOrder += this.SortedOrder(root.RightChild); // traverse right sub tree generating in order string.
            }

            return sortedOrder;
        }

        /// <summary>
        /// Recursive method that gets the total number of nodes in a tree.
        /// </summary>
        /// <param name="root">
        /// the node the count will base off of.
        /// </param>
        /// <returns>
        /// the integer number of nodes in the tree.
        /// </returns>
        public int Count(Node root)
        {
            int count = 0; // initialize count of 0.

            // if node is not null
            if (root != null)
            {
                count++; // increase count by 1.
                count += this.Count(root.LeftChild); // increase count by calling this method on the left child.
                count += this.Count(root.RightChild); // increase count by calling this method on the right child.
            }

            return count;
        }

        /// <summary>
        /// Recursive method that gets the number of levels in the tree.
        /// </summary>
        /// <param name="root">
        /// the node the count will base off of.
        /// </param>
        /// <returns>
        /// the integer number of max levels in the tree.
        /// </returns>
        public int Levels(Node root)
        {
            int levels = 0; // initialize count of 0.

            // if node is not null
            if (root != null)
            {
                int leftLevels = this.Levels(root.LeftChild);
                int rightLevels = this.Levels(root.RightChild);

                if (leftLevels > rightLevels)
                {
                    levels += leftLevels;
                }
                else
                {
                    levels += rightLevels;
                }
            }

            return levels;
        }

        /// <summary>
        /// Recursive method that gets the theoretical minimum number of levels in the tree.
        /// </summary>
        /// <returns>
        /// the integer number of theoretical minimum levels in the tree.
        /// </returns>
        public int MinLevels()
        {
            int count = this.Count(this.root);
            int min = 0;
            int currentLevel = 1;

            while (count > 0)
            {
                count -= currentLevel;
                currentLevel *= 2;
                min++;
            }

            return min;
        }
    }
}
