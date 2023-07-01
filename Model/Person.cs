namespace SiteClients.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int Age 
        {
            get
            {
                DateTime birth = BirthDate.ToDateTime(new TimeOnly(0));
                return (int)Math.Round(DateTime.Now.Subtract(birth).TotalDays / 365);
            }

        }
    }

    public class PersonString
    {
        public long id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? birthDate { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }

        public Person ToPerson()
        {
            return new Person()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = DateOnly.Parse(birthDate),
                Phone = phone,
                Email = email
            };
        }
    }
}
