using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Sailing2
{
    public class LoadFullSQL
    {
        
        public static Dictionary<string, Boats> getdictionary(List<Boats> list)
        {
            Dictionary<string, Boats> boatDictionary = new Dictionary<string, Boats>();
            foreach (var boat in list)
            {
                boatDictionary.Add(boat.name, boat);
            }
            return boatDictionary;
        }
        public void Addboat(string name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query($"update fulllist set '{ name }'");
            }
        }

        public Boats GetBoat(string name)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                string fullname;
                string sql = "call returnboat('" + name + "')";
                var obj =  connection.Query<Boats>(sql).First();
                return obj;
                //return connection.Query<Boats>("returnboat @fullname", new { fullname = name }).First();
            }
        }
        public List<Boats> GetBoats()
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                return connection.Query<Boats>("select * from fulllist").ToList();

            }
        }
        public static void AddPerson(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query<Boats>($"insert into fulllist values('{ Name }', '{ NoOfBoats }', '{ Boat1 }', '{ BoatNumber1 }'");
            }
        }
        public static void AddPerson(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1,
System.String Boat2, System.Int32 BoatNumber2)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query<Boats>($"insert into fulllist values('{ Name }', '{ NoOfBoats }', '{ Boat1 }', '{ BoatNumber1 }', " +
                    $"'{ Boat2 }', '{ BoatNumber2 }'");
            }
        }
        public static void AddPerson(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1,
System.String Boat2, System.Int32 BoatNumber2, System.String Boat3, System.Int32 BoatNumber3)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query<Boats>($"insert into fulllist values('{ Name }', '{ NoOfBoats }', '{ Boat1 }', '{ BoatNumber1 }', " +
                    $"'{ Boat2 }', '{ BoatNumber2 }', '{ Boat3 }', '{ BoatNumber3 }'");
            }
        }
        public static void AddPerson(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1,
System.String Boat2, System.Int32 BoatNumber2, System.String Boat3, System.Int32 BoatNumber3,
System.String Boat4, System.Int32 BoatNumber4)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query<Boats>($"insert into fulllist values('{ Name }', { NoOfBoats }', { Boat1 }', { BoatNumber1 }', " +
                    $"{ Boat2 }', { BoatNumber2 }', { Boat3 }', { BoatNumber3 }', { Boat4 }', { BoatNumber4 }'");
            }
        }
        public static void AddPerson(System.String Name, System.Int32 NoOfBoats, System.String Boat1, System.Int32 BoatNumber1,
System.String Boat2, System.Int32 BoatNumber2, System.String Boat3, System.Int32 BoatNumber3,
System.String Boat4, System.Int32 BoatNumber4, System.String Boat5, System.Int32 BoatNumber5)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.CnnVal("sailingDB")))
            {
                connection.Query<Boats>($"insert into fulllist values('{ Name }', { NoOfBoats }', { Boat1 }', { BoatNumber1 }', " +
                    $"{ Boat2 }', { BoatNumber2 }', { Boat3 }', { BoatNumber3 }', { Boat4 }', { BoatNumber4 }', { Boat5 }', " +
                    $"{ BoatNumber5 }'");
            }
        }
    }
}
