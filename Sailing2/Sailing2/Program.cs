using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft;
using System.Windows.Input;
using System.Linq;

namespace Sailing
{

    class Program
    {
//C:\Users\Luke\Documents\GitHub\test-sailing\Sailing2\Sailing2\Program.cs
        /*
        public static void Main2( )
        {
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }
        */
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
        // public static Boats Exceltoc(BoatsFromExcel boat)
        //   {

        //   return Boats;
        // }
        public static Dictionary<string, BoatsRacing> loadRaceFile(Dictionary<string, BoatsRacing> raceDictionary)
        {
            StreamReader reader = System.IO.File.OpenText(@"c:\temp\Race List.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(char.Parse(", "));
                Console.WriteLine("{0}, {1}, {2}", items[0], items[1], items[2]);
                BoatsRacing boat1 = new BoatsRacing(items[0], items[1], int.Parse(items[2]));


                raceDictionary.Add(items[0], boat1);

                //int myInteger = int.Parse(items[1]);

            }
            reader.Close();
            return raceDictionary;
        }
        public static Dictionary<string, Boats> LoadFullFile(Dictionary<string, Boats> boatDictionary)
        {
            StreamReader reader = System.IO.File.OpenText(@"c:\temp\Full List.txt");
            string line;
            Dictionary<int, BoatsFromExcel> BoatDictionaryInterim = new Dictionary<int, BoatsFromExcel>();
            //BoatsFromExcel hi = new BoatsFromExcel("hi", 12, "ho");
            //BoatDictionaryInterim.Add("hi", hi);
            int count1 = 0;
            while ((line = reader.ReadLine()) != null)

            {
                //Dictionary<string, BoatsFromExcel> BoatDictionaryInterim = new Dictionary<string, BoatsFromExcel>();

                string[] items = line.Split(char.Parse("\n"));
                //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}",
                //    items[0], items[1], items[2], items[3], items[4], items[5], items[6],
                //    items[7], items[8], items[9], items[10], items[11]);
                //Boats boat1 = new Boats(items[0], int.Parse(items[1]), items[2], int.Parse(items[3]), items[4],
                //int.Parse(items[5]), items[6], int.Parse(items[7]), items[8], int.Parse(items[9]),
                //items[10], int.Parse(items[11]));
                while ((line = reader.ReadLine()) != null)
                {
                    string[] items1 = line.Split('\t');
                    //Console.WriteLine("{0}, {1}, {2}", items1[0], int.Parse(items1[1]), items1[2]);
                    BoatsFromExcel boat1 = new BoatsFromExcel(items1[0], int.Parse(items1[1]), items1[2]);
                    BoatDictionaryInterim.Add(count1, boat1);
                    count1++;
                    // Now let's find the path.
                    /*
                    foreach (string item in items1)
                    {
                        if (!string.IsNullOrWhiteSpace(item))
                        {
                            string path = item;
                            
                        }
                      count++;
                    }
                    */

                    // At this point, `myInteger` and `path` contain the values we want
                    // for the current line. 
                }


                //BoatDictionaryInterim.Add("hi", hi);
                //int myInteger = int.Parse(items[1]);


            }
            //Turn BoatsFromExcel type to Boats:
            List<string> names = new List<string>();
            //while ((BoatDictionaryInterim[count] != null))
            for (int b = 0; b < count1; b++)
            {
                names.Add(BoatDictionaryInterim[b].name);
            }

            int distinctCount = names.Distinct().Count();

            int i = 0;
            try
            {
                while (i < names.Count())
                {
                    int noOfBoats = 0;

                    if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
            string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name) &&
            string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 3].name) &&
            string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 4].name))
                    {
                        noOfBoats += 5;
                        for (int b = 0; b < noOfBoats; b++)
                        {
                            Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                            boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);
                        }
                    }
                    else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
    string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name) &&
    string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 3].name))
                    {
                        noOfBoats += 4;
                        for (int b = 0; b < noOfBoats; b++)
                        {
                            Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                            boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);
                        }
                    }
                    else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
    string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name))
                    {
                        noOfBoats += 3;

                        Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                            BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                            BoatDictionaryInterim[i + 1].boatNumber, BoatDictionaryInterim[i + 2].boat,
                            BoatDictionaryInterim[i + 2].boatNumber);
                        boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                    }
                    else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name))
                    {
                        noOfBoats += 2;

                        Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                            BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                            BoatDictionaryInterim[i + 1].boatNumber);
                        boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                    }
                    else
                    {
                        noOfBoats++;

                        Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                        boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                    }

                    i += noOfBoats;




                }
            }
            catch
            {
                try
                {
                    while (i < names.Count())
                    {
                        int noOfBoats = 0;

                        if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
       string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name) &&
       string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 3].name))
                        {
                            noOfBoats += 4;
                            for (int b = 0; b < noOfBoats; b++)
                            {
                                Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                                boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);
                            }
                        }
                        else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
        string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name))
                        {
                            noOfBoats += 3;

                            Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                                BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                                BoatDictionaryInterim[i + 1].boatNumber, BoatDictionaryInterim[i + 2].boat,
                                BoatDictionaryInterim[i + 2].boatNumber);
                            boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                        }
                        else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name))
                        {
                            noOfBoats += 2;

                            Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                                BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                                BoatDictionaryInterim[i + 1].boatNumber);
                            boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                        }
                        else
                        {
                            noOfBoats++;

                            Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                            boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                        }

                        i += noOfBoats;




                    }
                }
                catch
                {
                    try
                    {
                        while (i < names.Count())
                        {
                            int noOfBoats = 0;

                            if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name) &&
            string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 2].name))
                            {
                                noOfBoats += 3;

                                Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                                    BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                                    BoatDictionaryInterim[i + 1].boatNumber, BoatDictionaryInterim[i + 2].boat,
                                    BoatDictionaryInterim[i + 2].boatNumber);
                                boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                            }
                            else if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name))
                            {
                                noOfBoats += 2;

                                Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                                    BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                                    BoatDictionaryInterim[i + 1].boatNumber);
                                boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                            }
                            else
                            {
                                noOfBoats++;

                                Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                                boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                            }

                            i += noOfBoats;




                        }
                    }
                    catch
                    {
                        try
                        {
                            while (i < names.Count())
                            {
                                int noOfBoats = 0;

                                if (string.Equals(BoatDictionaryInterim[i].name, BoatDictionaryInterim[i + 1].name))
                                {
                                    noOfBoats += 2;

                                    Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat,
                                        BoatDictionaryInterim[i].boatNumber, BoatDictionaryInterim[i + 1].boat,
                                        BoatDictionaryInterim[i + 1].boatNumber);
                                    boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                                }
                                else
                                {
                                    noOfBoats++;

                                    Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                                    boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);

                                }

                                i += noOfBoats;




                            }
                        }
                        catch
                        {
                            while (i < names.Count())
                            {
                                int noOfBoats = 0;

                                noOfBoats++;

                                Boats boat1 = new Boats(BoatDictionaryInterim[i].name, noOfBoats, BoatDictionaryInterim[i].boat, BoatDictionaryInterim[i].boatNumber);
                                boatDictionary.Add(BoatDictionaryInterim[i].name, boat1);



                                i += noOfBoats;




                            }
                        }
                    }





                }
            }
            reader.Close();
            return boatDictionary;
        }



        static void Main(string[] args)
        {


            //Boats boat1 = new Boats("Adrian Stanislaus", 2, "Laser Stratos", 927, "Laser", 182782);
            //Boats boat2 = new Boats("Luke Stanislaus", 1, "Laser Stratos", 182782, null, 0);
            //Boats boat3 = new Boats("Simon Clark", 2, "Phantom", 1080, "Laser", 1234);
            Dictionary<string, Boats> boatDictionary = new Dictionary<string, Boats>();
            Dictionary<string, BoatsRacing> raceDictionary = new Dictionary<string, BoatsRacing>();
            //boatDictionary.Add("hi", boat1);

            boatDictionary = LoadFullFile(boatDictionary);
            //Console.WriteLine(boatDictionary["Abc"].name);
            //boatDictionary.Add(boat1.name, boat1);
            //boatDictionary.Add(boat2.name, boat2);
            //boatDictionary.Add(boat3.name, boat3);
            string path = @"c:\temp\Race List.txt";


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
                                using (StreamWriter sw = System.IO.File.AppendText(path))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

                            }
                            if (boatDictionary[person].noOfBoats == 1)
                            {
                                Console.WriteLine("Would you like to add a boat? y/n");
                                response = Console.ReadLine();
                                if (response == "y")
                                {
                                    Console.WriteLine("Enter the name of the boat");
                                    string boat = Console.ReadLine();
                                    Console.Write("Enter the boat number of the boat ");
                                    int boatNumber = int.Parse(Console.ReadLine());
                                    using (StreamWriter file =
            new StreamWriter(@"c:\temp\Full List.txt", true))
                                    {
                                        file.WriteLine("\n{0}\t{1}\t{2}", person, boatNumber, boat);

                                    }
                                    Dictionary<string, Boats> nothing1 = new Dictionary<string, Boats>();
                                    boatDictionary = LoadFullFile(nothing1);
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


                                using (StreamWriter sw = System.IO.File.AppendText(path))
                                {

                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

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
                                using (StreamWriter sw = System.IO.File.AppendText(path))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

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
                                using (StreamWriter sw = System.IO.File.AppendText(path))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;

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
                                using (StreamWriter sw = System.IO.File.AppendText(path))
                                {
                                    sw.WriteLine("{0}, {1}, {2}", raceDictionary[person].name,
                                        raceDictionary[person].boatName,
                                        raceDictionary[person].boatNumber);
                                }
                                break;


                            }

                        }
                        Console.Clear();
                    }
                }

                catch
                {

                    Console.WriteLine("me is not in my records, would you like to add it?(y/n)");
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
                Dictionary<string, Boats> nothing = new Dictionary<string, Boats>();
                boatDictionary = LoadFullFile(nothing);
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

        public Boats(string Name, int NoOfBoats, string Boat1, int BoatNumber1)
        {
            name = Name;
            noOfBoats = NoOfBoats;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;


        }
        public Boats(string Name, int NoOfBoats, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2)
        {
            name = Name;
            noOfBoats = NoOfBoats;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;



        }
        public Boats(string Name, int NoOfBoats, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3)
        {
            name = Name;
            noOfBoats = NoOfBoats;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;


        }
        public Boats(string Name, int NoOfBoats, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4)
        {
            name = Name;
            noOfBoats = NoOfBoats;
            boat1 = Boat1;
            boatNumber1 = BoatNumber1;
            boat2 = Boat2;
            boatNumber2 = BoatNumber2;
            boat3 = Boat3;
            boatNumber3 = BoatNumber3;
            boat4 = Boat4;
            boatNumber4 = BoatNumber4;


        }
        public Boats(string Name, int NoOfBoats, string Boat1, int BoatNumber1, string Boat2,
        int BoatNumber2, string Boat3, int BoatNumber3, string Boat4, int BoatNumber4,
        string Boat5, int BoatNumber5)
        {
            name = Name;
            noOfBoats = NoOfBoats;
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

