namespace Turboom_Dinamic.Models
{
    public class MensagemTicket
    {
        public int IdMensagem { get; set; }
        public int IdTicket { get; set; }
        public int IdCliente { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; } = DateTime.Now;
        public bool EhInterno { get; set; } = false;
    }
}
