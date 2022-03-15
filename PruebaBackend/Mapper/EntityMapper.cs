using PruebaBackend.Entities;
using PruebaBackend.Mapper.Interface;
using PruebaBackend.Models.Dtos;

namespace PruebaBackend.Mapper
{
    public class EntityMapper : IEntityMapper
    {
        public ClienteDto ClienteToClienteDto(Cliente cliente)
        {
            return new ClienteDto
            {
                Nombre = cliente.Nombre,
                Edad = cliente.Edad,
                Genero = cliente.Genero,
                Enfermedad = cliente.Enfermedad,
                EsDiabetico = cliente.EsDiabetico,
                Maneja = cliente.Maneja,
                OtraEnfermedad = cliente.OtraEnfermedad,
                UsaLentes = cliente.UsaLentes,
                Id = cliente.Id
            };
        }

        public Cliente ClienteDtoToCliente(ClienteDto clienteDto)
        {
            return new Cliente
            {
                Nombre = clienteDto.Nombre,
                Edad = clienteDto.Edad,
                Genero = clienteDto.Genero,
                Enfermedad = clienteDto.Enfermedad,
                EsDiabetico = clienteDto.EsDiabetico,
                Maneja = clienteDto.Maneja,
                OtraEnfermedad = clienteDto.OtraEnfermedad,
                UsaLentes = clienteDto.UsaLentes
            };
        }

        public User UserDtoForRegisterToUser(UserDtoForRegister userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }

        public UserDtoDisplay UserToUserDtoDisplay(User user)
        {
            return new UserDtoDisplay
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }

    }
}
