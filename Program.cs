using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace MAYO28
{
    public class Person
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("Age")]
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:/Users/gd251/source/repos/MAYO28/bin/Debug/archivo.JSON";
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"El archivo '{filePath}' no se encontro.");
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
                return;
            }
            try
            {
                Person person = JsonSerializer.Deserialize<Person>(jsonString);
                //Imprimir los valores del objeto
                Console.WriteLine($"Nombre: {person.FirstName}");
                Console.WriteLine($"Apellido: {person.LastName}");
                Console.WriteLine($"Edad: {person.Age}");
                Console.ReadKey();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error al deserializar: {ex.Message}");
            }
            
            }
        }
    }

