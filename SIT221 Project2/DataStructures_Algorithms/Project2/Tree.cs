using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Project2
{
    // Represents the edge, the node belongs to i.e. Left or Right
    public enum Edge
    {
        Left,
        Right
    }
    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        /*
        *   Member Variables
        */
        private char value;
        private bool _visited;
        public Edge edge; 
        #region Properties
        public bool Visited
        {
            get { return _visited; }
            set { _visited = value; }
        }
        public char Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }
        public int weight { get; set; }
        #endregion

        public Node()
        {
            value = '\0';
            weight = 0;
            Visited = false;
            
        }
    }
    public class Tree
    {
        public Node root { get; set; }

        // Constructor for the resulting tree 
        public Tree(int weight)
        {
            root = new Node();
            root.Value = '\0';
            root.weight = weight;
        }

        // Constructor for inital character trees. 
        public Tree(char value, int weight)
        {
            root = new Node();
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
