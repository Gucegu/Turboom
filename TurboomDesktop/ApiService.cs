using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

namespace TurboomDesktop
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7269/api";

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // 🔹 LOGIN DO AGENTE
        public async Task<LoginResponse> LoginAgente(string email, string senha)
        {
            try
            {
                var loginData = new { email, senha };
                var json = JsonConvert.SerializeObject(loginData);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/Agentes/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LoginResponse>(responseJson);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro no login: {ex.Message}");
            }
        }

        // 🔹 VOLUMETRIA DE TICKETS
        // 🔹 VOLUMETRIA DE TICKETS - VERSÃO SUPER ROBUSTA
        public async Task<VolumetriaTickets> GetVolumetriaTickets()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Tickets");

                if (response.IsSuccessStatusCode)
                {
                    var ticketsJson = await response.Content.ReadAsStringAsync();
                    var tickets = JsonConvert.DeserializeObject<List<dynamic>>(ticketsJson);

                    int abertos = 0, pendentes = 0, resolvidos = 0;

                    if (tickets != null)
                    {
                        foreach (var ticket in tickets)
                        {
                            try
                            {
                                // ✅ MUITO seguro para dynamic
                                var statusObj = ticket?.status;
                                string status = statusObj?.ToString()?.ToLower() ?? "";

                                if (status.Contains("aberto")) abertos++;
                                else if (status.Contains("pendente")) pendentes++;
                                else if (status.Contains("resolvido")) resolvidos++;
                            }
                            catch
                            {
                                // Ignora tickets com problemas
                                continue;
                            }
                        }
                    }

                    return new VolumetriaTickets
                    {
                        Total = tickets?.Count ?? 0,
                        Abertos = abertos,
                        Pendentes = pendentes,
                        Resolvidos = resolvidos
                    };
                }
                return new VolumetriaTickets();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar volumetria: {ex.Message}");
            }
        }
        // 🔹 LISTAR AGENTES
        public async Task<List<Agente>> GetAgentes()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/Agentes");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Agente>>(json);
                }
                return new List<Agente>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar agentes: {ex.Message}");
            }
        }

        // 🔹 CRIAR AGENTE
        public async Task<bool> CriarAgente(AgenteCreateDto agente)
        {
            try
            {
                var json = JsonConvert.SerializeObject(agente);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{BaseUrl}/Agentes/register", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar agente: {ex.Message}");
            }
        }
    }
}