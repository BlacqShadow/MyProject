using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DataStructures_Algorithms
{
	public class BSTNode<T>
	{
		public BSTNode<T> LeftChild { get; set; }
		public BSTNode<T> RightChild { get; set; }
		public T Value { get; set; }
        public BSTNode(T element)
        {
            Value = element;
            LeftChild = null;
            RightChild = null;
        }
        
	}

    public class BinarySearchTree<T>
	{
		private BSTNode<T> Root { get; set; }

        public BinarySearchTree()
		{
   
		}

		private BSTNode<T> Add(BSTNode<T> node,T element)
		{
            // TODO: Add element into the tree
            if(node == null)
            {
                node = new BSTNode<T>(element);
                //Root.Value = element;
            }
            else
            {
                
                if(Comparer.Default.Compare(element, node.Value) <= 0)
                {
                    node.LeftChild = Add(node.LeftChild, element);
                }
                else
                {
                    node.RightChild = Add(node.RightChild, element);
                }
            }
            return node;
		}

        public void Add(T element)
        {
            // TODO: Add element into the tree
            Root = Add(Root, element);
        }

        public BSTNode<T> Search(T element)
        {
            // TODO: This method should return a BSTNode whose value is equal to element
            return null;
        }

        public T Min()
        {
            // TODO: This method return the min value of the tree
            return default(T);
        }

        public T Max()
        {
            // TODO: This method return the max value of the tree
            return default(T);
        }

        public void Traverse(TraversalMode mode, TextWriter tw)
		{
			switch (mode)
			{
				case TraversalMode.PRE: PreOrder_Traverse(Root, tw); break;
				case TraversalMode.POST: PostOrder_Traverse(Root, tw); break;
				case TraversalMode.IN: InOrder_Traverse(Root, tw); break;
			}

		}

        private void PreOrder_Traverse(BSTNode<T> node, TextWriter tw)
        {
            if (node == null) return;

            // the order for traversal should be: middle, left, right
            tw.WriteLine(node.Value);
            PreOrder_Traverse(node.LeftChild, tw);
            PreOrder_Traverse(node.RightChild, tw);
        }

        private void InOrder_Traverse(BSTNode<T> node, TextWriter tw)
		{
            // TODO: the order for traversal should be: left, middle, right
            
        }

		private void PostOrder_Traverse(BSTNode<T> node, TextWriter tw)
		{
            // TODO: the order for traversal should be: left, right, middle
            
        }
	}
}
