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

        public Tree(int weight)
        {
            root.Value = '\0';
            root.weight = weight;
        }

        public Tree(char value, int weight)
        {
            root.Value = value;
            root.weight = weight;
        }
        public Tree addTrees(Tree T1, Tree T2)
        {
            Tree finalTree = new Tree(T1.root.weight + T2.root.weight);
            finalTree.root.LeftChild = T1.root;
            finalTree.root.RightChild = T2.root;
            return finalTree;
        }
    }
}
