using System;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using static Lab3_Walter_Villatoro.Program;
using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

namespace Lab3_Walter_Villatoro
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> Usuario = new List<User>();
            Acciones Actions;
            string direccion = "";
            string direccion2 = "";
            using (StreamReader leer = new StreamReader(direccion))
            {
                while (!leer.EndOfStream)
                {
                    string linea = leer.ReadLine();
                    User persona = new User();
                    persona = JsonConvert.DeserializeObject<User>(linea);
                    Usuario.Add(persona);
                }
            }
 

        }
    }

    public class User
    {
        public long DPI { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Job { get; set; }
        public string PlaceJob { get; set; }
        public int Salary { get; set; }
    }


    public class Customer
    {
        public long DPI { get; set; }
        public int Budget { get; set; }
        public DateTime Date { get; set; }
    }

    public class Acciones
    {
        public string? Property { get; set; }
        public List<Customer>? Customers { get; set; }
        public int Rejection { get; set; }
    }
    
}




