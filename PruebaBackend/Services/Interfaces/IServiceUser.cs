using PruebaBackend.Models.Dtos;
using PruebaBackend.Models.Response;
using System.Threading.Tasks;

namespace PruebaBackend.Services.Interfaces
{
    public interface IServiceUser
    {
        Task<Result> Insert(UserDtoForRegister dto);
        Task<Result> LoginAsync(UserLoginDto userLoginDto);
    }
}
