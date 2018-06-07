using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft;
using System.Windows.Input;
using System.Linq;
using System.Data;
using ExcelDataReader;

namespace Sailing
{

    class Program
    { 
        
        //public static Dictionary<string, Boats> LoadFullExcel(string path)
        public static void LoadFullExcel(string path)
        {
            using (var stream = File.Open(@path + @"\WFSC_DATA (3).xlsx", FileMode.Open, FileAccess.Read))
            {

                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                /*
                using (StreamWriter file =
new StreamWriter(@path + @"\Full List.txt", true))
                {

                }
                */

                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                         //2. Use the AsDataSet extension method
                        var result = reader.AsDataSet();
                        DataTable table = new DataTable();
                        Console.ReadLine();
                        table = result.Tables[2];
                        File.Delete(@path + @"\Full List.txt");
                        //File.Create(@path + @"\Full List.txt");
                        using (StreamWriter file =
new StreamWriter(@path + @"\Full List.txt", true))
                        {

                            foreach (DataRow dr in table.Rows)
                            {
                                if (!dr["Column2"].ToString().Equals("") && !dr["Column2"].ToString().Equals("Class"))
                                {


                                file.WriteLine("{0}\t{1}\t{2}", dr["Column0"].ToString(),
                                dr["Column1"].ToString(), dr["Column2"].ToString());
                                    //Console.WriteLine(dr["Column2"].ToString());
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();

                                }
                                //Console.WriteLine(table.Rows[2][1]);


                                //DataRow hi =  new result.Tables[2].Rows[2];
                                // The result of each spreadsheet is in result.Tables
                            }
                        file.Close();
                        }
                    }
                
            }
        }
        
        public static BoatsRacing converter1(Boats boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat1, boat.boatNumber1);
            return racer1;
        }
        public static BoatsRacing converter2(Boats boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat2, boat.boatNumber2);
            return racer1;
        }
        public static BoatsRacing converter3(Boats boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat3, boat.boatNumber3);
            return racer1;
        }
        public static BoatsRacing converter4(Boats boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat4, boat.boatNumber4);
            return racer1;
        }
        public static BoatsRacing converter5(Boats boat)
        {
            BoatsRacing racer1 = new BoatsRacing(boat.name, boat.boat5, boat.boatNumber5);
            return racer1;
        }
        public static Dictionary<string, BoatsRacing> loadRaceFile(Dictionary<string, BoatsRacing> raceDictionary, string path)
        {
            StreamReader reader = System.IO.File.OpenText(@path + @"\Race List.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(char.Parse(", "));
                Console.WriteLine("{0}, {1}, {2}", items[0], items[1], items[2]);
                BoatsRacing boat1 = new BoatsRacing(items[0], items[1], int.Parse(items[2]));


                raceDictionary.Add(items[0], boat1);


            }
            reader.Close();
            return raceDictionary;
        }
        public static Dictionary<string, Boats> LoadFullFile(string path)
        //public static string LoadFullFile()
        {
            StreamReader reader = System.IO.File.OpenText(@path+@"\Full List.txt");
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



        static void Main(string[] args)
        {


            //Boats boat1 = new Boats("Adrian Stanislaus", 2, "Laser Stratos", 927, "Laser", 182782);
            //Boats boat2 = new Boats("Luke Stanislaus", 1, "Laser Stratos", 182782, null, 0);
            //Boats boat3 = new Boats("Simon Clark", 2, "Phantom", 1080, "Laser", 1234);
            Dictionary<string, Boats> boatDictionary = new Dictionary<string, Boats>();
            Dictionary<string, BoatsRacing> raceDictionary = new Dictionary<string, BoatsRacing>();
            //boatDictionary.Add("hi", boat1);
            Console.WriteLine("Enter path to folder of files");
            string path = Console.ReadLine();
            LoadFullExcel(path);
            boatDictionary = LoadFullFile(path);
            //Console.WriteLine(boatDictionary["Adrian Stanislaus"].boat1);
            //string hi = LoadFullFile();
            //Console.WriteLine(boatDictionary["Abc"].name);
            //boatDictionary.Add(boat1.name, boat1);
            //boatDictionary.Add(boat2.name, boat2);
            //boatDictionary.Add(boat3.name, boat3);


            while (true)
            {
                Console.WriteLine("Who is it?");
                string person = Console.ReadLine();
                try
                {

                    while (person == boatDictionary[person].name)
                    {

                        if (boatDictionary[person].noOfBoats > 0)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat1);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {

                                raceDictionary.Add(boatDictionary[person].name, converter1(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + raceDictionary[person].boatName);
                                Console.ReadLine();
                                // Create a file to write to.
                                using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

                            }
                            else if (boatDictionary[person].noOfBoats == 1)
                            {
                                Console.Clear();
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@path + @"\Full List.txt", true))
                                    {
                                        file.WriteLine("\n{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(path);
                                    //string hi1 = LoadFullFile();
                                    Console.Clear();
                                }

                            }
                        }
                        if (boatDictionary[person].noOfBoats > 1)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat2);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, converter2(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + raceDictionary[person].boatName);
                                Console.ReadLine();
                                // Create a file to write to.
                                string[] lines = System.IO.File.ReadAllLines(path);
                                int thing = Array.IndexOf(lines, person);
                                Console.WriteLine(thing);


                                using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
                                {

                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

                            }
                            else if (boatDictionary[person].noOfBoats == 2)
                            {
                                Console.Clear();
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@path + @"\Full List.txt", true))
                                    {
                                        file.WriteLine("{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(path);
                                    //string hi1 = LoadFullFile();
                                    Console.Clear();
                                }

                            }
                        }
                        if (boatDictionary[person].noOfBoats > 2)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat3);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, converter3(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + raceDictionary[person].boatName);
                                Console.ReadLine();
                                // Create a file to write to.
                                using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

                            }
                            else if (boatDictionary[person].noOfBoats == 3)
                            {
                                Console.Clear();
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@path + @"\Full List.txt", true))
                                    {
                                        file.WriteLine("{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(path);
                                    //string hi1 = LoadFullFile();
                                    Console.Clear();
                                }

                            }
                        }
                        if (boatDictionary[person].noOfBoats > 3)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat4);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, converter4(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + raceDictionary[person].boatName);
                                Console.ReadLine();
                                // Create a file to write to.
                                using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

                            }
                            else if (boatDictionary[person].noOfBoats == 4)
                            {
                                Console.Clear();
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@path + @"\Full List.txt", true))
                                    {
                                        file.WriteLine("{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(path);
                                    //string hi1 = LoadFullFile();
                                    Console.Clear();
                                }

                            }

                        }
                        if (boatDictionary[person].noOfBoats > 4)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat5);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, converter5(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + raceDictionary[person].boatName);
                                Console.ReadLine();
                                // Create a file to write to.
                                using (StreamWriter sw = System.IO.File.AppendText(@path + @"\Race List.txt"))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;


                            }
                            else if (boatDictionary[person].noOfBoats == 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@path + @"\Full List.txt", true))
                                    {
                                        file.WriteLine("{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    //Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(path);
                                    //string hi1 = LoadFullFile();
                                    Console.Clear();
                                }

                            }

                        }
                        Console.Clear();
                    }
                }

                catch (KeyNotFoundException)
                {

                    Console.WriteLine("Your name, "+ person +", is not in my records, would you like to add it?(y/n)");
                    string response = Console.ReadLine();
                    if (string.Equals(response, "y"))
                    {
                        Console.WriteLine("Please re-enter your name, capitalised how you want it.");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please enter the number of boats you have.");
                        int noOfBoats = int.Parse(Console.ReadLine());
                        for (int i = 0; i < noOfBoats; i++)
                        {
                            Console.WriteLine("Enter the name of boat {0}", i);
                            string boat = Console.ReadLine();
                            Console.Write("Enter the boat number of boat {0}", i);
                            int boatNumber = int.Parse(Console.ReadLine());
                            using (StreamWriter file =
    new StreamWriter(@"c:\temp\Full List.txt", true))
                            {
                                file.WriteLine("{0}\t{1}\t{2}", name, boatNumber, boat);


                            }


                        }
                    }
                }
                //Dictionary<string, Boats> nothing = new Dictionary<string, Boats>();
                boatDictionary = LoadFullFile(path);
                //string hi2 = LoadFullFile();
                Console.Clear();
            }

        }

    }

    public class BoatsRacing
    {
        public string name { get; set; }
        public string boatName { get; set; }
        public int boatNumber { get; set; }

        public BoatsRacing(string Name, string Boat, int BoatNumber)
        {
            name = Name;
            boatName = Boat;
            boatNumber = BoatNumber;


        }
    }

    public class Boats
    {
        public string name { get; set; }
        public int noOfBoats { get; set; }
        public string boat1 { get; set; }
        public int boatNumber1 { get; set; }
        public string boat2 { get; set; }
        public int boatNumber2 { get; set; }
        public string boat3 { get; set; }
        public int boatNumber3 { get; set; }
        public string boat4 { get; set; }
        public int boatNumber4 { get; set; }
        public string boat5 { get; set; }
        public int boatNumber5 { get; set; }

        public Boats(string Name, string Boat1, int BoatNumber1)
        {
            name = Name;
            noOfBoats = 1;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;


        }
        public Boats(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2)
        {
            name = Name;
            noOfBoats = 2;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;



        }
        public Boats(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3)
        {
            name = Name;
            noOfBoats = 3;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;


        }
        public Boats(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4)
        {
            name = Name;
            noOfBoats = 4;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;


        }
        public Boats(string Name, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4,
        string Boat5, int BoatNumber5)
        {
            name = Name;
            noOfBoats = 5;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;
            boat5 = Boat5;
            boatNumber5 = BoatNumber5;

        }





    }
    public class BoatsFromExcel
    {
        public string name { get; set; }
        public int boatNumber { get; set; }
        public string boat { get; set; }
        public BoatsFromExcel(string Name, int BoatNumber, string Boat)
        {
            name = Name;
            boatNumber = BoatNumber;
            boat = Boat;

        }
    }
}

