using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures_Algorithms.Project1
{
    public class DataSerializer<T> where T : IConvertible
    {
        public static void Serialise(string path, Vector<T> vector)
        {
            using (Stream stream = File.Open(path, FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, vector);
            }
        }
        public void deserialise(string path, ref Vector<T> vector)
        {

            using (Stream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                vector = (Vector<T>)bin.Deserialize(stream);

            }
        }

        public static void LoadVectorFromTextFile(string path, ref Vector<T> vector)
        {

            vector = new Vector<T>();
            string[] line = System.IO.File.ReadAllLines(path);
            foreach(string l in line)
            {
                if (l == "")
                {
                    vector.Add((T)Convert.ChangeType('\0', typeof(T)));
                }
                else
                {
                    //This would work only for primitive types
                    vector.Add((T)Convert.ChangeType(l, typeof(T)));
                }
            }

        }

        public static void SaveVectorToTextFile(string path, Vector<T> vector)
        {
            using (BufferedStream bs = new BufferedStream(File.Open(path, FileMode.Create)))
            using (StreamWriter sw = new StreamWriter(bs))
            {
                var count = vector.Count;
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(vector[i]);
                }
            }
        }

        /// <summary>
        /// Load the file as a binary file and then convert it to Base64string, run the huffman coding algorithm
        /// Then convert back to binary to write to a file. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="vector"></param>
        public static void LoadVectorFromAnyFile(string path, ref Vector<T> vector)
        {
            vector = new Vector<T>();
            string line = "";

            //Using base 64 encoding as ASCII was very lossy and the original file couldn't be contructed back. 
            byte[] bin = System.IO.File.ReadAllBytes(path);
            line = Convert.ToBase64String(bin);


            foreach (char c in line)
            {
                vector.Add((T)Convert.ChangeType(c, typeof(T)));
            }
        
        }


        /// <summary>
        /// Then convert back to binary to write to a file. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="vector"></param>
        public static void SaveFinalOutput(string path,Vector<T> vector)
        {
            string line = "";
            for (int i = 0; i < vector.Count; i++)
            {
                line += vector[i];
            }
            byte[] rebin = Convert.FromBase64String(line);

            System.IO.File.WriteAllBytes(path, rebin);
         
        }


        /// <summary>
        /// Converts the file back to the original state. 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="vector"></param>
        public static void GetOriginalFile(string path, Vector<T> vector)
        {
            string line = "";
            for(int i = 0; i < vector.Count; i++)
            {
                line += vector[i];
            }
            byte[] rebin = Convert.FromBase64String(line);

            System.IO.File.WriteAllBytes(path, rebin);
        }
    }
}
