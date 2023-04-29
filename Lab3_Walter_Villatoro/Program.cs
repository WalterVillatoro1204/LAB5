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
using System.Linq;

namespace Lab3_Walter_Villatoro
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<User> Usuario = new List<User>();
            Acciones Actions;

            string path = "C:\\Users\\wally\\Desktop\\LAB5\\Lab3_Walter_Villatoro\\bin\\Debug\\netcoreapp3.1\\input_customer_challenge_lab_3.jsonl";
            string path1 = "C:\\Users\\wally\\Desktop\\LAB5\\Lab3_Walter_Villatoro\\bin\\Debug\\netcoreapp3.1\\Costumer.JSONL";
            using (StreamReader leer = new StreamReader(path))
            {
                while (!leer.EndOfStream)
                {
                    string linea = leer.ReadLine();
                    User persona = new User();
                    persona = JsonConvert.DeserializeObject<User>(linea);
                    Usuario.Add(persona);
                }
            }
            //deserializar los datos de la direccion2
            using (StreamReader leer = new StreamReader(path1))
            {
                string linea = leer.ReadToEnd();
                Actions = JsonConvert.DeserializeObject<Acciones>(linea);
            }

            long[] DPI = Enumerable.Repeat(0L, Actions.Customers.Count).ToArray();
            int[] BUDGETS = Actions.Customers.Select(c => c.Budget).ToArray();
            int posicion = 0;

            foreach (var item in Actions.Customers)
            {
                DPI[posicion] = item.DPI;
                posicion++;
            }
            posicion = 0;
            foreach (var item in Actions.Customers)
            {
                BUDGETS[posicion] = item.Budget;
                posicion++;
            }
            for (int i = 0; i < DPI.Length - 1; i++)
            {
                for (int j = 0; j < DPI.Length - (1 + i); j++)
                {
                    if (BUDGETS[j] < BUDGETS[j + 1])
                    {
                        // Intercambiamos los elementos "BUDGETS" en las posiciones j y j+1
                        int tempBudget = BUDGETS[j];
                        BUDGETS[j] = BUDGETS[j + 1];
                        BUDGETS[j + 1] = tempBudget;

                        // Intercambiamos los elementos "DPI" en las posiciones j y j+1
                        long tempDPI = DPI[j];
                        DPI[j] = DPI[j + 1];
                        DPI[j + 1] = tempDPI;
                    }
                }
            }
            long Ganador = DPI[Actions.Rejection];
            int budgetGanador = default;
            DateTime FechaGanador = new DateTime();




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




