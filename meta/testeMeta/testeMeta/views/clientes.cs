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
    public partial class clientes : Form
    {
        #region Classes
            clientesControl cCliControl = new clientesControl();
            eUtilEnums.estadoForm cModo = new eUtilEnums.estadoForm();
            MensagensLista cMens = new MensagensLista();
            //util _util = new util();
        #endregion

        #region Variáveis
            string vNomeOld;
            string vTelefoneOld;
            bool vUltimaVer;
        #endregion

        #region Métodos
            public clientes()
            {
                InitializeComponent();
            }

            private void AtualizaB()
            {
                dgClientes.DataSource = cCliControl.Listar(0);
                this.tBCLIENTESTableAdapter.Fill(this.bd_metaDataSet.TBCLIENTES);
            }

            private void ControleFrm()
            {
                bool vReg = Existe();
    
                btnInserir.Enabled = (cModo == eUtilEnums.estadoForm.Inicial);
                btnAlterar.Enabled = ((cModo == eUtilEnums.estadoForm.Inicial) & (vReg));
                btnExcluir.Enabled = (cModo == eUtilEnums.estadoForm.Inicial) & (vReg);
                btnGravar.Enabled = (
                                    (cModo == eUtilEnums.estadoForm.Insercao) ||
                                    (cModo == eUtilEnums.estadoForm.Alteracao)
                                );

                btnCancelar.Enabled = (
                                    (cModo == eUtilEnums.estadoForm.Insercao) ||
                                    (cModo == eUtilEnums.estadoForm.Alteracao)
                                  );
                if (cModo == eUtilEnums.estadoForm.Inicial)
                {
                    //dgClientes.DataSource = cCliControl.Listar(0);
                }
                if (cModo == eUtilEnums.estadoForm.Insercao)
                {
                    tbNome.Focus();
                    tbId.Text = "";
                    tbNome.Text = "";
                    tbTelefone.Text = "";
                    dgClientes.DataSource = null;
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
                if (tbTelefone.Text == "")
                {
                    MessageBox.Show(cMens.getMensagemValCampo(1, "telefone"));
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

                return cCliControl.Existe(vId);
            }

            private void clientes_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'bd_metaDataSet.TBCLIENTES' table. You can move, or remove it, as needed.
                AtualizaB();
                cModo = eUtilEnums.estadoForm.Inicial;
                ControleFrm();
            }

            private void btnInserir_Click(object sender, EventArgs e)
            {
                cModo = eUtilEnums.estadoForm.Insercao;
                ControleFrm();
                dgClientes.DataSource = null;
            }

            private void btnAlterar_Click(object sender, EventArgs e)
            {
                cModo = eUtilEnums.estadoForm.Alteracao;
                ControleFrm();
                vNomeOld = tbNome.Text;
                vTelefoneOld = tbTelefone.Text;
            }

            private void btnGravar_Click(object sender, EventArgs e)
            {
                if (cModo == eUtilEnums.estadoForm.Insercao)
                {
                    if (CamposValidados())
                    {
                        if (cCliControl.inserir(tbNome.Text, tbTelefone.Text))
                        {
                            MessageBox.Show(cMens.getMensagem(1));
                            cModo = eUtilEnums.estadoForm.Inicial;
                            ControleFrm();
                            AtualizaB();
                        }
                    }
                } else
                if (cModo == eUtilEnums.estadoForm.Alteracao)
                {
                    if (CamposValidados())
                    {
                        if (cCliControl.alterar(Int32.Parse(tbId.Text), tbNome.Text, tbTelefone.Text))
                        {
                            MessageBox.Show(cMens.getMensagem(2));
                            cModo = eUtilEnums.estadoForm.Inicial;
                            ControleFrm();
                            AtualizaB();
                        }
                    }
                }
            }

            private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
                //
            }

            private void btnExcluir_Click_1(object sender, EventArgs e)
            {
                if (vUltimaVer == true)
                {
                    if (util.MetaMessageBtn(cMens.getMensagem(6), "Excluir registro"))
                    {
                        cCliControl.excluir(Int32.Parse(tbId.Text));
                        MessageBox.Show(cMens.getMensagem(3));
                        cModo = eUtilEnums.estadoForm.Inicial;
                        ControleFrm();
                        AtualizaB();                    
                    }
                }
            }
        #endregion
    }
}
