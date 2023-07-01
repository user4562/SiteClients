using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using SiteClients.Model;
using System.Text.Json;
using System.Net;
using System.Text;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SiteClients.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        public string Host { get; set; }
        //public readonly string ClientsCreate = "/api/clients/createNew";
        public readonly string ClientsCreate = "/clientController/newClient";


        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ILogger<CreateModel> logger)
        {
            _logger = logger;
            Console.WriteLine("Load Create Page");

            Host = Environment.GetEnvironmentVariable("DBIP") ?? "http://localhost:3000";
            Console.WriteLine(Host);
            Id = "-1";
        }

        public void SetPerson(PersonString person)
        { 
            Id = person.id.ToString();
            FirstName = person.firstName;
            LastName = person.lastName;
            BirthDate = DateOnly.Parse(person.birthDate).ToString("yyyy-MM-dd"); 
            Phone = person.phone;
            Email = person.email;
        }


        public void OnGet(PersonString personString)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(personString.firstName);
            if (personString.firstName != null) SetPerson(personString);
            else Id = "-1";
        }

        public IActionResult OnPost(string id,string firstName, string lastName, DateOnly birthDate, string phone, string email)
        {
            var person = new PersonString()
            {
                id = long.Parse(id ?? Id),
                firstName = firstName,
                lastName = lastName,
                birthDate = birthDate.ToString("yyyy-MM-dd"),
                phone = phone,
                email = email
            };

            string? json = JsonSerializer.Serialize(person);
            var url = Host;

            if (id == "-1")
            {
                url += ClientsCreate;
            }
            else
            {
                url += "/clientController/" + person.id;
            }


            WebRequest request = WebRequest.Create(url);

            if (id == "-1")
            {
                request.Method = "POST";
                Console.WriteLine("POST: create new client");

            }
            else
            {
                request.Method = "PATCH";
                Console.WriteLine("PATCH: id:" + person.id);

            }
            
            request.ContentType = "application/json";

            try
            {
                using (var stream = new StreamWriter(request.GetRequestStream()))
                {
                    stream.WriteLine(json);
                }

                request.GetResponse().Close();
            }
            catch
            {

            }
            
            return RedirectToPage("/Index");
        }
    }
}