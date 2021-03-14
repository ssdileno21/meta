using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMeta.lib;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace testeMeta.dal
{
    public class produtoDao
    {
    
        #region Classes
            MensagensLista cMens = new MensagensLista();
        #endregion

        #region Variáveis
        private string mensagem = "";
            private bool vEx = false;
            public bool vExiste;
            public bool vInserido;
            public bool vAlterado;
            public bool vExcluido;
            public DataTable vLista;
        #endregion

        #region Métodos
            public void Listar(int pId)
            {
                try
                {
                    string vSql = "SELECT ID, NOME, PRECO FROM [dbo].[FN_RETORNA_PRODUTOS] (" + pId.ToString() + ")";
                    conection cConn = new conection();
                    SqlDataAdapter sda = new SqlDataAdapter(vSql, cConn.ToConnect());
                    vLista = new DataTable();
                    sda.Fill(vLista);
                }
                catch
                {
                    MessageBox.Show(cMens.getMensagem(1));
                }
            }

            public void Existe(int pId)
            {
                try
                {
                    conection cConn = new conection();
                    vEx = false;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cConn.ToConnect();
                    cmd.CommandText = "SELECT [dbo].[FN_EXISTEPRODUTO](@ID)";
                    cmd.Parameters.AddWithValue("@ID", pId);

                    SqlDataReader adapter = cmd.ExecuteReader();

                    vEx = (adapter.HasRows);
                    vExiste = vEx;
                    cConn.Disconnect();
                    cConn = null;
                    cmd = null;
                }
                catch (Exception ex)
                {
                    this.mensagem = ex.Message;
                }

            }

            public void inserir(string pNome, float pPreco)
            {
                try
                {
                    conection cConn = new conection();
                    vEx = false;
                    SqlCommand cmd = new SqlCommand("dbo.USP_INSEREPRODUTOS", cConn.ToConnect());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PNOMEPRODUTO", SqlDbType.VarChar).Value = pNome;
                    cmd.Parameters.AddWithValue("@PPRECO", SqlDbType.Float).Value = pPreco;
                    cmd.ExecuteNonQuery();

                    vEx = true;
                    vInserido = vEx;
                    cConn.Disconnect();
                    cConn = null;
                    cmd = null;
                }
                catch (Exception ex)
                {
                    this.mensagem = ex.Message;
                }
            }

            public void alterar(int Pid, string pNome, float pPreco)
            {
                try
                {
                    conection cConn = new conection();
                    vEx = false;
                    SqlCommand cmd = new SqlCommand("dbo.USP_ALTERAPRODUTOS", cConn.ToConnect());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = Pid;
                    cmd.Parameters.AddWithValue("@PNOMEPRODUTO", SqlDbType.VarChar).Value = pNome;
                    cmd.Parameters.AddWithValue("@PPRECO", SqlDbType.Float).Value = pPreco;
                    cmd.ExecuteNonQuery();

                    vEx = true;
                    vAlterado = vEx;
                    cConn.Disconnect();
                    cConn = null;
                    cmd = null;
                }
                catch (Exception ex)
                {
                    this.mensagem = ex.Message;
                }
            }

            public void excluir(int pId)
            {
                try
                {
                    conection cConn = new conection();
                    vEx = false;
                    SqlCommand cmd = new SqlCommand("dbo.USP_EXCLUIRPRODUTOS", cConn.ToConnect());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PID", SqlDbType.Int).Value = pId;
                    cmd.ExecuteNonQuery();

                    vEx = true;
                    vExcluido = vEx;
                    cConn.Disconnect();
                    cConn = null;
                    cmd = null;
                }
                catch (Exception ex)
                {
                    this.mensagem = ex.Message;
                }
            }
        #endregion  
    }
}
