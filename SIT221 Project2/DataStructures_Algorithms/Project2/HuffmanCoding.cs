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
        private List<Dictionary<char, int>> forests; 
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
            return null;
        }

        // Build the tree after aquiring weights
        private void buildTree()
        {
            for(int i = 0; i < charWeights.Count; i++)
            {
                forests.Add(new Tree())
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



        /*
        *   Decode the data
        */
        public Vector<char> Decode(Vector<string> input)
        {
            return null;
        }
    }
}
