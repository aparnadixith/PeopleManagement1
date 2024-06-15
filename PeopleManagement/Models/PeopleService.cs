using PeopleManagement.Models.PersonModel;
using PeopleManagement.Models.ViewModel;

namespace PeopleManagement.Models
{
    public class PeopleService : IPeopleService
    {
            private readonly IPeopleRepo _repo;

            public PeopleService(IPeopleRepo repo)
            {
                _repo = repo;
            }

            public Person Add(CreatePersonViewModel person)
            {
                var newPerson = new Person
                {
                    Name = person.Name,
                    PhoneNumber = person.PhoneNumber,
                    City = person.City
                };
                return _repo.Create(newPerson);
            }

            public List<Person> All()
            {
                return _repo.Read();
            }

            public List<Person> Search(string search)
            {
                return _repo.Read().Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                p.City.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            public Person FindById(int id)
            {
                return _repo.Read(id);
            }

            public bool Edit(int id, CreatePersonViewModel person)
            {
                var existingPerson = _repo.Read(id);
                if (existingPerson == null) return false;

                existingPerson.Name = person.Name;
                existingPerson.PhoneNumber = person.PhoneNumber;
                existingPerson.City = person.City;
                return _repo.Update(existingPerson);
            }

            public bool Remove(int id)
            {
                var person = _repo.Read(id);
                if (person == null) return false;
                return _repo.Delete(person);
            }
        

    }
}
