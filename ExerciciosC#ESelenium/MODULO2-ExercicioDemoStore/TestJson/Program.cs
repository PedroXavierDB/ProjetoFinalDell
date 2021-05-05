using MODULO2_ExercicioDemoStore.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace TestJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //string jsonFromFile;
            //using (var reader = new StreamReader(@"C:\Users\pedro.xavier\source\repos\MODULO2-ExercicioDemoStore\TestJson\file.json"))
            //{
            //    jsonFromFile = reader.ReadToEnd();
            //}
            //List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonFromFile);
            // JArray json = JArray.Parse(jsonFromFile);

            //Console.WriteLine(jsonFromFile);
            //Console.WriteLine(users[0].FirstName);
            //Console.WriteLine(users[1].FirstName);

            //Console.WriteLine(user.FirstName);
            //Console.WriteLine(user.LastName);
            //Console.WriteLine(user.PhoneNumber);
            //Console.WriteLine(user.Email);
            //Console.WriteLine(user.Password);
            //Console.WriteLine(user.Birthdate);

            string aux = "form[name=\"Pedro\"]";
            Console.WriteLine(aux);

            Console.ReadLine();
        }
    }
}
