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
using System.Diagnostics.Eventing.Reader;
using Mysqlx;

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
        private RadioButton radioButtonBdesenv;
        private Button btnRecarregar;
        private RadioButton radioProvider;
        private RadioButton radioCaminhoRel;
        private LinkLabel linklblGitHub;
        private System.Windows.Forms.Label lblMySQLCarregado;
        private PictureBox pictureBoxLogo;
        private IContainer components;
        private System.Windows.Forms.Label lblIniSetting;
        private TextBox txtSenhaSQL;
        private TextBox txtUserSQL;
        private System.Windows.Forms.Label lblSenhaSQL;
        private System.Windows.Forms.Label lblUserSQL;
        private ToolTip toolTip1;
        private PictureBox pictureBoxAjuda;
        private Button btnMyIsam;
        private GroupBox groupEngineMySQL;
        private Button btnInnoDB;
        private IniFile ini;

        //Variaveis Públicas
        public MySqlConnection conn;
        public string bancoAtual;
        public string connectionString;
        public string bdesenv;
        public string caminhorel;
        public string provider;


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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMySQL = new System.Windows.Forms.GroupBox();
            this.btnMyIsam = new System.Windows.Forms.Button();
            this.txtSenhaSQL = new System.Windows.Forms.TextBox();
            this.txtUserSQL = new System.Windows.Forms.TextBox();
            this.lblSenhaSQL = new System.Windows.Forms.Label();
            this.lblUserSQL = new System.Windows.Forms.Label();
            this.lblMySQLCarregado = new System.Windows.Forms.Label();
            this.lblBancoDados = new System.Windows.Forms.Label();
            this.btnCarregarBancos = new System.Windows.Forms.Button();
            this.comboBoxBancos = new System.Windows.Forms.ComboBox();
            this.groupBoxIni = new System.Windows.Forms.GroupBox();
            this.lblIniSetting = new System.Windows.Forms.Label();
            this.lblbdsenv = new System.Windows.Forms.Label();
            this.comboBoxBDesenv = new System.Windows.Forms.ComboBox();
            this.groupBoxParAtual = new System.Windows.Forms.GroupBox();
            this.radioCaminhoRel = new System.Windows.Forms.RadioButton();
            this.radioProvider = new System.Windows.Forms.RadioButton();
            this.radioButtonBdesenv = new System.Windows.Forms.RadioButton();
            this.radioConexaoAtiva = new System.Windows.Forms.RadioButton();
            this.btnRecarregar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.linklblGitHub = new System.Windows.Forms.LinkLabel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBoxAjuda = new System.Windows.Forms.PictureBox();
            this.groupEngineMySQL = new System.Windows.Forms.GroupBox();
            this.btnInnoDB = new System.Windows.Forms.Button();
            this.groupBoxMySQL.SuspendLayout();
            this.groupBoxIni.SuspendLayout();
            this.groupBoxParAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).BeginInit();
            this.groupEngineMySQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxMySQL
            // 
            this.groupBoxMySQL.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxMySQL.Controls.Add(this.groupEngineMySQL);
            this.groupBoxMySQL.Controls.Add(this.txtSenhaSQL);
            this.groupBoxMySQL.Controls.Add(this.txtUserSQL);
            this.groupBoxMySQL.Controls.Add(this.lblSenhaSQL);
            this.groupBoxMySQL.Controls.Add(this.lblUserSQL);
            this.groupBoxMySQL.Controls.Add(this.lblMySQLCarregado);
            this.groupBoxMySQL.Controls.Add(this.lblBancoDados);
            this.groupBoxMySQL.Controls.Add(this.btnCarregarBancos);
            this.groupBoxMySQL.Controls.Add(this.comboBoxBancos);
            this.groupBoxMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMySQL.Location = new System.Drawing.Point(12, 150);
            this.groupBoxMySQL.Name = "groupBoxMySQL";
            this.groupBoxMySQL.Size = new System.Drawing.Size(276, 216);
            this.groupBoxMySQL.TabIndex = 0;
            this.groupBoxMySQL.TabStop = false;
            this.groupBoxMySQL.Text = "MySQL";
            this.groupBoxMySQL.Enter += new System.EventHandler(this.groupBoxMySQL_Enter);
            // 
            // btnMyIsam
            // 
            this.btnMyIsam.Location = new System.Drawing.Point(6, 51);
            this.btnMyIsam.Name = "btnMyIsam";
            this.btnMyIsam.Size = new System.Drawing.Size(120, 23);
            this.btnMyIsam.TabIndex = 10;
            this.btnMyIsam.Text = "Utilizar MyIsam";
            this.toolTip1.SetToolTip(this.btnMyIsam, "Altera o parâmetro \"mysql_engine\".");
            this.btnMyIsam.UseVisualStyleBackColor = true;
            this.btnMyIsam.Click += new System.EventHandler(this.btnMyIsam_Click);
            // 
            // txtSenhaSQL
            // 
            this.txtSenhaSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaSQL.Location = new System.Drawing.Point(197, 16);
            this.txtSenhaSQL.Name = "txtSenhaSQL";
            this.txtSenhaSQL.Size = new System.Drawing.Size(73, 20);
            this.txtSenhaSQL.TabIndex = 9;
            this.txtSenhaSQL.Text = "123";
            this.toolTip1.SetToolTip(this.txtSenhaSQL, "Deve ser configurado um usuário Root no MySQL.");
            // 
            // txtUserSQL
            // 
            this.txtUserSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserSQL.Location = new System.Drawing.Point(58, 16);
            this.txtUserSQL.Name = "txtUserSQL";
            this.txtUserSQL.Size = new System.Drawing.Size(82, 20);
            this.txtUserSQL.TabIndex = 8;
            this.txtUserSQL.Text = "teste";
            this.toolTip1.SetToolTip(this.txtUserSQL, "Deve ser configurado um usuário Root no MySQL.");
            this.txtUserSQL.TextChanged += new System.EventHandler(this.txtUserSQL_TextChanged);
            // 
            // lblSenhaSQL
            // 
            this.lblSenhaSQL.AutoSize = true;
            this.lblSenhaSQL.Location = new System.Drawing.Point(150, 23);
            this.lblSenhaSQL.Name = "lblSenhaSQL";
            this.lblSenhaSQL.Size = new System.Drawing.Size(47, 13);
            this.lblSenhaSQL.TabIndex = 7;
            this.lblSenhaSQL.Text = "Senha:";
            // 
            // lblUserSQL
            // 
            this.lblUserSQL.AutoSize = true;
            this.lblUserSQL.Location = new System.Drawing.Point(6, 23);
            this.lblUserSQL.Name = "lblUserSQL";
            this.lblUserSQL.Size = new System.Drawing.Size(54, 13);
            this.lblUserSQL.TabIndex = 6;
            this.lblUserSQL.Text = "Usuário:";
            // 
            // lblMySQLCarregado
            // 
            this.lblMySQLCarregado.AutoSize = true;
            this.lblMySQLCarregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMySQLCarregado.ForeColor = System.Drawing.Color.Gold;
            this.lblMySQLCarregado.Location = new System.Drawing.Point(7, 98);
            this.lblMySQLCarregado.Name = "lblMySQLCarregado";
            this.lblMySQLCarregado.Size = new System.Drawing.Size(136, 13);
            this.lblMySQLCarregado.TabIndex = 5;
            this.lblMySQLCarregado.Text = "MySQL Não Carregado";
            // 
            // lblBancoDados
            // 
            this.lblBancoDados.AutoSize = true;
            this.lblBancoDados.Location = new System.Drawing.Point(6, 58);
            this.lblBancoDados.Name = "lblBancoDados";
            this.lblBancoDados.Size = new System.Drawing.Size(172, 13);
            this.lblBancoDados.TabIndex = 2;
            this.lblBancoDados.Text = "Banco de Dados Disponíveis";
            this.lblBancoDados.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnCarregarBancos
            // 
            this.btnCarregarBancos.Location = new System.Drawing.Point(185, 101);
            this.btnCarregarBancos.Name = "btnCarregarBancos";
            this.btnCarregarBancos.Size = new System.Drawing.Size(85, 23);
            this.btnCarregarBancos.TabIndex = 1;
            this.btnCarregarBancos.Text = "Carregar";
            this.toolTip1.SetToolTip(this.btnCarregarBancos, "Informe o USUÁRIO e SENHA antes de Carregar");
            this.btnCarregarBancos.UseVisualStyleBackColor = true;
            this.btnCarregarBancos.Click += new System.EventHandler(this.btnCarregarBancos_Click);
            // 
            // comboBoxBancos
            // 
            this.comboBoxBancos.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxBancos.FormattingEnabled = true;
            this.comboBoxBancos.Location = new System.Drawing.Point(6, 74);
            this.comboBoxBancos.Name = "comboBoxBancos";
            this.comboBoxBancos.Size = new System.Drawing.Size(264, 21);
            this.comboBoxBancos.TabIndex = 0;
            this.comboBoxBancos.SelectedIndexChanged += new System.EventHandler(this.comboBoxBancos_SelectedIndexChanged_1);
            // 
            // groupBoxIni
            // 
            this.groupBoxIni.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxIni.Controls.Add(this.lblIniSetting);
            this.groupBoxIni.Controls.Add(this.lblbdsenv);
            this.groupBoxIni.Controls.Add(this.comboBoxBDesenv);
            this.groupBoxIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxIni.Location = new System.Drawing.Point(294, 150);
            this.groupBoxIni.Name = "groupBoxIni";
            this.groupBoxIni.Size = new System.Drawing.Size(283, 216);
            this.groupBoxIni.TabIndex = 1;
            this.groupBoxIni.TabStop = false;
            this.groupBoxIni.Text = "Arquivo .INI";
            this.groupBoxIni.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblIniSetting
            // 
            this.lblIniSetting.AutoSize = true;
            this.lblIniSetting.Location = new System.Drawing.Point(214, 16);
            this.lblIniSetting.Name = "lblIniSetting";
            this.lblIniSetting.Size = new System.Drawing.Size(61, 13);
            this.lblIniSetting.TabIndex = 2;
            this.lblIniSetting.Text = "[Settings]";
            // 
            // lblbdsenv
            // 
            this.lblbdsenv.AutoSize = true;
            this.lblbdsenv.Location = new System.Drawing.Point(6, 58);
            this.lblbdsenv.Name = "lblbdsenv";
            this.lblbdsenv.Size = new System.Drawing.Size(55, 13);
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
            this.comboBoxBDesenv.Location = new System.Drawing.Point(6, 74);
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
            this.groupBoxParAtual.Controls.Add(this.radioButtonBdesenv);
            this.groupBoxParAtual.Controls.Add(this.radioConexaoAtiva);
            this.groupBoxParAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParAtual.Location = new System.Drawing.Point(12, 10);
            this.groupBoxParAtual.Name = "groupBoxParAtual";
            this.groupBoxParAtual.Size = new System.Drawing.Size(423, 134);
            this.groupBoxParAtual.TabIndex = 2;
            this.groupBoxParAtual.TabStop = false;
            this.groupBoxParAtual.Text = "Parâmetros Atuais";
            this.groupBoxParAtual.Enter += new System.EventHandler(this.groupBoxParAtual_Enter);
            // 
            // radioCaminhoRel
            // 
            this.radioCaminhoRel.AutoSize = true;
            this.radioCaminhoRel.Enabled = false;
            this.radioCaminhoRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioCaminhoRel.Location = new System.Drawing.Point(6, 106);
            this.radioCaminhoRel.Name = "radioCaminhoRel";
            this.radioCaminhoRel.Size = new System.Drawing.Size(100, 17);
            this.radioCaminhoRel.TabIndex = 4;
            this.radioCaminhoRel.TabStop = true;
            this.radioCaminhoRel.Text = "Caminho Rel:";
            this.radioCaminhoRel.UseVisualStyleBackColor = true;
            this.radioCaminhoRel.CheckedChanged += new System.EventHandler(this.radioCaminhoRel_CheckedChanged);
            // 
            // radioProvider
            // 
            this.radioProvider.AutoSize = true;
            this.radioProvider.Enabled = false;
            this.radioProvider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioProvider.Location = new System.Drawing.Point(6, 37);
            this.radioProvider.Name = "radioProvider";
            this.radioProvider.Size = new System.Drawing.Size(72, 17);
            this.radioProvider.TabIndex = 3;
            this.radioProvider.TabStop = true;
            this.radioProvider.Text = "Provider";
            this.radioProvider.UseVisualStyleBackColor = true;
            this.radioProvider.CheckedChanged += new System.EventHandler(this.radioProvider_CheckedChanged);
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
            this.toolTip1.SetToolTip(this.radioButtonBdesenv, "Selecione um valor para a chave para gravar");
            this.radioButtonBdesenv.UseVisualStyleBackColor = true;
            this.radioButtonBdesenv.CheckedChanged += new System.EventHandler(this.radioButtonBdesenv_CheckedChanged);
            // 
            // radioConexaoAtiva
            // 
            this.radioConexaoAtiva.AutoSize = true;
            this.radioConexaoAtiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioConexaoAtiva.Location = new System.Drawing.Point(6, 60);
            this.radioConexaoAtiva.Name = "radioConexaoAtiva";
            this.radioConexaoAtiva.Size = new System.Drawing.Size(185, 17);
            this.radioConexaoAtiva.TabIndex = 0;
            this.radioConexaoAtiva.TabStop = true;
            this.radioConexaoAtiva.Text = "Conexão Ativa com o Banco";
            this.toolTip1.SetToolTip(this.radioConexaoAtiva, "Selecione um banco de dados para gravar");
            this.radioConexaoAtiva.UseVisualStyleBackColor = true;
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Location = new System.Drawing.Point(332, 383);
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.Size = new System.Drawing.Size(95, 23);
            this.btnRecarregar.TabIndex = 2;
            this.btnRecarregar.Text = "Recarregar";
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravar.Location = new System.Drawing.Point(433, 383);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(113, 23);
            this.btnGravar.TabIndex = 3;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
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
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(537, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 42);
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipGeral_Popup);
            // 
            // pictureBoxAjuda
            // 
            this.pictureBoxAjuda.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAjuda.Image")));
            this.pictureBoxAjuda.Location = new System.Drawing.Point(125, 383);
            this.pictureBoxAjuda.Name = "pictureBoxAjuda";
            this.pictureBoxAjuda.Size = new System.Drawing.Size(27, 26);
            this.pictureBoxAjuda.TabIndex = 6;
            this.pictureBoxAjuda.TabStop = false;
            this.pictureBoxAjuda.Click += new System.EventHandler(this.pictureBoxAjuda_Click);
            // 
            // groupEngineMySQL
            // 
            this.groupEngineMySQL.Controls.Add(this.btnInnoDB);
            this.groupEngineMySQL.Controls.Add(this.btnMyIsam);
            this.groupEngineMySQL.Location = new System.Drawing.Point(6, 130);
            this.groupEngineMySQL.Name = "groupEngineMySQL";
            this.groupEngineMySQL.Size = new System.Drawing.Size(264, 80);
            this.groupEngineMySQL.TabIndex = 11;
            this.groupEngineMySQL.TabStop = false;
            this.groupEngineMySQL.Text = "EngineMySQL";
            // 
            // btnInnoDB
            // 
            this.btnInnoDB.Location = new System.Drawing.Point(146, 51);
            this.btnInnoDB.Name = "btnInnoDB";
            this.btnInnoDB.Size = new System.Drawing.Size(112, 23);
            this.btnInnoDB.TabIndex = 11;
            this.btnInnoDB.Text = "Utilizar InnoDB";
            this.toolTip1.SetToolTip(this.btnInnoDB, "Altera o parâmetro \"mysql_engine\".\r\n");
            this.btnInnoDB.UseVisualStyleBackColor = true;
            this.btnInnoDB.Click += new System.EventHandler(this.btnInnoDB_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(589, 418);
            this.Controls.Add(this.pictureBoxAjuda);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.linklblGitHub);
            this.Controls.Add(this.btnRecarregar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBoxParAtual);
            this.Controls.Add(this.groupBoxIni);
            this.Controls.Add(this.groupBoxMySQL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMySQL.ResumeLayout(false);
            this.groupBoxMySQL.PerformLayout();
            this.groupBoxIni.ResumeLayout(false);
            this.groupBoxIni.PerformLayout();
            this.groupBoxParAtual.ResumeLayout(false);
            this.groupBoxParAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).EndInit();
            this.groupEngineMySQL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string iniPath = "C:\\projetos\\SGLinx\\sglinx.ini"; //<-- O caminho onde fica o arquivo na pasta
            ini = new IniFile((iniPath));

             provider = ini.Read("Provider");
             bancoAtual = ini.Read("nomebanco");
             bdesenv = ini.Read("bdesenv");
             caminhorel = ini.Read("Caminhorel");

            if (!string.IsNullOrEmpty(bancoAtual))
            {
                radioProvider.Text = $"Provider: {provider}";
                radioConexaoAtiva.Checked = true;
                radioConexaoAtiva.Text = $"Banco atual: {bancoAtual}";
                radioButtonBdesenv.Text = $"bdesenv: {bdesenv}";
                radioCaminhoRel.Text = $"Caminhorel: {caminhorel}";
            }
            else if (string.IsNullOrEmpty(bancoAtual))
            {
                radioConexaoAtiva.Checked = false;
                radioButtonBdesenv.Checked = true;
                radioConexaoAtiva.Text = "Nenhum banco de dados encontrado";
            }
        }
        private void btnCarregarBancos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserSQL.Text))
            {
                MessageBox.Show("Informe o Usuário do Banco de Dados!");
                return;
            }
            else if (string.IsNullOrEmpty(txtSenhaSQL.Text))
            {
                MessageBox.Show("Informe a Senha do Banco de Dados!");
                return;
            }
            lblBancoDados.Text = "Carregando...";
            
            //Declarando variável para controlar de a função têve êxito ou não:
            bool bError = false;
            bool bCarregado = false;

            CarregarBancosMySQL(ref bError, bCarregado);
            if (bError)
            {
                txtUserSQL.Text = "";
                txtSenhaSQL.Text = "";
                lblBancoDados.Text = "Erro ao Carregar";
                lblMySQLCarregado.ForeColor = Color.OrangeRed;
                return;
            }
            lblBancoDados.Text = "Carregado";
            lblMySQLCarregado.ForeColor = Color.Green;
            lblMySQLCarregado.Text = "MySQL Carregado";
       }
        //Função para Carregar os Bancos no MySQL
        private void CarregarBancosMySQL(ref bool bError, bool bCarregado)

        {
                //Define a conexão com o servidor do MySQL 
                string connectionString = $"Server=localhost;User Id={txtUserSQL.Text};Password={txtSenhaSQL.Text};";

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
                    bError = false;
                    return;
                }
            }
            catch (Exception ex)
            {   
                //Em caso de erro, exebe uma mensagem com o detalhe do erro
                MessageBox.Show($"Não foi possível carregar a lista de Bancode Dados!: {ex.Message}");
                 bError = true;
            }
        }

        //Função para Recarregar os dados, voltando para o FormLoad
        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            txtUserSQL.Text = "";
            txtSenhaSQL.Text = "";
            comboBoxBancos.Text = "";
            comboBoxBDesenv.Text = "";
            lblBancoDados.Text = "MySQL Não Carregado";
            lblMySQLCarregado.ForeColor = Color.LightGoldenrodYellow;
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

                    //Testa qua opção está selecionada e preenchida - Verifica se Banco
                if (string.IsNullOrEmpty(novoBancoIni))
                {
                    novoBancoIni = ini.Read("nomebanco");
                }
                //Testa qua opção está selecionada e preenchida - Verifica se Bdsenv
                if (string.IsNullOrEmpty(novoBDsenvIni))
                {
                    novoBDsenvIni = ini.Read("bdesenv");
                return;
            }
                //Validação das Informações
                if (radioButtonBdesenv.Checked && string.IsNullOrEmpty(comboBoxBDesenv.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Por favor, selecione um valor para a chave bdesenv antes de Gravar!");
                    return;
                }
                else if
                    (radioConexaoAtiva.Checked && string.IsNullOrEmpty(comboBoxBancos.SelectedItem?.ToString()))
                {
                    MessageBox.Show("Por favor, selecione um banco de dados antes de Gravar!");
                    return;
                }

                //Gravando as informações no arquivo .INI
                ini.Write("nomebanco", novoBancoIni);
                ini.Write("bdesenv", novoBDsenvIni);

                MessageBox.Show("Configuração salva com sucesso!");

                comboBoxBancos.Text = "";
                comboBoxBDesenv.Text = "";

                //Atualizando o status no RadioButtom - ConexãoAtiva
                Form1_Load(null, null);
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
        private void groupBoxParAtual_Enter(object sender, EventArgs e)
        {

        }

        private void radioProvider_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioCaminhoRel_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxMySQL_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("Este aplicativo não é oficialmente Linear, deve ser utilizaado apenas internamente.");
        }

        private void txtUserSQL_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolTipGeral_Popup(object sender, PopupEventArgs e)
        {
            toolTip1.AutoPopDelay = 5000;  // Tempo que o tooltip fica visível (ms)
            toolTip1.InitialDelay = 500;   // Tempo de espera antes de aparecer (ms)
            toolTip1.ReshowDelay = 200;    // Tempo entre um tooltip e outro (ms)
            toolTip1.ShowAlways = true;
        }

        private void pictureBoxAjuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este aplicativo não é oficialmente LINEAR, deve ser utilizaado apenas internamente.");
        }

        //Evento do botão MyIsam
        private void btnMyIsam_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeBanco = radioConexaoAtiva.Text;

                //Formatar o nome do banco para ser compatível com utilizado no Heide
                nomeBanco = radioConexaoAtiva.Text.Replace("Banco atual: ", "").Split('(')[0].Trim();

                // Aqui você monta a connection string corretamente
                string connectionString = $"Server=localhost;User Id={txtUserSQL.Text};Password={txtSenhaSQL.Text};database={nomeBanco};";

                // Abrindo conexão com o MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Realizando atualização do valor do Parâmetro
                    string sql = "UPDATE parametro SET pr_valor = 'myisam' WHERE pr_chave = 'mysql_engine'";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Parâmetro atualizado com sucesso! Linhas afetadas: {linhasAfetadas}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar parâmetro:\n{ex.Message}");
            }
        }

        //Evento do botão Inoodb
        private void btnInnoDB_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeBanco = radioConexaoAtiva.Text;

                //Formatar o nome do banco para ser compatível com utilizado no Heide
                nomeBanco = radioConexaoAtiva.Text.Replace("Banco atual: ", "").Split('(')[0].Trim();

                // Aqui você monta a connection string corretamente
                string connectionString = $"Server=localhost;User Id={txtUserSQL.Text};Password={txtSenhaSQL.Text};database={nomeBanco};";

                // Abrindo conexão com o MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Realizando atualização do valor do Parâmetro
                    string sql = "UPDATE parametro SET pr_valor = 'innodb' WHERE pr_chave = 'mysql_engine'";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        int linhasAfetadas = cmd.ExecuteNonQuery();
                        MessageBox.Show($"Parâmetro atualizado com sucesso! Linhas afetadas: {linhasAfetadas}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar parâmetro:\n{ex.Message}");
            }
        }

    }
    }