using System;

namespace TurboomDesktop
{
    // Model para Agente
    public class Agente
    {
        public int IdAgente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int IdFuncao { get; set; }
        public DateTime DataCadastro { get; set; }
    }

    // Model para criar Agente
    public class AgenteCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdFuncao { get; set; }
    }

    // Model para Volumetria
    public class VolumetriaTickets
    {
        public int Total { get; set; }
        public int Abertos { get; set; }
        public int Pendentes { get; set; }
        public int Resolvidos { get; set; }
    }

    // Model para Login Response
    public class LoginResponse
    {
        public int IdAgente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Funcao { get; set; }
    }
}