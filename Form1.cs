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
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Drawing.Drawing2D;
using MaterialSkin;
using MaterialSkin.Controls;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Conector_Banco_de_Dados
{
    public partial class Form1 : MaterialForm
    //public partial class Form1 : Form
    {
        private GroupBox groupBoxMySQL;
        private System.Windows.Forms.Label lblBancoDados;
        private GroupBox groupBoxIni;
        private System.Windows.Forms.Label lblbdsenv;
        private GroupBox groupBoxParAtual;
        private LinkLabel linklblGitHub;
        private System.Windows.Forms.Label lblMySQLCarregado;
        private PictureBox pictureBoxLogo;
        private IContainer components;
        private TextBox txtSenhaSQL;
        private TextBox txtUserSQL;
        private System.Windows.Forms.Label lblSenhaSQL;
        private System.Windows.Forms.Label lblUserSQL;
        private ToolTip toolTip1;
        private PictureBox pictureBoxAjuda;
        private IniFile ini;

        //Variaveis Públicas
        public MySqlConnection conn;
        public string bancoAtual;
        public string connectionString;
        public string bdesenv;
        public string caminhorel;
        private ProgressBar progressBarLoad;
        private PictureBox pictureBoxLinear;
        private GroupBox groupCreateMySQL;
        public string provider;
        bool bError = false;
        bool bCarregado = false;
        private MaterialButton btnExecutarViews;
        private MaterialButton btnRecarregaMySQL;
        private MaterialButton btnRecarregar;
        private MaterialButton btnSair;
        private MaterialSwitch swtUtilizaMyIsam;
        private MaterialSwitch swtUtilizaInnodb;
        private MaterialSwitch swtEstReservado;
        private MaterialSwitch swtEstReservadoItens;
        private MaterialSwitch swtUserLinear;
        private MaterialButton btnGravar;
        private MaterialComboBox comboBoxBDesenv;
        private MaterialComboBox comboBoxBancos;
        private MaterialRadioButton radioButtonBdesenv;
        private MaterialRadioButton radioConexaoAtiva;
        private MaterialRadioButton radioCaminhoRel;
        private MaterialRadioButton radioProvider;
        public string nomeBanco;

        public Form1()
        {
            InitializeComponent();
        }

       private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBoxMySQL = new System.Windows.Forms.GroupBox();
            this.groupCreateMySQL = new System.Windows.Forms.GroupBox();
            this.swtUserLinear = new MaterialSkin.Controls.MaterialSwitch();
            this.swtEstReservadoItens = new MaterialSkin.Controls.MaterialSwitch();
            this.swtEstReservado = new MaterialSkin.Controls.MaterialSwitch();
            this.swtUtilizaInnodb = new MaterialSkin.Controls.MaterialSwitch();
            this.swtUtilizaMyIsam = new MaterialSkin.Controls.MaterialSwitch();
            this.txtSenhaSQL = new System.Windows.Forms.TextBox();
            this.txtUserSQL = new System.Windows.Forms.TextBox();
            this.lblSenhaSQL = new System.Windows.Forms.Label();
            this.lblUserSQL = new System.Windows.Forms.Label();
            this.btnExecutarViews = new MaterialSkin.Controls.MaterialButton();
            this.lblMySQLCarregado = new System.Windows.Forms.Label();
            this.lblBancoDados = new System.Windows.Forms.Label();
            this.groupBoxIni = new System.Windows.Forms.GroupBox();
            this.comboBoxBancos = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxBDesenv = new MaterialSkin.Controls.MaterialComboBox();
            this.btnGravar = new MaterialSkin.Controls.MaterialButton();
            this.lblbdsenv = new System.Windows.Forms.Label();
            this.groupBoxParAtual = new System.Windows.Forms.GroupBox();
            this.radioButtonBdesenv = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioConexaoAtiva = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioCaminhoRel = new MaterialSkin.Controls.MaterialRadioButton();
            this.radioProvider = new MaterialSkin.Controls.MaterialRadioButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjuda = new System.Windows.Forms.PictureBox();
            this.linklblGitHub = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.pictureBoxLinear = new System.Windows.Forms.PictureBox();
            this.btnRecarregaMySQL = new MaterialSkin.Controls.MaterialButton();
            this.btnRecarregar = new MaterialSkin.Controls.MaterialButton();
            this.btnSair = new MaterialSkin.Controls.MaterialButton();
            this.groupBoxMySQL.SuspendLayout();
            this.groupCreateMySQL.SuspendLayout();
            this.groupBoxIni.SuspendLayout();
            this.groupBoxParAtual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinear)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxMySQL
            // 
            this.groupBoxMySQL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxMySQL.Controls.Add(this.groupCreateMySQL);
            this.groupBoxMySQL.Controls.Add(this.txtSenhaSQL);
            this.groupBoxMySQL.Controls.Add(this.txtUserSQL);
            this.groupBoxMySQL.Controls.Add(this.lblSenhaSQL);
            this.groupBoxMySQL.Controls.Add(this.lblUserSQL);
            this.groupBoxMySQL.Controls.Add(this.btnExecutarViews);
            this.groupBoxMySQL.Controls.Add(this.lblMySQLCarregado);
            this.groupBoxMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxMySQL.Location = new System.Drawing.Point(312, 67);
            this.groupBoxMySQL.Name = "groupBoxMySQL";
            this.groupBoxMySQL.Size = new System.Drawing.Size(287, 383);
            this.groupBoxMySQL.TabIndex = 0;
            this.groupBoxMySQL.TabStop = false;
            this.groupBoxMySQL.Text = "MySQL";
            this.groupBoxMySQL.Enter += new System.EventHandler(this.groupBoxMySQL_Enter);
            // 
            // groupCreateMySQL
            // 
            this.groupCreateMySQL.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupCreateMySQL.Controls.Add(this.swtUserLinear);
            this.groupCreateMySQL.Controls.Add(this.swtEstReservadoItens);
            this.groupCreateMySQL.Controls.Add(this.swtEstReservado);
            this.groupCreateMySQL.Controls.Add(this.swtUtilizaInnodb);
            this.groupCreateMySQL.Controls.Add(this.swtUtilizaMyIsam);
            this.groupCreateMySQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupCreateMySQL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupCreateMySQL.Location = new System.Drawing.Point(6, 74);
            this.groupCreateMySQL.Name = "groupCreateMySQL";
            this.groupCreateMySQL.Size = new System.Drawing.Size(273, 256);
            this.groupCreateMySQL.TabIndex = 12;
            this.groupCreateMySQL.TabStop = false;
            this.groupCreateMySQL.Text = "Create Viwes/Procedures";
            // 
            // swtUserLinear
            // 
            this.swtUserLinear.AutoSize = true;
            this.swtUserLinear.Depth = 0;
            this.swtUserLinear.Location = new System.Drawing.Point(7, 157);
            this.swtUserLinear.Margin = new System.Windows.Forms.Padding(0);
            this.swtUserLinear.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtUserLinear.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtUserLinear.Name = "swtUserLinear";
            this.swtUserLinear.Ripple = true;
            this.swtUserLinear.Size = new System.Drawing.Size(248, 37);
            this.swtUserLinear.TabIndex = 11;
            this.swtUserLinear.Text = "Usuário Linear | Senha 123";
            this.toolTip1.SetToolTip(this.swtUserLinear, "Aplicar senha \"xyz\" para usuários Linear");
            this.swtUserLinear.UseVisualStyleBackColor = true;
            // 
            // swtEstReservadoItens
            // 
            this.swtEstReservadoItens.AutoSize = true;
            this.swtEstReservadoItens.Depth = 0;
            this.swtEstReservadoItens.Location = new System.Drawing.Point(7, 120);
            this.swtEstReservadoItens.Margin = new System.Windows.Forms.Padding(0);
            this.swtEstReservadoItens.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtEstReservadoItens.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtEstReservadoItens.Name = "swtEstReservadoItens";
            this.swtEstReservadoItens.Ripple = true;
            this.swtEstReservadoItens.Size = new System.Drawing.Size(250, 37);
            this.swtEstReservadoItens.TabIndex = 10;
            this.swtEstReservadoItens.Text = "View- Est. Reservados Itens";
            this.toolTip1.SetToolTip(this.swtEstReservadoItens, "Criar Views");
            this.swtEstReservadoItens.UseVisualStyleBackColor = true;
            // 
            // swtEstReservado
            // 
            this.swtEstReservado.AutoSize = true;
            this.swtEstReservado.Depth = 0;
            this.swtEstReservado.Location = new System.Drawing.Point(7, 90);
            this.swtEstReservado.Margin = new System.Windows.Forms.Padding(0);
            this.swtEstReservado.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtEstReservado.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtEstReservado.Name = "swtEstReservado";
            this.swtEstReservado.Ripple = true;
            this.swtEstReservado.Size = new System.Drawing.Size(212, 37);
            this.swtEstReservado.TabIndex = 9;
            this.swtEstReservado.Text = "View- Est. Reservados";
            this.toolTip1.SetToolTip(this.swtEstReservado, "Criar Views");
            this.swtEstReservado.UseVisualStyleBackColor = true;
            this.swtEstReservado.CheckedChanged += new System.EventHandler(this.swtEstReservado_CheckedChanged);
            // 
            // swtUtilizaInnodb
            // 
            this.swtUtilizaInnodb.AutoSize = true;
            this.swtUtilizaInnodb.Depth = 0;
            this.swtUtilizaInnodb.Location = new System.Drawing.Point(7, 53);
            this.swtUtilizaInnodb.Margin = new System.Windows.Forms.Padding(0);
            this.swtUtilizaInnodb.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtUtilizaInnodb.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtUtilizaInnodb.Name = "swtUtilizaInnodb";
            this.swtUtilizaInnodb.Ripple = true;
            this.swtUtilizaInnodb.Size = new System.Drawing.Size(160, 37);
            this.swtUtilizaInnodb.TabIndex = 8;
            this.swtUtilizaInnodb.Text = "Utilizar Innodb";
            this.toolTip1.SetToolTip(this.swtUtilizaInnodb, "Alterar valor parâmetro \"MySQL_Engine\"");
            this.swtUtilizaInnodb.UseVisualStyleBackColor = true;
            this.swtUtilizaInnodb.CheckedChanged += new System.EventHandler(this.swtUtilizaInnodb_CheckedChanged);
            // 
            // swtUtilizaMyIsam
            // 
            this.swtUtilizaMyIsam.AutoSize = true;
            this.swtUtilizaMyIsam.Depth = 0;
            this.swtUtilizaMyIsam.Location = new System.Drawing.Point(7, 23);
            this.swtUtilizaMyIsam.Margin = new System.Windows.Forms.Padding(0);
            this.swtUtilizaMyIsam.MouseLocation = new System.Drawing.Point(-1, -1);
            this.swtUtilizaMyIsam.MouseState = MaterialSkin.MouseState.HOVER;
            this.swtUtilizaMyIsam.Name = "swtUtilizaMyIsam";
            this.swtUtilizaMyIsam.Ripple = true;
            this.swtUtilizaMyIsam.Size = new System.Drawing.Size(168, 37);
            this.swtUtilizaMyIsam.TabIndex = 7;
            this.swtUtilizaMyIsam.Text = "Utilizar MyIsam";
            this.toolTip1.SetToolTip(this.swtUtilizaMyIsam, "Alterar valor parâmetro \"MySQL_Engine\"");
            this.swtUtilizaMyIsam.UseVisualStyleBackColor = true;
            this.swtUtilizaMyIsam.CheckedChanged += new System.EventHandler(this.swtUtilizaMyIsam_CheckedChanged);
            // 
            // txtSenhaSQL
            // 
            this.txtSenhaSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaSQL.Location = new System.Drawing.Point(204, 20);
            this.txtSenhaSQL.Name = "txtSenhaSQL";
            this.txtSenhaSQL.Size = new System.Drawing.Size(75, 20);
            this.txtSenhaSQL.TabIndex = 9;
            this.txtSenhaSQL.Text = "123";
            this.txtSenhaSQL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtSenhaSQL, "Deve ser configurado um usuário Root no MySQL.");
            // 
            // txtUserSQL
            // 
            this.txtUserSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserSQL.Location = new System.Drawing.Point(63, 19);
            this.txtUserSQL.Name = "txtUserSQL";
            this.txtUserSQL.Size = new System.Drawing.Size(82, 20);
            this.txtUserSQL.TabIndex = 8;
            this.txtUserSQL.Text = "teste";
            this.txtUserSQL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.txtUserSQL, "Deve ser configurado um usuário Root no MySQL.");
            this.txtUserSQL.TextChanged += new System.EventHandler(this.txtUserSQL_TextChanged);
            // 
            // lblSenhaSQL
            // 
            this.lblSenhaSQL.AutoSize = true;
            this.lblSenhaSQL.Location = new System.Drawing.Point(151, 26);
            this.lblSenhaSQL.Name = "lblSenhaSQL";
            this.lblSenhaSQL.Size = new System.Drawing.Size(47, 13);
            this.lblSenhaSQL.TabIndex = 7;
            this.lblSenhaSQL.Text = "Senha:";
            // 
            // lblUserSQL
            // 
            this.lblUserSQL.AutoSize = true;
            this.lblUserSQL.Location = new System.Drawing.Point(6, 27);
            this.lblUserSQL.Name = "lblUserSQL";
            this.lblUserSQL.Size = new System.Drawing.Size(54, 13);
            this.lblUserSQL.TabIndex = 6;
            this.lblUserSQL.Text = "Usuário:";
            // 
            // btnExecutarViews
            // 
            this.btnExecutarViews.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExecutarViews.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnExecutarViews.Depth = 0;
            this.btnExecutarViews.HighEmphasis = true;
            this.btnExecutarViews.Icon = null;
            this.btnExecutarViews.Location = new System.Drawing.Point(7, 344);
            this.btnExecutarViews.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnExecutarViews.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExecutarViews.Name = "btnExecutarViews";
            this.btnExecutarViews.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnExecutarViews.Size = new System.Drawing.Size(95, 36);
            this.btnExecutarViews.TabIndex = 6;
            this.btnExecutarViews.Text = "Executar";
            this.toolTip1.SetToolTip(this.btnExecutarViews, "Aplica as configurações de Views/Procedure");
            this.btnExecutarViews.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnExecutarViews.UseAccentColor = false;
            this.btnExecutarViews.UseVisualStyleBackColor = true;
            this.btnExecutarViews.Click += new System.EventHandler(this.btnExecutarViews_Click_2);
            // 
            // lblMySQLCarregado
            // 
            this.lblMySQLCarregado.AutoSize = true;
            this.lblMySQLCarregado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMySQLCarregado.ForeColor = System.Drawing.Color.Gold;
            this.lblMySQLCarregado.Location = new System.Drawing.Point(60, 56);
            this.lblMySQLCarregado.Name = "lblMySQLCarregado";
            this.lblMySQLCarregado.Size = new System.Drawing.Size(153, 15);
            this.lblMySQLCarregado.TabIndex = 5;
            this.lblMySQLCarregado.Text = "MySQL Não Carregado";
            // 
            // lblBancoDados
            // 
            this.lblBancoDados.AutoSize = true;
            this.lblBancoDados.Location = new System.Drawing.Point(3, 105);
            this.lblBancoDados.Name = "lblBancoDados";
            this.lblBancoDados.Size = new System.Drawing.Size(172, 13);
            this.lblBancoDados.TabIndex = 2;
            this.lblBancoDados.Text = "Banco de Dados Disponíveis";
            this.lblBancoDados.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBoxIni
            // 
            this.groupBoxIni.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxIni.Controls.Add(this.comboBoxBancos);
            this.groupBoxIni.Controls.Add(this.comboBoxBDesenv);
            this.groupBoxIni.Controls.Add(this.btnGravar);
            this.groupBoxIni.Controls.Add(this.lblbdsenv);
            this.groupBoxIni.Controls.Add(this.lblBancoDados);
            this.groupBoxIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxIni.Location = new System.Drawing.Point(4, 237);
            this.groupBoxIni.Name = "groupBoxIni";
            this.groupBoxIni.Size = new System.Drawing.Size(303, 213);
            this.groupBoxIni.TabIndex = 1;
            this.groupBoxIni.TabStop = false;
            this.groupBoxIni.Text = "Arquivo .INI";
            this.groupBoxIni.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // comboBoxBancos
            // 
            this.comboBoxBancos.AutoResize = false;
            this.comboBoxBancos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxBancos.Depth = 0;
            this.comboBoxBancos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxBancos.DropDownHeight = 174;
            this.comboBoxBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBancos.DropDownWidth = 121;
            this.comboBoxBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxBancos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxBancos.FormattingEnabled = true;
            this.comboBoxBancos.IntegralHeight = false;
            this.comboBoxBancos.ItemHeight = 43;
            this.comboBoxBancos.Location = new System.Drawing.Point(6, 124);
            this.comboBoxBancos.MaxDropDownItems = 4;
            this.comboBoxBancos.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxBancos.Name = "comboBoxBancos";
            this.comboBoxBancos.Size = new System.Drawing.Size(290, 49);
            this.comboBoxBancos.StartIndex = 0;
            this.comboBoxBancos.TabIndex = 13;
            // 
            // comboBoxBDesenv
            // 
            this.comboBoxBDesenv.AutoResize = false;
            this.comboBoxBDesenv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxBDesenv.Depth = 0;
            this.comboBoxBDesenv.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxBDesenv.DropDownHeight = 174;
            this.comboBoxBDesenv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBDesenv.DropDownWidth = 121;
            this.comboBoxBDesenv.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxBDesenv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxBDesenv.FormattingEnabled = true;
            this.comboBoxBDesenv.IntegralHeight = false;
            this.comboBoxBDesenv.ItemHeight = 43;
            this.comboBoxBDesenv.Items.AddRange(new object[] {
            "SIM",
            "NÃO"});
            this.comboBoxBDesenv.Location = new System.Drawing.Point(6, 44);
            this.comboBoxBDesenv.MaxDropDownItems = 4;
            this.comboBoxBDesenv.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxBDesenv.Name = "comboBoxBDesenv";
            this.comboBoxBDesenv.Size = new System.Drawing.Size(290, 49);
            this.comboBoxBDesenv.StartIndex = 0;
            this.comboBoxBDesenv.TabIndex = 12;
            // 
            // btnGravar
            // 
            this.btnGravar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGravar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGravar.Depth = 0;
            this.btnGravar.HighEmphasis = true;
            this.btnGravar.Icon = null;
            this.btnGravar.Location = new System.Drawing.Point(9, 174);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGravar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGravar.Size = new System.Drawing.Size(78, 36);
            this.btnGravar.TabIndex = 12;
            this.btnGravar.Text = "Gravar";
            this.toolTip1.SetToolTip(this.btnGravar, "Aplica as configurações no arquivo .INI");
            this.btnGravar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnGravar.UseAccentColor = false;
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click_1);
            // 
            // lblbdsenv
            // 
            this.lblbdsenv.AutoSize = true;
            this.lblbdsenv.Location = new System.Drawing.Point(6, 25);
            this.lblbdsenv.Name = "lblbdsenv";
            this.lblbdsenv.Size = new System.Drawing.Size(55, 13);
            this.lblbdsenv.TabIndex = 1;
            this.lblbdsenv.Text = "bdesenv";
            // 
            // groupBoxParAtual
            // 
            this.groupBoxParAtual.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxParAtual.Controls.Add(this.radioButtonBdesenv);
            this.groupBoxParAtual.Controls.Add(this.radioConexaoAtiva);
            this.groupBoxParAtual.Controls.Add(this.radioCaminhoRel);
            this.groupBoxParAtual.Controls.Add(this.radioProvider);
            this.groupBoxParAtual.Controls.Add(this.pictureBoxLogo);
            this.groupBoxParAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxParAtual.Location = new System.Drawing.Point(4, 67);
            this.groupBoxParAtual.Name = "groupBoxParAtual";
            this.groupBoxParAtual.Size = new System.Drawing.Size(303, 164);
            this.groupBoxParAtual.TabIndex = 2;
            this.groupBoxParAtual.TabStop = false;
            this.groupBoxParAtual.Text = "Parâmetros Atuais";
            this.groupBoxParAtual.Enter += new System.EventHandler(this.groupBoxParAtual_Enter);
            // 
            // radioButtonBdesenv
            // 
            this.radioButtonBdesenv.AutoSize = true;
            this.radioButtonBdesenv.Depth = 0;
            this.radioButtonBdesenv.Location = new System.Drawing.Point(3, 127);
            this.radioButtonBdesenv.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonBdesenv.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioButtonBdesenv.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioButtonBdesenv.Name = "radioButtonBdesenv";
            this.radioButtonBdesenv.Ripple = true;
            this.radioButtonBdesenv.Size = new System.Drawing.Size(96, 37);
            this.radioButtonBdesenv.TabIndex = 16;
            this.radioButtonBdesenv.TabStop = true;
            this.radioButtonBdesenv.Text = "BDSENV";
            this.toolTip1.SetToolTip(this.radioButtonBdesenv, "Obriga informação de BDESENV");
            this.radioButtonBdesenv.UseVisualStyleBackColor = true;
            // 
            // radioConexaoAtiva
            // 
            this.radioConexaoAtiva.AutoSize = true;
            this.radioConexaoAtiva.Depth = 0;
            this.radioConexaoAtiva.Location = new System.Drawing.Point(3, 90);
            this.radioConexaoAtiva.Margin = new System.Windows.Forms.Padding(0);
            this.radioConexaoAtiva.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioConexaoAtiva.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioConexaoAtiva.Name = "radioConexaoAtiva";
            this.radioConexaoAtiva.Ripple = true;
            this.radioConexaoAtiva.Size = new System.Drawing.Size(137, 37);
            this.radioConexaoAtiva.TabIndex = 15;
            this.radioConexaoAtiva.TabStop = true;
            this.radioConexaoAtiva.Text = "Conexao Ativa";
            this.toolTip1.SetToolTip(this.radioConexaoAtiva, "Obriga informação de Banco Disponível");
            this.radioConexaoAtiva.UseVisualStyleBackColor = true;
            // 
            // radioCaminhoRel
            // 
            this.radioCaminhoRel.AutoSize = true;
            this.radioCaminhoRel.Depth = 0;
            this.radioCaminhoRel.Enabled = false;
            this.radioCaminhoRel.Location = new System.Drawing.Point(3, 53);
            this.radioCaminhoRel.Margin = new System.Windows.Forms.Padding(0);
            this.radioCaminhoRel.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioCaminhoRel.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioCaminhoRel.Name = "radioCaminhoRel";
            this.radioCaminhoRel.Ripple = true;
            this.radioCaminhoRel.Size = new System.Drawing.Size(61, 37);
            this.radioCaminhoRel.TabIndex = 14;
            this.radioCaminhoRel.TabStop = true;
            this.radioCaminhoRel.Text = "Rel:";
            this.radioCaminhoRel.UseVisualStyleBackColor = true;
            // 
            // radioProvider
            // 
            this.radioProvider.AutoSize = true;
            this.radioProvider.Depth = 0;
            this.radioProvider.Enabled = false;
            this.radioProvider.Location = new System.Drawing.Point(3, 20);
            this.radioProvider.Margin = new System.Windows.Forms.Padding(0);
            this.radioProvider.MouseLocation = new System.Drawing.Point(-1, -1);
            this.radioProvider.MouseState = MaterialSkin.MouseState.HOVER;
            this.radioProvider.Name = "radioProvider";
            this.radioProvider.Ripple = true;
            this.radioProvider.Size = new System.Drawing.Size(93, 37);
            this.radioProvider.TabIndex = 13;
            this.radioProvider.TabStop = true;
            this.radioProvider.Text = "Provider";
            this.radioProvider.UseVisualStyleBackColor = true;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(265, 7);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(36, 33);
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // pictureBoxAjuda
            // 
            this.pictureBoxAjuda.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAjuda.Image")));
            this.pictureBoxAjuda.Location = new System.Drawing.Point(693, 462);
            this.pictureBoxAjuda.Name = "pictureBoxAjuda";
            this.pictureBoxAjuda.Size = new System.Drawing.Size(27, 26);
            this.pictureBoxAjuda.TabIndex = 6;
            this.pictureBoxAjuda.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxAjuda, "Leia-me!");
            this.pictureBoxAjuda.Click += new System.EventHandler(this.pictureBoxAjuda_Click);
            // 
            // linklblGitHub
            // 
            this.linklblGitHub.AutoSize = true;
            this.linklblGitHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linklblGitHub.Location = new System.Drawing.Point(266, 466);
            this.linklblGitHub.Name = "linklblGitHub";
            this.linklblGitHub.Size = new System.Drawing.Size(101, 13);
            this.linklblGitHub.TabIndex = 2;
            this.linklblGitHub.TabStop = true;
            this.linklblGitHub.Text = "Acesse meu GitHub";
            this.toolTip1.SetToolTip(this.linklblGitHub, "Acesso o GitHub do Tiago Braga...");
            this.linklblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklblGitHub_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTipGeral_Popup);
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(5, 456);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(682, 32);
            this.progressBarLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarLoad.TabIndex = 7;
            this.progressBarLoad.Tag = "";
            this.toolTip1.SetToolTip(this.progressBarLoad, "Verde - Aplicação carregada completamente");
            this.progressBarLoad.Click += new System.EventHandler(this.progressBarLoad_Click);
            // 
            // pictureBoxLinear
            // 
            this.pictureBoxLinear.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLinear.Image")));
            this.pictureBoxLinear.Location = new System.Drawing.Point(288, 28);
            this.pictureBoxLinear.Name = "pictureBoxLinear";
            this.pictureBoxLinear.Size = new System.Drawing.Size(37, 33);
            this.pictureBoxLinear.TabIndex = 9;
            this.pictureBoxLinear.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBoxLinear, "Produto não oficial");
            // 
            // btnRecarregaMySQL
            // 
            this.btnRecarregaMySQL.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRecarregaMySQL.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRecarregaMySQL.Depth = 0;
            this.btnRecarregaMySQL.HighEmphasis = true;
            this.btnRecarregaMySQL.Icon = null;
            this.btnRecarregaMySQL.Location = new System.Drawing.Point(606, 330);
            this.btnRecarregaMySQL.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRecarregaMySQL.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecarregaMySQL.Name = "btnRecarregaMySQL";
            this.btnRecarregaMySQL.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRecarregaMySQL.Size = new System.Drawing.Size(114, 36);
            this.btnRecarregaMySQL.TabIndex = 7;
            this.btnRecarregaMySQL.Text = "Recarregar";
            this.toolTip1.SetToolTip(this.btnRecarregaMySQL, "Utilize quando incluir novos bancos");
            this.btnRecarregaMySQL.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRecarregaMySQL.UseAccentColor = false;
            this.btnRecarregaMySQL.UseVisualStyleBackColor = true;
            this.btnRecarregaMySQL.Click += new System.EventHandler(this.btnRecarregaMySQL_Click_1);
            // 
            // btnRecarregar
            // 
            this.btnRecarregar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRecarregar.Depth = 0;
            this.btnRecarregar.HighEmphasis = true;
            this.btnRecarregar.Icon = null;
            this.btnRecarregar.Location = new System.Drawing.Point(606, 374);
            this.btnRecarregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRecarregar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRecarregar.Name = "btnRecarregar";
            this.btnRecarregar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRecarregar.Size = new System.Drawing.Size(113, 36);
            this.btnRecarregar.TabIndex = 11;
            this.btnRecarregar.Text = "Cancelar";
            this.toolTip1.SetToolTip(this.btnRecarregar, "Restaura as configurações padrões");
            this.btnRecarregar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRecarregar.UseAccentColor = false;
            this.btnRecarregar.UseVisualStyleBackColor = true;
            this.btnRecarregar.Click += new System.EventHandler(this.btnRecarregar_Click_1);
            // 
            // btnSair
            // 
            this.btnSair.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSair.Depth = 0;
            this.btnSair.HighEmphasis = true;
            this.btnSair.Icon = null;
            this.btnSair.Location = new System.Drawing.Point(606, 411);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSair.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSair.Name = "btnSair";
            this.btnSair.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSair.Size = new System.Drawing.Size(113, 36);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "Sair";
            this.toolTip1.SetToolTip(this.btnSair, "Encerra o app com segurança");
            this.btnSair.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSair.UseAccentColor = false;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(726, 494);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnRecarregar);
            this.Controls.Add(this.btnRecarregaMySQL);
            this.Controls.Add(this.pictureBoxAjuda);
            this.Controls.Add(this.pictureBoxLinear);
            this.Controls.Add(this.linklblGitHub);
            this.Controls.Add(this.groupBoxParAtual);
            this.Controls.Add(this.groupBoxIni);
            this.Controls.Add(this.groupBoxMySQL);
            this.Controls.Add(this.progressBarLoad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Sizable = false;
            this.Text = "Central de Configurações .INI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxMySQL.ResumeLayout(false);
            this.groupBoxMySQL.PerformLayout();
            this.groupCreateMySQL.ResumeLayout(false);
            this.groupCreateMySQL.PerformLayout();
            this.groupBoxIni.ResumeLayout(false);
            this.groupBoxIni.PerformLayout();
            this.groupBoxParAtual.ResumeLayout(false);
            this.groupBoxParAtual.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLinear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // INICIO DA APLICAÇÃO ------------- <>
        public async void Form1_Load(object sender, EventArgs e)
        {
            //Configurações da Extensão MaterialSkin e MaterialSkin_Controls
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            materialSkinManager.ColorScheme = new ColorScheme
                (
                Primary.BlueGrey800,    // Cor principal do topo
                Primary.BlueGrey900,    // Cor da barra de ferramentas (darker)
                Primary.BlueGrey500,    // Cor de destaque (hover etc)
                Accent.LightBlue200,    // Cor de botões, switches etc
                TextShade.WHITE         // Cor do texto
                );

            progressBarLoad.Minimum = 0;
                    progressBarLoad.Maximum = 150;
                    progressBarLoad.Value = 0;

                    for (int i = 0; i <= 150; i += 10)
                    {
                        progressBarLoad.Value = i;
                        await Task.Delay(150); // Simula tempo de carregamento sem travar a UI
                    }
            //Inicio dos Métodos reais
            string iniPath = "C:\\projetos\\SGLinx\\sglinx.ini"; //<-- O caminho onde fica o arquivo na pasta
            ini = new IniFile((iniPath));

            provider = ini.Read("Provider");
            bancoAtual = ini.Read("nomebanco");
            bdesenv = ini.Read("bdesenv");
            caminhorel = ini.Read("Caminhorel");
            swtUtilizaMyIsam.Enabled = false; //--> Serão ao carregar os bancos no MySQL
            swtUtilizaInnodb.Enabled = false;
            swtEstReservadoItens.Enabled = false;
            swtEstReservado.Enabled = false;


            if (!string.IsNullOrEmpty(bancoAtual))
            {
                radioProvider.Text = $"Provider: {provider}";
                radioConexaoAtiva.Checked = true;
                radioConexaoAtiva.Text = $"Banco atual: {bancoAtual}";
                radioButtonBdesenv.Text = $"bdesenv: {bdesenv}";
                radioCaminhoRel.Text = $"{caminhorel}";
            }
            else if (string.IsNullOrEmpty(bancoAtual))
            {
                radioConexaoAtiva.Checked = false;
                radioButtonBdesenv.Checked = true;
                radioConexaoAtiva.Text = "Nenhum banco de dados encontrado";
                }
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

                // Ativando botões e posicionando labels após carregamento do MySQL
                CarregarBancosMySQL(ref bError);
                if (bError)
                {
                    txtUserSQL.Text = "";
                    txtSenhaSQL.Text = "";
                    lblBancoDados.Text = "Erro ao Carregar";
                    lblMySQLCarregado.ForeColor = Color.OrangeRed;
                    return;
                }
                lblBancoDados.Text = "Banco de Dados Disponíveis:";
                lblMySQLCarregado.ForeColor = Color.LightSeaGreen;
                lblMySQLCarregado.Text = "MySQL Carregado";
                swtUtilizaMyIsam.Enabled = true;
                swtUtilizaInnodb.Enabled = true;
                swtEstReservadoItens.Enabled = true;
                swtEstReservado.Enabled = true;
                btnExecutarViews.Enabled = true;
            }
            //Sub Método para Carregar os Bancos no MySQL
             void CarregarBancosMySQL(ref bool bError)
            {
                //Define a conexão com o servidor do MySQL 
                string connectionString = $"Server=localhost;User Id={txtUserSQL.Text};Password={txtSenhaSQL.Text};database={nomeBanco};"; //Usuario: Teste | Senha: 123
                try
                {
                    //Cria e abre a conexão no MySQL
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1º consulta - Cria e execuata comando SQL para listar todos os bancos de dados
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
                        reader.Close();
                    //Exibe uma mensagem que deu certo
                    MessageBox.Show("Aplicativo iniciado e pronto para uso!");
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
        }
        //Função para Recarregar os dados da tela
        private void btnRecarregar_Click(object sender, EventArgs e)
        {
            comboBoxBancos.Text = "";
            comboBoxBDesenv.Text = "";
            lblBancoDados.Text = "MySQL Carregado";
            lblMySQLCarregado.ForeColor = Color.LightGoldenrodYellow;

            swtEstReservado.Checked = false;
            swtEstReservadoItens.Checked = false;
            swtUtilizaInnodb.Checked = false;
            swtUtilizaMyIsam.Checked = false;

            provider = ini.Read("Provider");
            bancoAtual = ini.Read("nomebanco");
            bdesenv = ini.Read("bdesenv");
            caminhorel = ini.Read("Caminhorel");
        }

        //Função para Confirmar as alterações no arquivo .INI
        private void btnGravar_Click_1(object sender, EventArgs e)
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
        private void groupBox1_Enter(object sender, EventArgs e)
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
            MessageBox.Show("Selecione entre Conexão Ativa ou bdesenv. Conforme a seleção, torna-se obrigatório informar seu valor pra Gravar.&_" +
                "Informe um usuário e senha de um usuá´rio MySQL com permissões totais do tipo Root, para poder carrgar os bancos ativos &_" +
                "e realizar atualização do valor do parâmetro mysql_engine via aplicação.&_" +
                "Essa aplicação não é oficial, sendo que deve ser utilizado apenas internamente!");
        }
        //Evento do Botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(conn != null && conn.State == ConnectionState.Open)
                conn.Close();
                Application.Exit(); // Encerra toda a aplicação
            }
        }
        private void chkEstqReservados_CheckedChanged(object sender, EventArgs e)
        {

        }
        // Executa procedimentos no MySQL
        private void btnExecutarViews_Click_2(object sender, EventArgs e)
        {
            swtEstReservado.Text = "Estoques Reservados";
            swtEstReservadoItens.Text = "Estoques Reservados Itens";
            swtUtilizaMyIsam.Text = "engine MyIsam";
            swtUtilizaInnodb.Text = "engine InnoDB";

            if (!swtEstReservado.Checked && !swtEstReservadoItens.Checked && !swtUtilizaMyIsam.Checked && !swtUtilizaInnodb.Checked && !swtUserLinear.Checked)
                {
                MessageBox.Show("Nenhuma opção de chekbox selecionada!");
                return;
            }
            try
            {
                nomeBanco = radioConexaoAtiva.Text;

                //Formatar o nome do banco para ser compatível com utilizado no Heide
                nomeBanco = radioConexaoAtiva.Text.Replace("Banco atual: ", "").Split('(')[0].Trim();

                // Aqui você monta a connection string corretamente
                string connectionString = $"Server=localhost;User Id={txtUserSQL.Text};Password={txtSenhaSQL.Text};database={nomeBanco};";

                // Abrindo conexão com o MySQL
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Funções dos checkbox dentro do MySQL
                    if (swtEstReservado.Checked)
                    {
                        string sql = "CREATE VIEW vw_estoques_reservados AS SELECT a.es1_cod AS codigo_produto, a.es1_codbarra AS codigo_barras, a.es1_desc AS descricao_produto, b.es1_empresa AS empresa, b.quantidade_atual AS estoque_fiscal, SUM(c.quantidade) AS estoque_reservado, (b.quantidade_atual - SUM(c.quantidade)) AS estoque_disponivel, a.es1_familia AS codigo_familia, a.es1_departamento AS codigo_departamento, a.es1_secao AS codigo_secao, c.modulo_id, c.DATA, c.hora FROM es1p a INNER JOIN estoques b ON a.es1_cod = b.es1_cod INNER JOIN reserva_estoques c ON c.estoque_id = b.id LEFT JOIN st_familia d ON d.tab_cod = a.es1_familia LEFT JOIN st_departamento e ON e.tab_cod = a.es1_departamento LEFT JOIN st_secao f ON f.tab_cod = a.es1_secao GROUP BY c.id;";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            int linhasAfetadas = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{swtEstReservado.Text} crida com sucesso!");
                        }
                    }

                    if (swtEstReservadoItens.Checked)
                    {
                        string sql = "CREATE VIEW vw_estoques_reservados_itens AS SELECT a.es1_empresa,b.entidade_id cod_interno,a.es1_cod, c.descricao descricao_modulo, LPAD(b.entidade_sequencial_id,3,'0') cod_sequencial,b.quantidade, CONCAT(DATE_FORMAT(b.data,'%d/%m/%Y'),' ',b.hora) datahora_log FROM estoques a INNER JOIN reserva_estoques b ON a.id = b.estoque_id INNER JOIN modulos c ON b.modulo_id = c.id;";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            int linhasAfetadas = cmd.ExecuteNonQuery();
                            MessageBox.Show($"{swtEstReservadoItens.Text} crida com sucesso!");
                        }
                    }

                    if (swtUtilizaMyIsam.Checked)
                    {
                        string sql = "UPDATE parametro SET pr_valor = 'myisam' WHERE pr_chave = 'mysql_engine'";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            int linhasAfetadas = cmd.ExecuteNonQuery();
                            MessageBox.Show($"Parâmetro {swtUtilizaMyIsam.Text} atualizado com sucesso! Linhas afetadas: {linhasAfetadas}");
                        }
                    }

                    if (swtUtilizaInnodb.Checked)
                    {
                        string sql = "UPDATE parametro SET pr_valor = 'innodb' WHERE pr_chave = 'mysql_engine'";
                        using (var cmd = new MySqlCommand(sql, conn))
                        {
                            int linhasAfetadas = cmd.ExecuteNonQuery();
                            MessageBox.Show($"Parâmetro {swtUtilizaInnodb.Text} atualizado com sucesso! Linhas afetadas: {linhasAfetadas}");
                        }
                        }

                    if (swtUserLinear.Checked)
                    {
                        // Primeiro, busco os nomes que serão afetados
                        string selectSql = "SELECT us_nome FROM usuario WHERE us_nome LIKE '%Linear%'";
                        List<string> usuariosAfetados = new List<string>();

                        using (var selectCmd = new MySqlCommand(selectSql, conn))
                        using (var reader = selectCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuariosAfetados.Add(reader["us_nome"].ToString());
                            }
                        }

                        // Se não encontrou ninguém, exibe e sai
                        if (usuariosAfetados.Count == 0)
                        {
                            MessageBox.Show("Não foi encontrado nenhum usuário com nome semelhante a 'Linear'.");
                            return;
                        }

                        // Agora faço o UPDATE
                        string updateSql = "UPDATE usuario SET us_senha = 'xyz' WHERE us_nome LIKE '%Linear%'";
                        using (var updateCmd = new MySqlCommand(updateSql, conn))
                        {
                            int linhasAfetadas = updateCmd.ExecuteNonQuery();

                            string nomes = string.Join(", ", usuariosAfetados);
                            MessageBox.Show($"Senha 123 aplicada para os usuários: {nomes}. " +
                                                     $"Linhas afetadas: {linhasAfetadas}.");
                        }
                    }
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar Views:\n{ex.Message}");
            }
        }
        // Controlar o uso do check InnoDB e MyIsam para não serem executados juntos
        private void swtUtilizaInnodb_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (swtUtilizaInnodb.Checked)
                {
                    swtUtilizaMyIsam.Enabled = false;
                }
                if (!swtUtilizaInnodb.Checked)
                {
                    swtUtilizaMyIsam.Enabled = true;
                }
            }
        }
        private void progressBarLoad_Click(object sender, EventArgs e)
        {
        }
        private void btnRecarregaMySQL_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja recarregar os bancos do MySQL?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                Form1_Load(null, null);
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
                Application.Exit(); // Encerra toda a aplicação
            }
        }
        private void btnRecarregar_Click_1(object sender, EventArgs e)
        {
            comboBoxBancos.Text = "";
            comboBoxBDesenv.Text = "";
            lblBancoDados.Text = "MySQL Carregado";
            lblMySQLCarregado.ForeColor = Color.LightGoldenrodYellow;


            swtEstReservado.Checked = false;
            swtEstReservadoItens.Checked = false;
            swtUtilizaInnodb.Checked = false;
            swtUtilizaMyIsam.Checked = false;

            provider = ini.Read("Provider");
            bancoAtual = ini.Read("nomebanco");
            bdesenv = ini.Read("bdesenv");
            caminhorel = ini.Read("Caminhorel");
        }
        private void swtUtilizaMyIsam_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (swtUtilizaMyIsam.Checked)
                {
                    swtUtilizaInnodb.Enabled = false;
                }
                if (!swtUtilizaMyIsam.Checked)
                {
                    swtUtilizaInnodb.Enabled = true;
                }
            }
        }
        private void swtEstReservado_CheckedChanged(object sender, EventArgs e)
        {
        }

    }
} //-- Fim do Código </>