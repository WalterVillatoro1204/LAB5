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
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\wally\Desktop\Url\EstructurasLAB\Lab2_Walter_Villatoro\bin\Debug\netcoreapp3.1\input_challenge_lab_2.jsonl"))
            {

                InputLab input = JsonSerializer.Deserialize<InputLab>(line);

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
