using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructures_Algorithms.Project1;

namespace DataStructures_Algorithms.Project2
{
    // Material
    // https://en.wikipedia.org/wiki/Huffman_coding
    // https://www.siggraph.org/education/materials/HyperGraph/video/mpeg/mpegfaq/huffman_tutorial.html
    // http://www.geeksforgeeks.org/greedy-algorithms-set-3-huffman-coding/

    public class HuffmanCoding
    {

        private Vector<char> rawData;
        private Dictionary<char, int> charWeights;
        private List<Tree> trees;
        private Vector<int> _encodedData;


        /// <summary>
        /// Takes in a vector to encode the data contained using huffman coding
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Encoded vector</returns>
        public Vector<string> Encode(Vector<char> input)
        {
            rawData = input;
            getWeights();
            buildTree();
            //_encodedData = getEncodedData();
            return null;
        }

        /*
        *   Using Depth First Traversal Method
        *   Put the encoded data in a vector
        */
        private Vector<int> getEncodedData()
        {
            Stack<Node> s = new Stack<Node>();
            s.Push(trees[0].root);

            while (s.Count > 0)
            {
                Node current = s.Pop();
                if (current.RightChild != null)
                    s.Push(current.RightChild);
                if (current.LeftChild != null)
                    s.Push(current.LeftChild);
                Console.WriteLine(current.Value);

            }

            return
        }

        #region Building the huffman tree from raw data
        // After the frequency of the characters are acquired 
        private void buildTree()
        {
            // Check to see if the character weights array is empty.
            // Get a list of trees. 
            if(charWeights != null)
            {
                trees = new List<Tree>();
                foreach (KeyValuePair<char, int> entry in charWeights)
                {
                    // Check to see if it is a null entry
                    if (entry.Key == '\0')
                        continue;
                    trees.Add(new Tree(entry.Key,entry.Value));
                }

                createHuffmanTree(trees);
            }
        }

        private void createHuffmanTree(List<Tree> trees) 
        {
            // Get the lowest two trees and add them together
            // How do you get the lowest two trees, iterate through all the tress and check the minimum weight value
            Tree t1, t2;

            // Sort list of trees
            while(trees.Count() > 1)
            {
				List<Tree> sortedTrees = trees.OrderBy(o => o.root.weight).ToList();
                t1 = sortedTrees.First();
                sortedTrees.Remove(t1);
                trees.Remove(t1);
                t2 = sortedTrees.First();
                sortedTrees.Remove(t2);
                trees.Remove(t2);
                Tree t3 = Tree.addTrees(t1, t2);
                trees.Add(t3);
            }
        }


        /*
        *   This function gets the weights of the values;
        */
        private void getWeights()
        {
            // Declare a new key value pair and store weights of input chars 
            charWeights = new Dictionary<char, int>();
            foreach (char c in rawData)
            {
                if (charWeights.ContainsKey(c))
                {
                    charWeights[c] += 1;
                }
                else
                {
                    charWeights.Add(c, 1);
                }
            }
        }
        #endregion




        /*
        *   Decode the data
        */
        public Vector<char> Decode(Vector<string> input)
        {
            return null;
        }
    }
}
