using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sailing2
{
    class LoadFullFile
    {
        public static void ExportToFile(Dictionary<string, Boats> fulldictionary, string path)
        {
            using (StreamWriter sw = File.AppendText(@path + @"\FullDump.csv"))
            {
                foreach (var entry in fulldictionary)
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", entry.Value.name, entry.Value.noOfBoats, 
                        entry.Value.boat1, entry.Value.boatNumber1, 
                        entry.Value.boat2, entry.Value.boatNumber2,
                         entry.Value.boat3, entry.Value.boatNumber3, 
                         entry.Value.boat4, entry.Value.boatNumber4, 
                         entry.Value.boat5, entry.Value.boatNumber5);
            }
        }

        public static Dictionary<string, Boats> loadFullFile(string path)
        //public static string LoadFullFile()
        {
            StreamReader reader = System.IO.File.OpenText(@path + @"Full List.txt");
            string line;
            Dictionary<int, BoatsFromExcel> BoatDictionaryInterim = new Dictionary<int, BoatsFromExcel>();
            Dictionary<string, Boats> BoatDictionary = new Dictionary<string, Boats>();

            int count1 = 0;
            while ((line = reader.ReadLine()) != null)

            {
                string[] items = line.Split(char.Parse("\n"));

                while ((line = reader.ReadLine()) != null)
                {
                    string[] items1 = line.Split('\t');
                    BoatsFromExcel boat1 = new BoatsFromExcel(items1[0], int.Parse(items1[1]), items1[2]);
                    BoatDictionaryInterim.Add(count1, boat1);
                    count1++;
                }


            }
            List<string> keys = new List<string>();

            int m = 0;
            foreach (KeyValuePair<int, BoatsFromExcel> Boat in BoatDictionaryInterim)
            {
                if (keys.Contains(BoatDictionaryInterim[m].name))
                {
                    if (BoatDictionary[BoatDictionaryInterim[m].name].boat2 == null)
                    {
                        Boats boat1 = new Boats(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionaryInterim[m].boat,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat3 == null)
                    {

                        Boats boat1 = new Boats(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionaryInterim[m].boat,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat4 == null)
                    {
                        Boats boat1 = new Boats(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber3,
                        BoatDictionaryInterim[m].boat,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }
                    else if (BoatDictionary[BoatDictionaryInterim[m].name].boat5 == null)
                    {
                        Boats boat1 = new Boats(BoatDictionaryInterim[m].name,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber1,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber2,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber3,
                        BoatDictionary[BoatDictionaryInterim[m].name].boat4,
                        BoatDictionary[BoatDictionaryInterim[m].name].boatNumber4,
                        BoatDictionaryInterim[m].boat,
                        BoatDictionaryInterim[m].boatNumber);
                        BoatDictionary.Remove(BoatDictionaryInterim[m].name);
                        BoatDictionary.Add(boat1.name, boat1);
                    }

                }
                else
                {
                    Boats boat3 = new Boats(BoatDictionaryInterim[m].name,
                    BoatDictionaryInterim[m].boat,
                    BoatDictionaryInterim[m].boatNumber);
                    BoatDictionary.Add(boat3.name, boat3);
                    keys.Add(BoatDictionaryInterim[m].name);
                }
                m++;






            }
            reader.Close();
            return BoatDictionary;
        }
    }
}

