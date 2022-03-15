using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaBackend.Models.Dtos;
using PruebaBackend.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace PruebaBackend.Controllers
{
    [Route("Cliente")]
    [ApiController]
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IServiceCliente _serviceCliente;

        public ClienteController(IServiceCliente serviceCliente)
        {
            _serviceCliente = serviceCliente;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            try
            {
                var clientes = await _serviceCliente.GetAll();
                if (clientes != null)
                    return Ok(clientes);
                else
                    return NotFound("No se encontraron Clientes");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var result = await _serviceCliente.GetById(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 404, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var result = await _serviceCliente.Delete(id);
            if (result.Success)
                return Ok(result);
            return StatusCode(result.isError() ? 500 : 400, result);
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteDto clienteDto)
        {
            var result = await _serviceCliente.Insert(clienteDto);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClienteDto clienteDto)
        {
            var result = await _serviceCliente.Update(clienteDto, id);

            return StatusCode(result.StatusCode, result);
        }

    }
}
