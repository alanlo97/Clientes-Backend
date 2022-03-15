using PruebaBackend.Entities;
using PruebaBackend.Models.Dtos;

namespace PruebaBackend.Mapper.Interface
{
    public interface IEntityMapper
    {
        ClienteDto ClienteToClienteDto(Cliente cliente);
        Cliente ClienteDtoToCliente(ClienteDto clienteDto);
        User UserDtoForRegisterToUser(UserDtoForRegister userDto);
        UserDtoDisplay UserToUserDtoDisplay(User user);
    }
}
