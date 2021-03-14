
namespace testeMeta
{
    partial class main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadClientes = new System.Windows.Forms.Button();
            this.btnOrcamentos = new System.Windows.Forms.Button();
            this.btnCadProdutos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCadClientes
            // 
            this.btnCadClientes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadClientes.Location = new System.Drawing.Point(109, 43);
            this.btnCadClientes.Name = "btnCadClientes";
            this.btnCadClientes.Size = new System.Drawing.Size(195, 23);
            this.btnCadClientes.TabIndex = 0;
            this.btnCadClientes.Text = "Cadastro de clientes";
            this.btnCadClientes.UseVisualStyleBackColor = true;
            this.btnCadClientes.Click += new System.EventHandler(this.btnCadClientes_Click);
            // 
            // btnOrcamentos
            // 
            this.btnOrcamentos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOrcamentos.Location = new System.Drawing.Point(109, 120);
            this.btnOrcamentos.Name = "btnOrcamentos";
            this.btnOrcamentos.Size = new System.Drawing.Size(195, 23);
            this.btnOrcamentos.TabIndex = 1;
            this.btnOrcamentos.Text = "Orçamentos";
            this.btnOrcamentos.UseVisualStyleBackColor = true;
            this.btnOrcamentos.Click += new System.EventHandler(this.btnOrcamentos_Click);
            // 
            // btnCadProdutos
            // 
            this.btnCadProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCadProdutos.Location = new System.Drawing.Point(109, 81);
            this.btnCadProdutos.Name = "btnCadProdutos";
            this.btnCadProdutos.Size = new System.Drawing.Size(195, 23);
            this.btnCadProdutos.TabIndex = 2;
            this.btnCadProdutos.Text = "Cadastro de produtos";
            this.btnCadProdutos.UseVisualStyleBackColor = true;
            this.btnCadProdutos.Click += new System.EventHandler(this.btnCadProdutos_Click);
            // 
            // main
            // 
            this.ClientSize = new System.Drawing.Size(408, 206);
            this.Controls.Add(this.btnCadProdutos);
            this.Controls.Add(this.btnOrcamentos);
            this.Controls.Add(this.btnCadClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste - Meta Posto - Tela Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCadClientes;
        private System.Windows.Forms.Button btnOrcamentos;
        private System.Windows.Forms.Button btnCadProdutos;
    }
}

