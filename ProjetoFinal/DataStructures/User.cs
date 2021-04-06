using System;

namespace ProjetoFinal.DataStructures
{
    public class User
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string Zip { get; private set; }
        public string MobilePhone { get; private set; }

        public User()
        {
            FirstName = "Ethan";
            LastName = "Smith";
            Email = $"{Guid.NewGuid()}@hotmail.com";
            Password = "12345";
            Address = "TX-8 Beltway";
            City = "Houston";
            State = "Texas";
            Country = "United States";
            Zip = "00009";
            MobilePhone = "995847602";
        }
    }
}
