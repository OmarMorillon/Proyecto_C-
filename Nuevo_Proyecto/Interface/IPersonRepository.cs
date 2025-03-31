using Microsoft.EntityFrameworkCore;
using Nuevo_Proyecto.Data;
using Nuevo_Proyecto.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nuevo_Proyecto.Interface
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonByIdAsync(int id);
        Task<IEnumerable<Person>> GetPersonAsync();
        Task<Person> CreatePersonAsync(Person person);
        Task<bool> UpdatePersonAsync(Person person);
        Task<bool> DeletePersonByIdAsync(int id);
    }

    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _context.Person.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetPersonAsync()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            var existingPerson = await _context.Person.FindAsync(person.BusinessEntityID);
            if (existingPerson == null)
                return false;

            // Actualización selectiva de campos
            existingPerson.PersonType = person.PersonType;
            existingPerson.NameStyle = person.NameStyle;
            existingPerson.Title = person.Title;
            existingPerson.FirstName = person.FirstName;
            existingPerson.MiddleName = person.MiddleName;
            existingPerson.LastName = person.LastName;
            existingPerson.Suffix = person.Suffix;
            existingPerson.EmailPromotion = person.EmailPromotion;
            existingPerson.ModifiedDate = DateTime.UtcNow; // Actualización automática

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<bool> DeletePersonByIdAsync(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
                return false;

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}