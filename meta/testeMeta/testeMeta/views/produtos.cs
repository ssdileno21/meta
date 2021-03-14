using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testeMeta.model;
using testeMeta.Enum;
using testeMeta.lib;

namespace testeMeta.views
{
    public partial class produtos : Form
    {
        #region Classes
            produtosControl cProdutos = new produtosControl();
            eUtilEnums.estadoForm cModo = new eUtilEnums.estadoForm();
            MensagensLista cMens = new MensagensLista();
        #endregion

        #region Variáveis
            string vNomeOld;
            string vPrecoOld;
            bool vUltimaVer;
        #endregion

        public produtos()
        {
            InitializeComponent();
        }

        #region Métodos
            private void AtualizaB()
            {
                //dgProdutos.DataSource = cProdutos.Listar(0);
                this.tBPRODUTOSTableAdapter.Fill(this.bd_metaDataSet.TBPRODUTOS);
            }

            private void ControleFrm()
            {
                bool vReg = Existe();
                string vVal = "";

                if (cModo == eUtilEnums.estadoForm.Inicial)
                    vVal = "0";
                if ((cModo == eUtilEnums.estadoForm.Inicial) & (vReg))
                    vVal = "01";
                if ((cModo == eUtilEnums.estadoForm.Insercao))
                    vVal = "1";
                if ((cModo == eUtilEnums.estadoForm.Insercao))
                    vVal = "2";

                remover o trecho abaixo, deletar o datagridview e inserir um novo,
                descomentar as acoes com o datagridview antigo
                if ((vVal == "0") || (vVal == "01"))
                {
                    bindingNavigator1.BindingSource = tBPRODUTOSBindingSource;
                    tBPRODUTOSDataGridView.DataSource = tBPRODUTOSBindingSource;
                } 
                    else
                {
                    bindingNavigator1.BindingSource = null;
                    tBPRODUTOSDataGridView.DataSource = null;
                }                   

                btnInserir.Enabled = ((vVal == "0") || (vVal == "01"));
                btnAlterar.Enabled = (vVal == "01");
                btnExcluir.Enabled = (vVal == "01");
                btnGravar.Enabled = ((vVal == "1") || (vVal == "2"));
                btnCancelar.Enabled = ((vVal == "1") || (vVal == "2"));

                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        if (vVal == "1")
                            ((TextBox)(ctrl)).Text = String.Empty;

                        ((TextBox)(ctrl)).Enabled = ((vVal == "1") || (vVal == "2"));
                    }
                }

                if (vVal == "1")
                {
                    tbNome.Focus();
                   // dgProdutos.DataSource = null;
                }

                vUltimaVer = vReg;
            }

            private bool CamposValidados()
            {
                bool vVal = true;
                if (tbNome.Text == "")
                {
                    MessageBox.Show(cMens.getMensagemValCampo(1, "nome"));
                    vVal = false;
                }
                if (tbPreco.Text == "")
                {
                    MessageBox.Show(cMens.getMensagemValCampo(1, "preço"));
                    vVal = false;
                }
                return vVal;
            }

            private bool Existe()
            {
                int vId;

                if (tbId.Text == "")
                {
                    vId = 0;
                }
                else
                    vId = Int32.Parse(tbId.Text);

            return (vId > 0);
            }


        #endregion

        #region Eventos
            private void produtos_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'bd_metaDataSet.TBPRODUTOS' table. You can move, or remove it, as needed.
                this.tBPRODUTOSTableAdapter.Fill(this.bd_metaDataSet.TBPRODUTOS);
                AtualizaB();
                cModo = eUtilEnums.estadoForm.Inicial;
                ControleFrm();
            }

            private void btnInserir_Click(object sender, EventArgs e)
            {
                cModo = eUtilEnums.estadoForm.Insercao;
                ControleFrm();
                //dgProdutos.DataSource = null;
            }

            private void btnAlterar_Click(object sender, EventArgs e)
            {
                cModo = eUtilEnums.estadoForm.Alteracao;
                ControleFrm();
                vNomeOld = tbNome.Text;
                vPrecoOld = tbPreco.Text;
            }

            private void btnExcluir_Click(object sender, EventArgs e)
            {
                if (vUltimaVer == true)
                {
                    if (util.MetaMessageBtn(cMens.getMensagem(6), "Excluir registro"))
                    {
                        cProdutos.excluir(Int32.Parse(tbId.Text));
                        MessageBox.Show(cMens.getMensagem(3));
                        cModo = eUtilEnums.estadoForm.Inicial;
                        ControleFrm();
                        AtualizaB();
                    }
                }
            }

            private void tbPreco_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
                if (e.KeyChar == (char)13)
                {
                    tbPreco.Text = string.Format("{0:n0}", double.Parse(tbPreco.Text));
                }
            }

            private void tbPreco_TextChanged(object sender, EventArgs e)
            {
                util.CurrencyFormat(ref tbPreco);
            }

            private void btnGravar_Click(object sender, EventArgs e)
            {
                if (cModo == eUtilEnums.estadoForm.Insercao)
                {
                    if (CamposValidados())
                    {
                        if (cProdutos.inserir(tbNome.Text,float.Parse(tbPreco.Text)))
                        {
                            MessageBox.Show(cMens.getMensagem(1));
                            cModo = eUtilEnums.estadoForm.Inicial;
                            ControleFrm();
                            AtualizaB();
                        }
                    }
                }
                else
                if (cModo == eUtilEnums.estadoForm.Alteracao)
                {
                    if (CamposValidados())
                    {
                        if (cProdutos.alterar(Int32.Parse(tbId.Text), 
                                tbNome.Text, float.Parse(tbPreco.Text)))
                        {
                            MessageBox.Show(cMens.getMensagem(2));
                            cModo = eUtilEnums.estadoForm.Inicial;
                            ControleFrm();
                            AtualizaB();
                        }
                    }
                }
            }

            private void btnCancelar_Click(object sender, EventArgs e)
            {
                util.ClearAll(this.Controls);
                this.tBPRODUTOSTableAdapter.Fill(this.bd_metaDataSet.TBPRODUTOS);
                cModo = eUtilEnums.estadoForm.Inicial;
                ControleFrm();
                AtualizaB();
            }
        #endregion

    }
}
