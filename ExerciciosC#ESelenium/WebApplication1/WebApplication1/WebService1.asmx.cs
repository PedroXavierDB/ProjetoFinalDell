using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        // ajustar para o caminho do json na máquina de vocês
        private string _jsonFile = @"C:\Users\pedro.xavier\source\repos\WebApplication1\WebApplication1\data\contacts.json";

        [WebMethod]
        public Contact[] GetContacts()
        {
            var data = this.LoadJson();
            return data.ToArray();
        }

        [WebMethod]
        public Contact GetContact(int id)
        {
            var data = this.LoadJson();
            var contact = data.FirstOrDefault(c => c.Id == id);
            return contact;
        }

        private List<Contact> LoadJson()
        {
            var jsonString = string.Empty;
            using (var fs = new FileStream(_jsonFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    jsonString = sr.ReadToEnd();
                    sr.BaseStream.Flush();
                }
            }

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(jsonString);
            return data;
        }
    }

    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public float Salary { get; set; }
    }
}
