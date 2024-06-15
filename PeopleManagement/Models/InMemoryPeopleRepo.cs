using PeopleManagement.Models.PersonModel;

namespace PeopleManagement.Models
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        private static List<Person> people = new List<Person>();
        private static int idCounter = 1;

        public Person Create(Person person)
        {
            person.Id = idCounter++;
            people.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return people;
        }

        public Person Read(int id)
        {
            return people.FirstOrDefault(p => p.Id == id);
        }

        public bool Update(Person person)
        {
            var existingPerson = Read(person.Id);
            if (existingPerson == null) return false;

            existingPerson.Name = person.Name;
            existingPerson.PhoneNumber = person.PhoneNumber;
            existingPerson.City = person.City;
            return true;
        }

        public bool Delete(Person person)
        {
            return people.Remove(person);
        }
    }
}

