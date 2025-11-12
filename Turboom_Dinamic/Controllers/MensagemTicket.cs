// Controllers/MensagensController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turboom_Dinamic.Data;
using Turboom_Dinamic.Models;

namespace Turboom_Dinamic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MensagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Mensagens/ticket/5
        [HttpGet("ticket/{idTicket}")]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagensPorTicket(int idTicket)
        {
            var mensagens = await _context.Mensagens
                .Include(m => m.Cliente)
                .Where(m => m.IDTicket == idTicket)
                .OrderBy(m => m.DataEnvio)
                .ToListAsync();

            return Ok(mensagens);
        }

        // POST: api/Mensagens
        [HttpPost]
        public async Task<ActionResult<Mensagem>> PostMensagem(Mensagem mensagem)
        {
            // Se for mensagem do cliente, pega o ID do cliente do ticket
            if (mensagem.IDCliente == 0 && mensagem.IDTicket > 0)
            {
                var ticket = await _context.Tickets.FindAsync(mensagem.IDTicket);
                if (ticket != null)
                {
                    mensagem.IDCliente = ticket.IdCliente;
                }
            }

            mensagem.DataEnvio = DateTime.Now;

            _context.Mensagens.Add(mensagem);
            await _context.SaveChangesAsync();

            // Carrega os dados relacionados para retornar
            await _context.Entry(mensagem)
                .Reference(m => m.Cliente)
                .LoadAsync();

            return CreatedAtAction("GetMensagensPorTicket", new { idTicket = mensagem.IDTicket }, mensagem);
        }
    }
}