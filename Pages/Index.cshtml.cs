using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;
using SiteClients.Model;
using System;
using System.Net;
using System.Text.Json;

namespace SiteClients.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        public string Host { get; set; }
        public readonly string Clients = "/clientController";

        public List<Person> Persons { get; set; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            Host = Environment.GetEnvironmentVariable("DBIP") ?? "http://localhost:3000";
          
            _logger = logger;
            Persons = new List<Person>();

            InitClients(Host + Clients);
            Console.WriteLine("Load Index Page");
        }
        
        private void InitClients(string url)
        {
            string json = GetJsonClients(url);
            var persons = JsonToClients(json);

            Persons = persons ?? Persons;
        }

        private string GetJsonClients(string url)
        {
            WebRequest request = WebRequest.Create(url);
            Stream stream;
            try
            {
                stream = request.GetResponse().GetResponseStream();
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
            catch
            {
                return "[]";
            }
        }

        private List<Person> JsonToClients(string json)
        {
            PersonString[]? personsString;

            try
            {
              
                personsString = JsonSerializer.Deserialize<PersonString[]>(json);

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                personsString = new PersonString[0];
            }

            List<Person> persons = new();

            if (personsString == null) return persons;
           
            foreach(var perStr in personsString)
                persons.Add(perStr.ToPerson());

            return persons;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostDelete(string deleteId)
        {
            try
            {
                WebRequest request = WebRequest.Create(Host + Clients + '/' + deleteId);
                request.Method = "DELETE";
                request.GetResponse().Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("DELETE: id:" + deleteId);

            return RedirectToPage("/Index");

        }

        public IActionResult OnPostEdit(string editId)
        {
            WebRequest request = WebRequest.Create(Host + Clients + "/" + editId);

            PersonString? personString = new();

            Console.WriteLine(editId);

            try
            {
                string? json = "";
                Stream stream = request.GetResponse().GetResponseStream();
                using (StreamReader streamReader = new StreamReader(stream))
                {
                    json = streamReader.ReadToEnd();
                }
                stream.Close();

                Console.WriteLine(json);

                personString = JsonSerializer.Deserialize<PersonString>(json);
            }
            catch(Exception e)
            {

            }


            Console.WriteLine("GET: to edit. id:" + personString.id);

            if (personString == null) 
            {
                return RedirectToPage("/Index");
            }

            string? url = Url.Page("Create", personString);
            return Redirect(url);
        }

    }
}