using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turboom_Dinamic.Data;
using Turboom_Dinamic.Models;

namespace Turboom_Dinamic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Cliente)
                .AsNoTracking()
                .ToListAsync();

            // remove tickets com cliente nulo só pra evitar o erro
            tickets = tickets.Where(t => t.Cliente != null).ToList();

            return tickets;
        }


        // ✅ GET: api/tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // ✅ POST: api/tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            // assume idCliente já ok e válido
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTicket), new { id = ticket.IdTicket }, ticket);
        }
        // ✅ PUT: api/tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.IdTicket)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tickets.Any(e => e.IdTicket == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // ✅ DELETE: api/tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                return NotFound();

            // 🔥 Remove primeiro todas as mensagens relacionadas
            var mensagens = _context.Mensagens.Where(m => m.IDTicket == id);
            _context.Mensagens.RemoveRange(mensagens);

            // Depois remove o ticket
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Ticket e mensagens deletados com sucesso!" });
        }


        // ✅ GET: api/Tickets/problemas
        [HttpGet("problemas")]
        public async Task<IActionResult> GetProblemas()
        {
            var problemas = await _context.Problemas
                .Select(p => new { p.IdProblema, p.Titulo })
                .ToListAsync();
            return Ok(problemas);
        }
        // GET: api/Tickets/cliente/5
        [HttpGet("cliente/{idCliente}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsPorCliente(int idCliente)
        {
            try
            {
                var tickets = await _context.Tickets
                    .Include(t => t.Cliente)
                    .Include(t => t.Problema)
                    .Where(t => t.IdCliente == idCliente)
                    .OrderByDescending(t => t.DataCriacao)
                    .Select(t => new
                    {
                        IdTicket = t.IdTicket,
                        Titulo = t.Titulo,
                        Descricao = t.Descricao,
                        Status = t.Status,
                        Prioridade = t.Prioridade,
                        DataCriacao = t.DataCriacao,
                        DataFechamento = t.DataFechamento,
                        Cliente = new
                        {
                            IdCliente = t.Cliente.IdCliente,
                            Nome = t.Cliente.Nome,
                            Email = t.Cliente.Email
                        },
                        Problema = t.Problema != null ? new
                        {
                            IdProblema = t.Problema.IdProblema,
                            Titulo = t.Problema.Titulo
                        } : null
                    })
                    .ToListAsync();

                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // ✅ POST: api/Tickets (cria ticket + primeira mensagem)
        [HttpPost("novo")]
        public async Task<IActionResult> CriarTicketComMensagem([FromBody] NovoTicketDto dto)
        {
            if (dto == null || dto.IdCliente <= 0 || dto.IdProblema <= 0)
                return BadRequest("Dados inválidos.");

            var ticket = new Ticket
            {
                IdCliente = dto.IdCliente,
                IdProblema = dto.IdProblema,
                Titulo = dto.Titulo ?? "Sem título",
                Descricao = dto.Descricao ?? "Sem descrição"
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // adiciona a primeira mensagem do cliente
            var msg = new Mensagem
            {
                IDTicket = ticket.IdTicket,
                IDCliente = dto.IdCliente,
                Texto = dto.Descricao ?? "Sem mensagem"
            };

            _context.Mensagens.Add(msg);
            await _context.SaveChangesAsync();

            return Ok(new { ticket.IdTicket, ticket.Titulo, ticket.Status });
        }

        // DTO auxiliar (fica dentro do mesmo arquivo, fora da classe principal)
        public class NovoTicketDto
        {
            public int IdCliente { get; set; }
            public int IdProblema { get; set; }
            public string? Titulo { get; set; }
            public string? Descricao { get; set; }
        }
        // No ProblemsController ou TicketsController
        [HttpGet("problemas/{id}")]
        public async Task<ActionResult<Problema>> GetProblema(int id)
        {
            var problema = await _context.Problemas.FindAsync(id);
            if (problema == null) return NotFound();
            return problema;
        }


    }
}
