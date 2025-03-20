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

        public async Task<Person> GetPersonByIDAsync(int id) => await _context.Person.FindAsync(id);

        public async Task<IEnumerable<Person>> GetPersonAsync() => await _context.Person.Take(100).ToListAsync();
    }
}
