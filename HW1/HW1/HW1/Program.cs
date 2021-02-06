using System;

namespace HW1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree();
            Console.WriteLine("Enter a collection in the range [0, 100], seperated by spaces");
            string input = Console.ReadLine();
            foreach (string s in tree.SplitString(input))
            {
                tree.Root = tree.Insert(tree.Root, Convert.ToInt32(s));
            }

            Console.WriteLine("Sorted Order: " + tree.SortedOrder(tree.Root));
            Console.WriteLine("Number of Items: " + tree.Count(tree.Root));
            Console.WriteLine("Number of Levels: " + tree.Levels(tree.Root));
            Console.WriteLine("Minimum Levels: " + tree.MinLevels());
        }
    }
}
