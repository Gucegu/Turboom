using System;
using System.Windows.Forms;

namespace TurboomDesktop
{
    public partial class LoginForm : Form
    {
        private readonly ApiService _apiService;
        public LoginResponse AgenteLogado { get; private set; }

        public LoginForm(ApiService apiService)
        {
            InitializeComponent();
            _apiService = apiService;
        }

        // ✅ MÉTODOS DOS EVENTOS DO DESIGNER (deixe vazios)
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio - é só o evento do campo email
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Pode deixar vazio - é o evento do campo senha
        }

        // ✅ BOTÃO LOGIN
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Preencha e-mail e senha!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                btnLogin.Enabled = false;
                Cursor = Cursors.WaitCursor;

                AgenteLogado = await _apiService.LoginAgente(txtEmail.Text, txtSenha.Text);

                if (AgenteLogado != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("E-mail ou senha incorretos!", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no login: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        // ✅ BOTÃO CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}