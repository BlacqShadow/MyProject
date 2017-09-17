using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Project2
{
    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public char Value { get; set; }
        public int weight { get; set; }
    }
    public class Tree
    {
        public Node root { get; set; }

        // Constructor for the resulting tree 
        public Tree(int weight)
        {
            root.Value = '\0';
            root.weight = weight;
        }

        // Constructor for inital character trees. 
        public Tree(char value, int weight)
        {
            root.Value = value;
            root.weight = weight;
        }


        /// <summary>
        /// Adds Two trees together into a new tree whose weight is the sum of the weights of T1 and T2
        /// </summary>
        /// <returns>The merged tree</returns>
        /// <param name="T1">Tree 1</param>
        /// <param name="T2">Tree 2</param>
        public static Tree addTrees(Tree T1, Tree T2)
        {
            Tree finalTree = new Tree(T1.root.weight + T2.root.weight);
            finalTree.root.LeftChild = T1.root;
            finalTree.root.RightChild = T2.root;
            return finalTree;
        }
    }
}
