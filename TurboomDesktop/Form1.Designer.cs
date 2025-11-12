namespace TurboomDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDashboard = new System.Windows.Forms.TabPage();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.groupResolvidos = new System.Windows.Forms.GroupBox();
            this.lblResolvidosValor = new System.Windows.Forms.Label();
            this.groupPendentes = new System.Windows.Forms.GroupBox();
            this.lblPendentesValor = new System.Windows.Forms.Label();
            this.groupAbertos = new System.Windows.Forms.GroupBox();
            this.lblAbertosValor = new System.Windows.Forms.Label();
            this.groupTotal = new System.Windows.Forms.GroupBox();
            this.lblTotalValor = new System.Windows.Forms.Label();
            this.tabPageAgentes = new System.Windows.Forms.TabPage();
            this.btnRefreshAgentes = new System.Windows.Forms.Button();
            this.btnNovoAgente = new System.Windows.Forms.Button();
            this.dataGridViewAgentes = new System.Windows.Forms.DataGridView();
            this.tabPageCriarAgente = new System.Windows.Forms.TabPage();
            this.btnCriar = new System.Windows.Forms.Button();
            this.numericFuncao = new System.Windows.Forms.NumericUpDown();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Nome = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageDashboard.SuspendLayout();
            this.groupResolvidos.SuspendLayout();
            this.groupPendentes.SuspendLayout();
            this.groupAbertos.SuspendLayout();
            this.groupTotal.SuspendLayout();
            this.tabPageAgentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgentes)).BeginInit();
            this.tabPageCriarAgente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFuncao)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.AccessibleName = "panelTop";
            this.panelTop.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(984, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AccessibleName = "lblTitulo";
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(300, 40);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "TURBOOM DESKTOP";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 60);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(984, 501);
            this.panelMain.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDashboard);
            this.tabControl1.Controls.Add(this.tabPageAgentes);
            this.tabControl1.Controls.Add(this.tabPageCriarAgente);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageDashboard
            // 
            this.tabPageDashboard.Controls.Add(this.btnAtualizar);
            this.tabPageDashboard.Controls.Add(this.groupResolvidos);
            this.tabPageDashboard.Controls.Add(this.groupPendentes);
            this.tabPageDashboard.Controls.Add(this.groupAbertos);
            this.tabPageDashboard.Controls.Add(this.groupTotal);
            this.tabPageDashboard.Location = new System.Drawing.Point(4, 22);
            this.tabPageDashboard.Name = "tabPageDashboard";
            this.tabPageDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDashboard.Size = new System.Drawing.Size(976, 475);
            this.tabPageDashboard.TabIndex = 0;
            this.tabPageDashboard.Text = "Dashboard";
            this.tabPageDashboard.UseVisualStyleBackColor = true;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(50, 200);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(150, 40);
            this.btnAtualizar.TabIndex = 4;
            this.btnAtualizar.Text = "Atualizar Dashboard";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // groupResolvidos
            // 
            this.groupResolvidos.Controls.Add(this.lblResolvidosValor);
            this.groupResolvidos.Location = new System.Drawing.Point(768, 50);
            this.groupResolvidos.Name = "groupResolvidos";
            this.groupResolvidos.Size = new System.Drawing.Size(200, 100);
            this.groupResolvidos.TabIndex = 3;
            this.groupResolvidos.TabStop = false;
            this.groupResolvidos.Text = "Resolvidos: 0";
            // 
            // lblResolvidosValor
            // 
            this.lblResolvidosValor.AutoSize = true;
            this.lblResolvidosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResolvidosValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResolvidosValor.Location = new System.Drawing.Point(3, 16);
            this.lblResolvidosValor.Name = "lblResolvidosValor";
            this.lblResolvidosValor.Size = new System.Drawing.Size(30, 31);
            this.lblResolvidosValor.TabIndex = 0;
            this.lblResolvidosValor.Text = "0";
            this.lblResolvidosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupPendentes
            // 
            this.groupPendentes.Controls.Add(this.lblPendentesValor);
            this.groupPendentes.Location = new System.Drawing.Point(519, 50);
            this.groupPendentes.Name = "groupPendentes";
            this.groupPendentes.Size = new System.Drawing.Size(200, 100);
            this.groupPendentes.TabIndex = 2;
            this.groupPendentes.TabStop = false;
            this.groupPendentes.Text = "Pendentes: 0";
            // 
            // lblPendentesValor
            // 
            this.lblPendentesValor.AutoSize = true;
            this.lblPendentesValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPendentesValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendentesValor.Location = new System.Drawing.Point(3, 16);
            this.lblPendentesValor.Name = "lblPendentesValor";
            this.lblPendentesValor.Size = new System.Drawing.Size(30, 31);
            this.lblPendentesValor.TabIndex = 0;
            this.lblPendentesValor.Text = "0";
            this.lblPendentesValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPendentesValor.Click += new System.EventHandler(this.label3_Click);
            // 
            // groupAbertos
            // 
            this.groupAbertos.Controls.Add(this.lblAbertosValor);
            this.groupAbertos.Location = new System.Drawing.Point(271, 50);
            this.groupAbertos.Name = "groupAbertos";
            this.groupAbertos.Size = new System.Drawing.Size(200, 100);
            this.groupAbertos.TabIndex = 1;
            this.groupAbertos.TabStop = false;
            this.groupAbertos.Text = "Abertos: 0";
            // 
            // lblAbertosValor
            // 
            this.lblAbertosValor.AutoSize = true;
            this.lblAbertosValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAbertosValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbertosValor.Location = new System.Drawing.Point(3, 16);
            this.lblAbertosValor.Name = "lblAbertosValor";
            this.lblAbertosValor.Size = new System.Drawing.Size(30, 31);
            this.lblAbertosValor.TabIndex = 0;
            this.lblAbertosValor.Text = "0";
            this.lblAbertosValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupTotal
            // 
            this.groupTotal.Controls.Add(this.lblTotalValor);
            this.groupTotal.Location = new System.Drawing.Point(21, 50);
            this.groupTotal.Name = "groupTotal";
            this.groupTotal.Size = new System.Drawing.Size(200, 100);
            this.groupTotal.TabIndex = 0;
            this.groupTotal.TabStop = false;
            this.groupTotal.Text = "Total: 0";
            this.groupTotal.Enter += new System.EventHandler(this.groupTotal_Enter);
            // 
            // lblTotalValor
            // 
            this.lblTotalValor.AutoSize = true;
            this.lblTotalValor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValor.Location = new System.Drawing.Point(3, 16);
            this.lblTotalValor.Name = "lblTotalValor";
            this.lblTotalValor.Size = new System.Drawing.Size(30, 31);
            this.lblTotalValor.TabIndex = 0;
            this.lblTotalValor.Text = "0";
            this.lblTotalValor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalValor.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPageAgentes
            // 
            this.tabPageAgentes.Controls.Add(this.btnRefreshAgentes);
            this.tabPageAgentes.Controls.Add(this.btnNovoAgente);
            this.tabPageAgentes.Controls.Add(this.dataGridViewAgentes);
            this.tabPageAgentes.Location = new System.Drawing.Point(4, 22);
            this.tabPageAgentes.Name = "tabPageAgentes";
            this.tabPageAgentes.Size = new System.Drawing.Size(976, 475);
            this.tabPageAgentes.TabIndex = 2;
            this.tabPageAgentes.Text = "Agentes";
            this.tabPageAgentes.UseVisualStyleBackColor = true;
            // 
            // btnRefreshAgentes
            // 
            this.btnRefreshAgentes.Location = new System.Drawing.Point(51, 187);
            this.btnRefreshAgentes.Name = "btnRefreshAgentes";
            this.btnRefreshAgentes.Size = new System.Drawing.Size(120, 30);
            this.btnRefreshAgentes.TabIndex = 2;
            this.btnRefreshAgentes.Text = "Atualizar Lista";
            this.btnRefreshAgentes.UseVisualStyleBackColor = true;
            this.btnRefreshAgentes.Click += new System.EventHandler(this.btnRefreshAgentes_Click);
            // 
            // btnNovoAgente
            // 
            this.btnNovoAgente.Location = new System.Drawing.Point(51, 31);
            this.btnNovoAgente.Name = "btnNovoAgente";
            this.btnNovoAgente.Size = new System.Drawing.Size(120, 30);
            this.btnNovoAgente.TabIndex = 1;
            this.btnNovoAgente.Text = "Novo Agente";
            this.btnNovoAgente.UseVisualStyleBackColor = true;
            this.btnNovoAgente.Click += new System.EventHandler(this.btnNovoAgente_Click);
            // 
            // dataGridViewAgentes
            // 
            this.dataGridViewAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAgentes.Location = new System.Drawing.Point(536, 0);
            this.dataGridViewAgentes.Name = "dataGridViewAgentes";
            this.dataGridViewAgentes.Size = new System.Drawing.Size(440, 464);
            this.dataGridViewAgentes.TabIndex = 0;
            // 
            // tabPageCriarAgente
            // 
            this.tabPageCriarAgente.Controls.Add(this.btnCriar);
            this.tabPageCriarAgente.Controls.Add(this.numericFuncao);
            this.tabPageCriarAgente.Controls.Add(this.txtSenha);
            this.tabPageCriarAgente.Controls.Add(this.txtEmail);
            this.tabPageCriarAgente.Controls.Add(this.txtNome);
            this.tabPageCriarAgente.Controls.Add(this.label4);
            this.tabPageCriarAgente.Controls.Add(this.label3);
            this.tabPageCriarAgente.Controls.Add(this.label2);
            this.tabPageCriarAgente.Controls.Add(this.Nome);
            this.tabPageCriarAgente.Location = new System.Drawing.Point(4, 22);
            this.tabPageCriarAgente.Name = "tabPageCriarAgente";
            this.tabPageCriarAgente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCriarAgente.Size = new System.Drawing.Size(976, 475);
            this.tabPageCriarAgente.TabIndex = 1;
            this.tabPageCriarAgente.Text = "Criar Agente";
            this.tabPageCriarAgente.UseVisualStyleBackColor = true;
            // 
            // btnCriar
            // 
            this.btnCriar.Location = new System.Drawing.Point(461, 389);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(120, 40);
            this.btnCriar.TabIndex = 8;
            this.btnCriar.Text = "Criar Agente";
            this.btnCriar.UseVisualStyleBackColor = true;
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // numericFuncao
            // 
            this.numericFuncao.Location = new System.Drawing.Point(234, 318);
            this.numericFuncao.Name = "numericFuncao";
            this.numericFuncao.Size = new System.Drawing.Size(44, 20);
            this.numericFuncao.TabIndex = 7;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(234, 243);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(271, 20);
            this.txtSenha.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(234, 157);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(427, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(234, 47);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(427, 20);
            this.txtNome.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(76, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Função:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Senha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email:";
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nome.Location = new System.Drawing.Point(76, 50);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(99, 31);
            this.Nome.TabIndex = 0;
            this.Nome.Text = "Nome:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.panelTop);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Turboom Desktop - Dashboard";
            this.panelMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDashboard.ResumeLayout(false);
            this.groupResolvidos.ResumeLayout(false);
            this.groupResolvidos.PerformLayout();
            this.groupPendentes.ResumeLayout(false);
            this.groupPendentes.PerformLayout();
            this.groupAbertos.ResumeLayout(false);
            this.groupAbertos.PerformLayout();
            this.groupTotal.ResumeLayout(false);
            this.groupTotal.PerformLayout();
            this.tabPageAgentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAgentes)).EndInit();
            this.tabPageCriarAgente.ResumeLayout(false);
            this.tabPageCriarAgente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericFuncao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.TabPage tabPageCriarAgente;
        private System.Windows.Forms.TabPage tabPageAgentes;
        private System.Windows.Forms.GroupBox groupResolvidos;
        private System.Windows.Forms.GroupBox groupPendentes;
        private System.Windows.Forms.GroupBox groupAbertos;
        private System.Windows.Forms.GroupBox groupTotal;
        private System.Windows.Forms.Label lblResolvidosValor;
        private System.Windows.Forms.Label lblPendentesValor;
        private System.Windows.Forms.Label lblAbertosValor;
        private System.Windows.Forms.Label lblTotalValor;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridView dataGridViewAgentes;
        private System.Windows.Forms.Button btnRefreshAgentes;
        private System.Windows.Forms.Button btnNovoAgente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.NumericUpDown numericFuncao;
        private System.Windows.Forms.Button btnCriar;
    }
}

