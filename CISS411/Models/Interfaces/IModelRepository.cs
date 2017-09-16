using CISS411.Models.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CISS411.Models.Interfaces
{
    public interface IModelRepository
    {
        Task<List<Event>> Events();
        Task<List<Book>> Books();
    }
}
