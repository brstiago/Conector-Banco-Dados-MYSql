using ConectorSGLinx;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Conector_Banco_de_Dados
{
    public partial class Form1 : Form

    {
        private GroupBox groupBoxMySQL;
        private Button btnCarregarBancos;
        private ComboBox comboBoxBancos;
        private System.Windows.Forms.Label lblBancoDados;
        private GroupBox groupBoxIni;
        private System.Windows.Forms.Label lblbdsenv;
        private ComboBox comboBoxBDesenv;
        private GroupBox groupBoxParAtual;
        private RadioButton radioConexaoAtiva;
        private Button btnGravar;
        private PictureBox pictureBoxLinear;
        private RadioButton radioButtonBdesenv;
        private Button btnRecarregar;
        private RadioButton radioProvider;
        private RadioButton radioCaminhoRel;
        private LinkLabel linklblGitHub;
        private System.Windows.Forms.Label lblMySQLCarregado;
        private IniFile ini;

        public Form1()
        {
            InitializeComponent();
        }

       //// private void Form1_Load(object sender, EventArgs e)
       // {
       //     string iniPath = "C:\\projetos\\SGLinx.ini"; //<-- O caminho onde fica o arquivo na pasta
       //     ini = new IniFile((iniPath));

       //     string bancoAtual = ini.Read("nomebanco");
       //     string bdesenv = ini.Read("bdesenv");

       //     if (!string.IsNullOrEmpty(bancoAtual))
       //     {
       //         radioConexaoAtiva.Checked = true;
       //         radioConexaoAtiva.Text = $"Banco atual: {bancoAtual}";
       //     }

       //     else

       //         radioConexaoAtiva.Checked = false;
       //         radioConexaoAtiva.Text = "Nenhuma conexão ativa";
       // }

       private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMySQL = new System.Windows.Forms.GroupBox();
            this.lblBancoDados = new System.Windows.Forms.Label();
            this.btnCarregarBancos = new System.Windows.Forms.Button();
            this.comboBoxBancos = new System.Windows.Forms.ComboBox();
            this.groupBoxIni = new System.Windows.Forms.GroupBox();
            this.lblbdsenv = new System.Windows.Forms.Label();
            this.comboBoxBDesenv = new System.Windows.Forms.ComboBox();
            this.groupBoxParAtual = new System.Windows.Forms.GroupBox();
            this.lblMySQLCarregado = new System.Windows.Forms.Label();
            this.radioCaminhoRel = new System.Windows.Forms.RadioButton();
            this.radioProvider = new System.Windows.Forms.RadioButton();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.radioButtonBdesenv = new System.Windows.Forms.RadioButton();
            this.radioConexaoAtiva = new System.Windows.Forms.RadioButton();
            this.btnGravar = new System.Windows.Forms.Button();
            this.pictureBoxLinear = new System.Windows.Forms.PictureBox();
            this.linklblGitHub = new System.Windows.Forms.LinkLabel();
            this.groupBoxMySQL.SuspendLayout();
            this.groupBoxIni.SuspendLayout();
            this.groupBoxParAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinear)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMySQL
            // 
            this.groupBoxMySQL.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxMySQL.Controls.Add(this.lblMySQLCarregado);
            this.groupBoxMySQL.Controls.Add(this.lblBancoDados);
            this.groupBoxMySQL.Controls.Add(this.btnCarregarBancos);
            this.groupBoxMySQL.Controls.Add(this.comboBoxBancos);
            this.groupBoxMySQL.Location = new System.Drawing.Point(12, 217);
            this.groupBoxMySQL.Name = "groupBoxMySQL";
            this.groupBoxMySQL.Size = new System.Drawing.Size(253, 149);
            this.groupBoxMySQL.TabIndex = 0;
            this.groupBoxMySQL.TabStop = false;
            this.groupBoxMySQL.Text = "MySQL";
            this.groupBoxMySQL.Enter += new System.EventHandler(this.groupBoxMySQL_Enter);
            // 
            // lblBancoDados
            // 
            this.lblBancoDados.AutoSize = true;
            this.lblBancoDados.Location = new System.Drawing.Point(7, 41);
            this.lblBancoDados.Name = "lblBancoDados";
            this.lblBancoDados.Size = new System.Drawing.Size(146, 13);
            this.lblBancoDados.TabIndex = 2;
            this.lblBancoDados.Text = "Banco de Dados Disponíveis";
            this.lblBancoDados.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCarregarBancos
            // 
            this.btnCarregarBancos.Location = new System.Drawing.Point(172, 120);
            this.btnCarregarBancos.Name = "btnCarregarBancos";
            this.btnCarregarBancos.Size = new System.Drawing.Size(75, 23);
            this.btnCarregarBancos.TabIndex = 1;
            this.btnCarregarBancos.Text = "Carregar";
            this.btnCarregarBancos.UseVisualStyleBackColor = true;
            this.btnCarregarBancos.Click += new System.EventHandler(this.btnCarregarBancos_Click);
            // 
            // comboBoxBancos
            // 
            this.comboBoxBancos.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBancos.FormattingEnabled = true;
            this.comboBoxBancos.Location = new System.Drawing.Point(6, 60);
            this.comboBoxBancos.Name = "comboBoxBancos";
            this.comboBoxBancos.Size = new System.Drawing.Size(241, 21);
            this.comboBoxBancos.TabIndex = 0;
            this.comboBoxBancos.SelectedIndexChanged += new System.EventHandler(this.comboBoxBancos_SelectedIndexChanged_1);
            // 
            // groupBoxIni
            // 
            this.groupBoxIni.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxIni.Controls.Add(this.lblbdsenv);
            this.groupBoxIni.Controls.Add(this.comboBoxBDesenv);
            this.groupBoxIni.Location = new System.Drawing.Point(271, 217);
            this.groupBoxIni.Name = "groupBoxIni";
            this.groupBoxIni.Size = new System.Drawing.Size(283, 149);
            this.groupBoxIni.TabIndex = 1;
            this.groupBoxIni.TabStop = false;
            this.groupBoxIni.Text = "Arquivo .INI";
            this.groupBoxIni.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblbdsenv
            // 
            this.lblbdsenv.AutoSize = true;
            this.lblbdsenv.Location = new System.Drawing.Point(7, 40);
            this.lblbdsenv.Name = "lblbdsenv";
            this.lblbdsenv.Size = new System.Drawing.Size(48, 13);
            this.lblbdsenv.TabIndex = 1;
            this.lblbdsenv.Text = "bdesenv";
            // 
            // comboBoxBDesenv
            // 
            this.comboBoxBDesenv.DisplayMember = "Sim";
            this.comboBoxBDesenv.FormattingEnabled = true;
            this.comboBoxBDesenv.Items.AddRange(new object[] {
            "SIM",
            "NAO"});
            this.comboBoxBDesenv.Location = new System.Drawing.Point(6, 60);
            this.comboBoxBDesenv.Name = "comboBoxBDesenv";
            this.comboBoxBDesenv.Size = new System.Drawing.Size(269, 21);
            this.comboBoxBDesenv.TabIndex = 0;
            this.comboBoxBDesenv.SelectedIndexChanged += new System.EventHandler(this.comboBoxBDesenv_SelectedIndexChanged);
            // 
            // groupBoxParAtual
            // 
            this.groupBoxParAtual.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxParAtual.Controls.Add(this.radioCaminhoRel);
            this.groupBoxParAtual.Controls.Add(this.radioProvider);
            this.groupBoxParAtual.Controls.Add(this.btnRecarregar);
            this.groupBoxParAtual.Controls.Add(this.radioButtonBdesenv);
            this.groupBoxParAtual.Controls.Add(this.radioConexaoAtiva);
            this.groupBoxParAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParAtual.Location = new System.Drawing.Point(12, 12);
            this.groupBoxParAtual.Name = "groupBoxParAtual";
            this.groupBoxParAtual.Size = new System.Drawing.Size(417, 173);
            this.groupBoxParAtual.TabIndex = 2;
            this.groupBoxParAtual.TabStop = false;
            this.groupBoxParAtual.Text = "Parâmetros Atuais";
            // 
            // lblMySQLCarregado
            // 
            this.lblMySQLCarregado.AutoSize = true;
            this.lblMySQLCarregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMySQLCarregado.ForeColor = System.Drawing.Color.Red;
            this.lblMySQLCarregado.Location = new System.Drawing.Point(7, 125);
            this.lblMySQLCarregado.Name = "lblMySQLCarregado";
            this.lblMySQLCarregado.Size = new System.Drawing.Size(136, 13);
            this.lblMySQLCarregado.TabIndex = 5;
            this.lblMySQLCarregado.Text = "MySQL Não Carregado";
            // 
            // radioCaminhoRel
            // 
            this.radioCaminhoRel.AutoSize = true;
            this.radioCaminhoRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCaminhoRel.Location = new System.Drawing.Point(6, 106);
            this.radioCaminhoRel.Name = "radioCaminhoRel";
            this.radioCaminhoRel.Size = new System.Drawing.Size(134, 17);
            this.radioCaminhoRel.TabIndex = 4;
            this.radioCaminhoRel.TabStop = true;
            this.radioCaminhoRel.Text = "Caminho Relatorios";
            this.radioCaminhoRel.UseVisualStyleBackColor = true;
            // 
            // radioProvider
            // 
            this.radioProvider.AutoSize = true;
            this.radioProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioProvider.Location = new System.Drawing.Point(6, 37);
            this.radioProvider.Name = "radioProvider";
            this.radioProvider.Size = new System.Drawing.Size(72, 17);
            this.radioProvider.TabIndex = 3;
            this.radioProvider.TabStop = true;
            this.radioProvider.Text = "Provider";
            this.radioProvider.UseVisualStyleBackColor = true;
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Location = new System.Drawing.Point(323, 144);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(75, 23);
            this.btnRecarregar.TabIndex = 2;
            this.btnRecarregar.Text = "Recarregar";
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // radioButtonBdesenv
            // 
            this.radioButtonBdesenv.AutoSize = true;
            this.radioButtonBdesenv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBdesenv.Location = new System.Drawing.Point(6, 83);
            this.radioButtonBdesenv.Name = "radioButtonBdesenv";
            this.radioButtonBdesenv.Size = new System.Drawing.Size(83, 17);
            this.radioButtonBdesenv.TabIndex = 1;
            this.radioButtonBdesenv.TabStop = true;
            this.radioButtonBdesenv.Text = "BDESENV";
            this.radioButtonBdesenv.UseVisualStyleBackColor = true;
            this.radioButtonBdesenv.CheckedChanged += new System.EventHandler(this.radioButtonBdesenv_CheckedChanged);
            // 
            // radioConexaoAtiva
            // 
            this.radioConexaoAtiva.AutoSize = true;
            this.radioConexaoAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioConexaoAtiva.Location = new System.Drawing.Point(6, 60);
            this.radioConexaoAtiva.Name = "radioConexaoAtiva";
            this.radioConexaoAtiva.Size = new System.Drawing.Size(189, 17);
            this.radioConexaoAtiva.TabIndex = 0;
            this.radioConexaoAtiva.TabStop = true;
            this.radioConexaoAtiva.Text = "Conexão Ativa com o Banco:";
            this.radioConexaoAtiva.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(357, 383);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(189, 23);
            this.btnGravar.TabIndex = 3;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // pictureBoxLinear
            // 
            this.pictureBoxLinear.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxLinear.ErrorImage = null;
            this.pictureBoxLinear.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLinear.Image")));
            this.pictureBoxLinear.InitialImage = null;
            this.pictureBoxLinear.Location = new System.Drawing.Point(435, 12);
            this.pictureBoxLinear.Name = "pictureBoxLinear";
            this.pictureBoxLinear.Size = new System.Drawing.Size(64, 54);
            this.pictureBoxLinear.TabIndex = 4;
            this.pictureBoxLinear.TabStop = false;
            // 
            // linklblGitHub
            // 
            this.linklblGitHub.AutoSize = true;
            this.linklblGitHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblGitHub.Location = new System.Drawing.Point(19, 396);
            this.linklblGitHub.Name = "linklblGitHub";
            this.linklblGitHub.Size = new System.Drawing.Size(101, 13);
            this.linklblGitHub.TabIndex = 2;
            this.linklblGitHub.TabStop = true;
            this.linklblGitHub.Text = "Acesse meu GitHub";
            this.linklblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblGitHub_LinkClicked);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(589, 418);
            this.Controls.Add(this.linklblGitHub);
            this.Controls.Add(this.pictureBoxLinear);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBoxParAtual);
            this.Controls.Add(this.groupBoxIni);
            this.Controls.Add(this.groupBoxMySQL);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMySQL.ResumeLayout(false);
            this.groupBoxMySQL.PerformLayout();
            this.groupBoxIni.ResumeLayout(false);
            this.groupBoxIni.PerformLayout();
            this.groupBoxParAtual.ResumeLayout(false);
            this.groupBoxParAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string iniPath = "C:\\projetos\\SGLinx\\sglinx.ini"; //<-- O caminho onde fica o arquivo na pasta
            ini = new IniFile((iniPath));

            string provider = ini.Read("Provider");
            string bancoAtual = ini.Read("nomebanco");
            string bdesenv = ini.Read("bdesenv");
            string caminhorel = ini.Read("Caminhorel");

            if (!string.IsNullOrEmpty(bancoAtual))
            {
                radioProvider.Text = $"Provider: {provider}";
                radioConexaoAtiva.Checked = true;
                radioConexaoAtiva.Text = $"Banco atual: {bancoAtual}";
                radioButtonBdesenv.Text = $"bdesenv: {bdesenv}";
                radioCaminhoRel.Text = $"Caminhorel: {caminhorel}";
            }

            //else

                //radioConexaoAtiva.Checked = false;
                //radioConexaoAtiva.Text = "Nenhuma conexão ativa";
        }

        private void btnCarregarBancos_Click(object sender, EventArgs e)
        {
            lblBancoDados.Text = "Carregando...";
            CarregarBancosMySQL();
            lblBancoDados.Text = "Carregado";
            lblMySQLCarregado.ForeColor = Color.DarkGreen;
            lblMySQLCarregado.Text = "MySQL Carregado";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxMySQL_Enter(object sender, EventArgs e)
        {
            MessageBox.Show("Este aplicativo não é oficialmente Linear, deve ser utilizaado apenas internamente.");
        }

        //Função para Carregar os Bancos no MySQL
        private void CarregarBancosMySQL()
        {
            //Define a conexão com o servidor do MySQL 
            string connectionString = "server=localhost;user id=teste;password=123;"; //--> Tenho que ver essas inforamções no MySQL

            try
            {
                //Cria e abre a conexão no MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    //Cria e execuata comando SQL para listar todos os bancos de dados
                    MySqlCommand cmd = new MySqlCommand("SHOW DATABASES;", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Limpa os itens atuais do ComboBox antes de adicionar os novos
                    comboBoxBancos.Items.Clear();

                    //Lê cada banco de dados retornado e adicionado ao ComboBox
                    while (reader.Read())
                    {
                        string banco = reader.GetString(0); //--> Pega os nomes dos bancos
                        comboBoxBancos.Items.Add(banco);    //--> Adicona ao ComboBox

                    }

                    //Exibe uma mensagem que deu certo
                    MessageBox.Show("Bancos do MySQL carregados com Sucesso!");
                }
            }
            catch (Exception ex)
            {   
                //Em caso de erro, exebe uma mensagem com o detalhe do erro
                MessageBox.Show($"Não foi possível carregar a lista de Bancode Dados!: {ex.Message}");
            }
        }

        //Função para Recarregar os dados, voltando para o FormLoad
        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            Form1_Load(null, null);
        }

        //Função para Confirmar as alterações no arquivo .INI
        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                //Pegando os Valors do Combobox
                string novoBancoIni = comboBoxBancos.SelectedItem?.ToString();
                string novoBDsenvIni = comboBoxBDesenv.SelectedItem?.ToString();

                //Validação das Informações
                if(string.IsNullOrEmpty(novoBancoIni) || string.IsNullOrEmpty(novoBDsenvIni))
                {
                    MessageBox.Show("Por favor, selecione um banco e o valor para Bdesenv antes de gravar!");
                    return;

                }
                //Gravando as informações no arquivo .INI
                ini.Write("nomebanco", novoBancoIni);
                ini.Write("bdesenv", novoBDsenvIni);

                MessageBox.Show("Configuração salva com sucesso!");

                comboBoxBancos.Text = "";
                comboBoxBDesenv.Text = "";

                //Atualizando o status no RadioButtom - ConexãoAtiva
                btnRecarregar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar as configurações:{ex.Message}");
            }
        }

        private void comboBoxBancos_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxBDesenv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonBdesenv_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void linklblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/brstiago",
                    UseShellExecute = true
                });
        }
                catch (Exception ex)
                {
                
            MessageBox.Show($"Erro ao abrir o link: {ex.Message}");
            }
        }

        private void eventLog1_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}