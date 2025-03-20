using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Interface
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersonAsync();
    }
}
