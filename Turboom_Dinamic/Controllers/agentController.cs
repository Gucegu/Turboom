using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turboom_Dinamic.Data;
using Turboom_Dinamic.Models;

namespace Turboom_Dinamic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AgentesController(AppDbContext context) => _context = context;

        // POST api/agentes/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AgenteLoginDto dto)
        {
            if (dto == null)
                return BadRequest("Payload inválido.");

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            var agente = await _context.Agentes
                .Include(a => a.Funcao) // Inclui dados da função se necessário
                .FirstOrDefaultAsync(a => a.Email == dto.Email);

            if (agente == null || string.IsNullOrEmpty(agente.SenhaHash))
                return Unauthorized("E-mail ou senha incorretos.");

            bool senhaValida = BCrypt.Net.BCrypt.Verify(dto.Senha, agente.SenhaHash);
            if (!senhaValida)
                return Unauthorized("E-mail ou senha incorretos.");

            // Retorna dados do agente
            return Ok(new
            {
                IdAgente = agente.IdAgente,
                Nome = agente.Nome,
                Email = agente.Email,
                Funcao = agente.Funcao?.NomeFuncao // Ajuste conforme sua estrutura
            });
        }

        // GET api/agentes - Listar agentes (opcional, para admin)
        [HttpGet]
        public async Task<IActionResult> GetAgentes()
        {
            var agentes = await _context.Agentes
                .Include(a => a.Funcao)
                .Select(a => new
                {
                    a.IdAgente,
                    a.Nome,
                    a.Email,
                    Funcao = a.Funcao.NomeFuncao,
                    a.DataCadastro
                })
                .ToListAsync();

            return Ok(agentes);
        }

        // POST api/agentes/register (apenas para desenvolvimento)
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AgenteRegisterDto dto)
        {
            if (dto == null)
                return BadRequest("Payload inválido.");

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Senha))
                return BadRequest("Email e senha são obrigatórios.");

            if (await _context.Agentes.AnyAsync(a => a.Email == dto.Email))
                return BadRequest("E-mail já cadastrado.");

            var agente = new Agente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha),
                IdFuncao = dto.IdFuncao
            };

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                agente.IdAgente,
                agente.Nome,
                agente.Email,
                agente.IdFuncao
            });
        }

        public class AgenteRegisterDto
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
            public int IdFuncao { get; set; }
        }
    }

    // DTO para login do agente
    public class AgenteLoginDto
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}