using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurboomDesktop
{
    public partial class Form1 : Form
    {
        private ApiService _apiService;
        private LoginResponse _agenteLogado;

        public Form1()
        {
            InitializeComponent();
            _apiService = new ApiService();
            MostrarLogin();
        }

        // 🔹 MOSTRAR TELA DE LOGIN
        private void MostrarLogin()
        {
            using (var loginForm = new LoginForm(_apiService))
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    _agenteLogado = loginForm.AgenteLogado;
                    // ✅ USA lblTitulo (que existe no seu designer)
                    lblTitulo.Text = $"TURBOOM DESKTOP - {_agenteLogado.Nome}";
                    _ = CarregarDashboard();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        // 🔹 CARREGAR DASHBOARD
        // 🔹 CARREGAR DASHBOARD
        private async Task CarregarDashboard()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var volumetria = await _apiService.GetVolumetriaTickets();

                // ✅ CORREÇÃO: Usar Invoke para atualizar a UI na thread principal
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() =>
                    {
                        // Atualizar os GroupBox NA THREAD PRINCIPAL
                        groupTotal.Text = $"Total: {volumetria.Total}";
                        groupAbertos.Text = $"Abertos: {volumetria.Abertos}";
                        groupPendentes.Text = $"Pendentes: {volumetria.Pendentes}";
                        groupResolvidos.Text = $"Resolvidos: {volumetria.Resolvidos}";

                        // Atualizar labels dentro dos GroupBox
                        lblTotalValor.Text = volumetria.Total.ToString();
                        lblAbertosValor.Text = volumetria.Abertos.ToString();
                        lblPendentesValor.Text = volumetria.Pendentes.ToString();
                        lblResolvidosValor.Text = volumetria.Resolvidos.ToString();
                    }));
                }
                else
                {
                    // Já está na thread principal
                    groupTotal.Text = $"Total: {volumetria.Total}";
                    groupAbertos.Text = $"Abertos: {volumetria.Abertos}";
                    groupPendentes.Text = $"Pendentes: {volumetria.Pendentes}";
                    groupResolvidos.Text = $"Resolvidos: {volumetria.Resolvidos}";

                    lblTotalValor.Text = volumetria.Total.ToString();
                    lblAbertosValor.Text = volumetria.Abertos.ToString();
                    lblPendentesValor.Text = volumetria.Pendentes.ToString();
                    lblResolvidosValor.Text = volumetria.Resolvidos.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dashboard: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        // 🔹 CARREGAR LISTA DE AGENTES
        private async Task CarregarAgentes()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var agentes = await _apiService.GetAgentes();
                dataGridViewAgentes.DataSource = agentes;

                // Formatar DataGridView
                dataGridViewAgentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewAgentes.Columns["IdAgente"].HeaderText = "ID";
                dataGridViewAgentes.Columns["Nome"].HeaderText = "Nome";
                dataGridViewAgentes.Columns["Email"].HeaderText = "E-mail";
                dataGridViewAgentes.Columns["DataCadastro"].HeaderText = "Data Cadastro";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar agentes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ✅ BOTÃO ATUALIZAR DASHBOARD
        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            await CarregarDashboard();
        }

        // ✅ BOTÃO ATUALIZAR AGENTES
        private async void btnRefreshAgentes_Click(object sender, EventArgs e)
        {
            await CarregarAgentes();
        }

        // ✅ BOTÃO NOVO AGENTE
        private void btnNovoAgente_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCriarAgente;
        }

        // ✅ BOTÃO CRIAR AGENTE
        private async void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Preencha todos os campos!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var novoAgente = new AgenteCreateDto
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Senha = txtSenha.Text,
                    IdFuncao = (int)numericFuncao.Value
                };

                Cursor = Cursors.WaitCursor;
                var sucesso = await _apiService.CriarAgente(novoAgente);

                if (sucesso)
                {
                    MessageBox.Show("Agente criado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpar campos
                    txtNome.Clear();
                    txtEmail.Clear();
                    txtSenha.Clear();
                    numericFuncao.Value = 1;

                    // Voltar para lista de agentes
                    tabControl1.SelectedTab = tabPageAgentes;
                    await CarregarAgentes();
                }
                else
                {
                    MessageBox.Show("Erro ao criar agente. Verifique os dados.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // ✅ BOTÃO SAIR
        private void btnLogout_Click(object sender, EventArgs e)
        {
            _agenteLogado = null;
            MostrarLogin();
        }

        // ✅ QUANDO MUDAR DE ABA
        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageDashboard)
            {
                await CarregarDashboard();
            }
            else if (tabControl1.SelectedTab == tabPageAgentes)
            {
                await CarregarAgentes();
            }
        }

        // ✅ MÉTODOS VAZIOS (deixe existentes - não apague)
        private void groupTotal_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}