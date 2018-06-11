using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using Microsoft;
using System.Windows.Input;
using System.Linq;
using System.Data;
using ExcelDataReader;
using System.Data.OleDb;
using Sailing2;

namespace Sailing
{

    class Program
    { 
        static void Main(string[] args)
        {
            List<Boats> boatlist = new List<Boats>();
            //Boats boat1 = new Boats("Adrian Stanislaus", 2, "Laser Stratos", 927, "Laser", 182782);
            //Boats boat2 = new Boats("Luke Stanislaus", 1, "Laser Stratos", 182782, null, 0);
            //Boats boat3 = new Boats("Simon Clark", 2, "Phantom", 1080, "Laser", 1234);
            Dictionary<string, Boats> boatDictionary = new Dictionary<string, Boats>();
            Dictionary<string, BoatsRacing> raceDictionary = new Dictionary<string, BoatsRacing>();
            //Console.WriteLine("Enter path to folder of files");
            string[] path1 = System.Reflection.Assembly.GetEntryAssembly().Location.Split(char.Parse(@"\"));
            string path = "";
            int b = 0;
            while (path1[b] != "Sailing2")
            {
                path = string.Concat(path + path1[b] + @"\");
                b++;
            }
            //string path2 = path.Split(path)
            Console.WriteLine("Enter name");
            string name1 = Console.ReadLine();
            LoadFullSQL db = new LoadFullSQL();
            boatlist = db.GetBoats();
            Console.WriteLine(db.GetBoat(name1).boat1);
            boatDictionary = LoadFullSQL.getdictionary(boatlist);
            //boatDictionary = LoadFullFile.loadFullFile(path);
            //Console.WriteLine(boatDictionary["Adrian Stanislaus"].boat1);
            //string hi = LoadFullFile();
            //Console.WriteLine(boatDictionary["Abc"].name);
            //boatDictionary.Add(boat1.name, boat1);
            //boatDictionary.Add(boat2.name, boat2);
            //boatDictionary.Add(boat3.name, boat3);
            //LoadFullFile.ExportToFile(boatDictionary, path);

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

                                raceDictionary.Add(boatDictionary[person].name, BoatsRacing.converter1(boatDictionary[person]));
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
                                Boats.Addboats(response, path, person, boatDictionary);
                                boatDictionary = LoadFullFile.loadFullFile(path);
                            }
                        }
                        if (boatDictionary[person].noOfBoats > 1)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat2);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, BoatsRacing.converter2(boatDictionary[person]));
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
                                Boats.Addboats(response, path, person, boatDictionary);
                                boatDictionary = LoadFullFile.loadFullFile(path);
                            }
                        }
                        if (boatDictionary[person].noOfBoats > 2)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat3);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, BoatsRacing.converter3(boatDictionary[person]));
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
                                Boats.Addboats(response, path, person, boatDictionary);
                                boatDictionary = LoadFullFile.loadFullFile(path);
                            }
                        }
                        if (boatDictionary[person].noOfBoats > 3)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat4);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, BoatsRacing.converter4(boatDictionary[person]));
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
                                Boats.Addboats(response, path, person, boatDictionary);
                                boatDictionary = LoadFullFile.loadFullFile(path);
                            }

                        }
                        if (boatDictionary[person].noOfBoats > 4)
                        {
                            Console.WriteLine("Is your boat a(n) {0}, T/F?", boatDictionary[person].boat5);
                            string response = Console.ReadLine();
                            if (response == "T" || response == "t")
                            {
                                raceDictionary.Add(boatDictionary[person].name, BoatsRacing.converter5(boatDictionary[person]));
                                Console.WriteLine(raceDictionary[person].name + " is racing a(n) " + 
                                    raceDictionary[person].boatName);
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
                                Boats.Addboats(response, path, person, boatDictionary);
                                boatDictionary = LoadFullFile.loadFullFile(path);
                            }

                        }
                        Console.Clear();
                    }
                }

                catch (KeyNotFoundException)
                {

                    Console.WriteLine("Your name, " + person + ", is not in my records, would you like to add it?(y/n)");
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
                                //LoadFullSQL.AddPerson()

                            }


                        }
                    }
                }
                //Dictionary<string, Boats> nothing = new Dictionary<string, Boats>();
                boatDictionary = LoadFullFile.loadFullFile(path);
                //string hi2 = LoadFullFile();
                Console.Clear();
            }

        }
    }
}

