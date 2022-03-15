using PruebaBackend.Entities;
using PruebaBackend.Mapper.Interface;
using PruebaBackend.Models.Dtos;
using PruebaBackend.Models.Response;
using PruebaBackend.Repositories.Interfaces;
using PruebaBackend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaBackend.Services
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntityMapper _mapper;

        public ServiceCliente(IUnitOfWork unitOfWork, IEntityMapper entityMapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = entityMapper;
        }

        public async Task<ICollection<ClienteDto>> GetAll()
        {
            var response = await _unitOfWork.ClienteRepository.FindByConditionAsync(x => !x.IsDeleted);
            if (response.Count == 0)
                return null;
            else
            {
                List<ClienteDto> dto = new();
                foreach (var item in response)
                {
                    dto.Add(_mapper.ClienteToClienteDto(item));
                }

                return dto;
            }
        }

        public async Task<Result> GetById(int id)
        {
            try
            {
                Cliente cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(id);

                if (cliente == null)
                    return Result.FailureResult("No se encontro ningun Cliente con Id ingresado");
                if (cliente.IsDeleted != false)
                    return Result.FailureResult("Cliente con Id ingresado ha sido eliminado previamente");

                var clienteDto = _mapper.ClienteToClienteDto(cliente);

                return Result<ClienteDto>.SuccessResult(clienteDto);
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Insert(ClienteDto clienteDto)
        {
            try
            {
                if (string.IsNullOrEmpty(clienteDto.Enfermedad) && clienteDto.OtraEnfermedad)
                    return Result.FailureResult("Se debe ingresar Otra Enfermedad");

                var cliente = _mapper.ClienteDtoToCliente(clienteDto);

                await _unitOfWork.ClienteRepository.Create(cliente);
                _unitOfWork.SaveChanges();

                return Result<ClienteDto>.SuccessResult(_mapper.ClienteToClienteDto(cliente));
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }
        public async Task<Result> Update(ClienteDto clienteDto, int id)
        {
            try
            {
                if (string.IsNullOrEmpty(clienteDto.Enfermedad) && clienteDto.OtraEnfermedad)
                    return Result.FailureResult("Se debe ingresar Otra Enfermedad");

                var cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(id);

                if (cliente != null)
                {
                    cliente.Nombre = clienteDto.Nombre;
                    cliente.Edad = clienteDto.Edad;
                    cliente.Genero = clienteDto.Genero;
                    cliente.Enfermedad = clienteDto.Enfermedad;
                    cliente.EsDiabetico = clienteDto.EsDiabetico;
                    cliente.Maneja = clienteDto.Maneja;
                    cliente.OtraEnfermedad = clienteDto.OtraEnfermedad;
                    cliente.UsaLentes = clienteDto.UsaLentes;

                    await _unitOfWork.SaveChangesAsync();

                    return Result<ClienteDto>.SuccessResult(_mapper.ClienteToClienteDto(cliente));
                }

                return Result.FailureResult("Id de Cliente inexistente.");
            }
            catch (Exception ex)
            {
                return Result.ErrorResult(new List<string> { ex.Message });
            }
        }

        public async Task<Result> Delete(int id)
        {
            try
            {
                Cliente cliente = await _unitOfWork.ClienteRepository.GetByIdAsync(id);

                if (cliente != null && !cliente.IsDeleted)
                {
                    cliente.IsDeleted = true;
                    _unitOfWork.SaveChanges();

                    return Result<string>.SuccessResult("Cliente eliminado correctamente");
                }
                else
                {
                    if (cliente == null)
                        return Result.FailureResult("No se encontro ningun Cliente con Id ingresado");
                    else
                        return Result.FailureResult("Cliente con Id ingresado ha sido eliminado previamente");
                }
            }
            catch (Exception ex)
            {
                return Result.FailureResult(ex.Message);
            }
        }
    }
}
