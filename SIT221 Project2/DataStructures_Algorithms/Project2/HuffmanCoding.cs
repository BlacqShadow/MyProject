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
        private Dictionary<char, string> encodingScheme;
        private Vector<string> EncodedData;
        private Tree _HTree;


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
            GetEncodingScheme();
            return GetEncodedData();
        }

        /*
        *   Encode the 
        */

        private Vector<string> GetEncodedData()
        {
            Vector<string> v = new Vector<string>();
            foreach(char c in rawData)
            {
                if (encodingScheme.ContainsKey(c))
                    v.Add(encodingScheme[c]);
                //else
                //{
                //    //Empty Line 
                //    v.Add("");
                //}
            }
            return v;
        }
        /*
        *   Using Depth First Traversal Method
        *   Put the encoded data in a vector
        */
        private void GetEncodingScheme()
        {
            encodingScheme = new Dictionary<char, string>();
            Vector<int> EncodedValues = new Vector<int>();

            Stack<Node> s = new Stack<Node>();

            //Push the complete tree at node 0 onto the stack
            s.Push(_HTree.root);

            while (s.Count > 0)
            {
                Node current = s.Pop();
                if (current.RightChild != null)
                    s.Push(current.RightChild);
                if (current.LeftChild != null)
                    s.Push(current.LeftChild);
                if(current.LeftChild == null && current.RightChild == null)
                {
                    encodingScheme.Add(current.Value, GetCharCode(current));
                }
            }
        }

        //Get Character code from the huffman tree
        private string GetCharCode(Node n)
        {
            // Reverse the string as we are traversing from the bottom of the tree to get the character codes. 
            return new string(FindParent(n, "").ToCharArray().Reverse().ToArray());
        }
    
        //Find the parent of a node 
        private string FindParent(Node n, string code)
        {
            if (n.Parent == null)
                return code;
            code += ((int)n.edge).ToString();
            return FindParent(n.Parent, code);

        }

        #region Building the huffman tree from raw data
        // After the frequency of the characters are acquired 
        private void buildTree()
        {
            // Check to see if the character weights array is empty.
            // Get a list of trees. 
            if(charWeights != null)
            {
                List<Tree> trees = new List<Tree>();
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
            Tree Left, Right;

            // Sort list of trees
            while(trees.Count() > 1)
            {
				List<Tree> sortedTrees = trees.OrderBy(o => o.root.weight).ToList();
                
                /*
                *   Get the smallest frequency tree first and remove it from trees + sorted trees Lists
                */
                Left = sortedTrees.First();
                Left.root.edge = Edge.Left;     //Add a left edge, i.e. a zero to this node 
                sortedTrees.Remove(Left);
                trees.Remove(Left);

                // Do the same again to get the next smallest frequency 
                Right = sortedTrees.First();
                Right.root.edge = Edge.Right;  //Add a right edge, i.e. a one to this edge
                sortedTrees.Remove(Right);
                trees.Remove(Right);

                //Add both these trees together and add the resulting tree into the trees list
                trees.Add(Tree.addTrees(Left, Right));
            }

            //We don't need the list after creating the tree
            _HTree = trees[0];
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
            Vector<char> decoded = new Vector<char>();

            Dictionary<string, char> RevEncodingScheme = new Dictionary<string, char>();
            //Create a reverse dictionary
            foreach(KeyValuePair<char, string> entry in encodingScheme)
            {
                RevEncodingScheme.Add(entry.Value, entry.Key);
            }
            foreach(string s in input)
            {
                //if(RevEncodingScheme.ContainsKey(s))
                if(s != null)
                    decoded.Add(RevEncodingScheme[s]);
                //else
                //{
                //    // Means that it is an empty character
                //    decoded.Add('\0');
                //}
            }
            
            return decoded;
        }
    }
}
