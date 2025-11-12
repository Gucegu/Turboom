using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turboom_Dinamic.Data;
using Turboom_Dinamic.Models;

namespace Turboom_Dinamic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientesController(AppDbContext context) => _context = context;

        // POST api/clientes/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ClienteRegisterDto dto)
        {
            if (dto == null) return BadRequest("Payload inválido.");
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            if (await _context.Clientes.AnyAsync(c => c.Email == dto.Email))
                return BadRequest("E-mail já cadastrado.");

            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha)
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(new { cliente.IdCliente, cliente.Nome, cliente.Email });
        }

        // POST api/clientes/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] ClienteLoginDto dto)
        {
            if (dto == null) return BadRequest("Payload inválido.");
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Email == dto.Email);
            if (cliente == null || string.IsNullOrEmpty(cliente.SenhaHash))
                return Unauthorized("E-mail ou senha incorretos.");

            bool ok = BCrypt.Net.BCrypt.Verify(dto.Senha, cliente.SenhaHash);
            if (!ok) return Unauthorized("E-mail ou senha incorretos.");

            // Retorna dados mínimos
            return Ok(new
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                Email = cliente.Email
            });
        }
    }
}
