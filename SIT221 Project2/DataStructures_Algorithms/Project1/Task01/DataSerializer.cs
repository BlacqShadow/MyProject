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
            string line = "";
            using (StreamReader sr = new StreamReader(path))
            {
                //Change this function to
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        vector.Add((T)Convert.ChangeType('\0', typeof(T)));
                    }
                    else
                    {
                    //This would work only for primitive types
                    vector.Add((T)Convert.ChangeType(line, typeof(T)));
                    }
                }

            }
        }

        public static void SaveVectorToTextFile(string path, Vector<T> vector)
        {

            using (StreamWriter sw = new StreamWriter(path))
            {
                var count = vector.Count;
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(vector[i]);
                }
            }
        }

        public static void LoadVectorFromAnyFile(string path, ref Vector<T> vector)
        {
            vector = new Vector<T>();
            string line = "";
            using (BufferedStream bs = new BufferedStream(File.Open(path, FileMode.Open)))
            using (BinaryReader br = new BinaryReader(bs))
            {

                byte[] bin = br.ReadBytes(Convert.ToInt32(br.BaseStream.Length));
                line = Convert.ToBase64String(bin);


                foreach (char c in line)
                {
                    vector.Add((T)Convert.ChangeType(c, typeof(T)));
                }
                ////Set the position and length of the stream 
                //for (int pos = 0; pos < (int)br.BaseStream.Length; pos += sizeof(char))
                //{
                //    vector.Add((T)Convert.ChangeType(br.ReadChar(), typeof(T)));
                //}

            }
        }

        public static void SaveFinalOutput(string path,Vector<T> vector)
        {
            string line = "";
            for (int i = 0; i < vector.Count; i++)
            {
                line += vector[i];
            }
            byte[] rebin = Convert.FromBase64String(line);
            using(BufferedStream bs = new BufferedStream(File.Open(path, FileMode.Create)))
            using (BinaryWriter bw = new BinaryWriter(bs))
            {
                bw.Write(rebin);
            }
        }

    }
}
