using Nuevo_Proyecto.Controllers;
using Nuevo_Proyecto.Model;

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
}
