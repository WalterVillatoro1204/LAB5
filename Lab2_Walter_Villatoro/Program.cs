using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;


namespace ReadJson
{
    class Program
    {

        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\wally\Desktop\LAB5\Lab2_Walter_Villatoro\bin\Debug\netcoreapp3.1\input_challenge_lab_2.jsonl"))
            {

                InputLab input = JsonSerializer.Deserialize<InputLab>(line);

                var algo = input.input1;
                var algo1 = input.input2;

                Dictionary<string, double> sortApartments = new Dictionary<string, double>();
                Dictionary<string, double> sortHouses = new Dictionary<string, double>();
                Dictionary<string, double> sortPremises = new Dictionary<string, double>();

                if (input.input2.typeBuilder == "Apartments")
                {
                    foreach (var itemApartments in input.input1)
                    {
                        if (itemApartments.builds.Apartments != null)
                        {
                            foreach (var item1Apartments in itemApartments.builds.Apartments)
                            {
                                if (input.input2.wannaPetFriendly == item1Apartments.isPetFriendly)
                                {
                                    if (input.input2.wannaPetFriendly == true) //desea mascota
                                    {
                                        if (item1Apartments.price < input.input2.budget)
                                        {
                                            sortApartments.Add(item1Apartments.id, item1Apartments.price);
                                        }
                                        else { }
                                    }
                                    else  //no desea mascota
                                    {
                                        if (item1Apartments.price < input.input2.budget)
                                        {
                                            sortApartments.Add(item1Apartments.id, item1Apartments.price);
                                        }
                                        else { }
                                    }
                                }
                            }
                        }
                    }

                    var itemsApartments = from pair in sortApartments orderby pair.Value ascending select pair;

                    foreach (var itemSorted in itemsApartments)
                    {
                        Console.Write("[ " + itemSorted.Key + " ]" + ",");
                    }
                    Console.Write("\n");

                }
                else if (input.input2.typeBuilder == "Houses")
                {
                    foreach (var itemHouses in input.input1)
                    {
                        if (itemHouses.builds.Houses != null)
                        {
                            foreach (var item1Houses in itemHouses.builds.Houses)
                            {
                                if (input.input2.minDanger == "Red")
                                {
                                    if (item1Houses.price < input.input2.budget)
                                    {
                                        sortHouses.Add(item1Houses.id, item1Houses.price);
                                    }
                                    else { }
                                }
                                else if (input.input2.minDanger == "Orange")
                                {
                                    if (item1Houses.zoneDangerous == "Red")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Orange")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                }
                                else if (input.input2.minDanger == "Yellow")
                                {
                                    if (item1Houses.zoneDangerous == "Red")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Orange")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Yellow")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                }
                                else if (input.input2.minDanger == "Green")
                                {
                                    if (item1Houses.zoneDangerous == "Red")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Orange")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Yellow")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                    else if (item1Houses.zoneDangerous == "Green")
                                    {
                                        if (item1Houses.price < input.input2.budget)
                                        {
                                            sortHouses.Add(item1Houses.id, item1Houses.price);
                                        }
                                        else { }
                                    }
                                }
                            }
                        }

                    }

                    var itemsOrdenadosHouses = from pair in sortHouses orderby pair.Value ascending select pair;

                    foreach (var itemSortedHouses in itemsOrdenadosHouses)
                    {
                        Console.Write("[ " + itemSortedHouses.Key + " ]" + ",");
                    }

                    Console.Write("\n");

                }

            }
    }


   public class House
    {
        public string zoneDangerous { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Apartment
    {
        public bool isPetFriendly { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Premise
    {
        public string[] commercialActivities { get; set; }
        public string address { get; set; }
        public double price { get; set; }
        public string contactPhone { get; set; }
        public string id { get; set; }
    }
    public class Builds
    {
        public Premise[]? Premises { get; set; }
        public Apartment[]? Apartments { get; set; }
        public House[]? Houses { get; set; }
    }
    public class Input1
    {
        public Dictionary<string, bool> services { get; set; }
        public Builds builds { get; set; }

    }
    public class Input2
    {
        public double budget { get; set; }
        public string typeBuilder { get; set; }
        public string[] requiredServices { get; set; }
        public string? commercialActivity { get; set; }
        public bool? wannaPetFriendly { get; set; }
        public string? minDanger { get; set; }
    }
    public class InputLab
    {
        public Input1[] input1 { get; set; }
        public Input2 input2 { get; set; }
    }

}
