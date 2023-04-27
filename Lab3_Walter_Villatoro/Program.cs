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
            foreach (string line in System.IO.File.ReadLines(@"C:\Users\wally\Desktop\Lab3_Walter_Villatoro\bin\Debug\netcoreapp3.1\input_auctions_example_lab_3.jsonl"))
            {

                Json input = JsonSerializer.Deserialize<Json>Convert.ToString((line));

            }
        }
    }

    public partial class Json
    {
        [JsonProperty("property")]
        public string Property { get; set; }

        [JsonProperty("customers")]
        public Customer[] Customers { get; set; }

        [JsonProperty("rejection")]
        public long Rejection { get; set; }
    }

    public partial class Customer
    {
        [JsonProperty("dpi")]
        public long Dpi { get; set; }

        [JsonProperty("budget")]
        public long Budget { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
    }

    public partial class Json1
    {
        public static Json1 FromJson(string json) => JsonConvert.DeserializeObject<Json1>(json, Lab3_Walter_Villatoro.Converter.Settings);
    }

    public class InputLab
    {
        public Json[] input1 { get; set; }
        public Customer input2 { get; set; }
    }



    public static class Serialize
    {
        public static string ToJson(this Json1 self) => JsonConvert.SerializeObject(self, Lab3_Walter_Villatoro.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}




