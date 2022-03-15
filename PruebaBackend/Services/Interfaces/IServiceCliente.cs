using PruebaBackend.Models.Dtos;
using PruebaBackend.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaBackend.Services.Interfaces
{
    public interface IServiceCliente
    {
        Task<ICollection<ClienteDto>> GetAll();
        Task<Result> GetById(int id);
        Task<Result> Insert(ClienteDto clienteDto);
        Task<Result> Update(ClienteDto clienteDto, int id);
        Task<Result> Delete(int id);
    }
}
