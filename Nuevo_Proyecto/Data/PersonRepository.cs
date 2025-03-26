using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Nuevo_Proyecto.Interface;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context) 
        {
            _context = context;   
        }

        public async Task<Person> GetPersonByIdAsync(int id) => await _context.Person.FindAsync(id);

        public async Task<IEnumerable<Person>> GetPersonAsync() => await _context.Person.Take(100).ToListAsync();

        //create
        public async Task<Person>CreatePersonAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<bool> UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(person.BusinessEntityID))
                {
                    return false;
                }
                else
                {
                    throw;
                }

            }
        }
        public async Task<bool> DeletePersonByIdAsync(int id)
        {
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return false;
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.BusinessEntityID == id);
        }
    }
}
