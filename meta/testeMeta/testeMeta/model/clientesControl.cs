using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMeta.dal;
using System.Data;

namespace testeMeta.model
{
    public class clientesControl
    {

        clienteDao cliDao = new clienteDao();

        public DataTable Listar(int pId)
        {
            cliDao.Listar(pId);
            return cliDao.vLista;
        }

        public bool Existe(int pId)
        {
            cliDao.Existe(pId);
            return cliDao.vExiste;
        }

        public bool inserir(string pNome, string pTelefone)
        {
            cliDao.inserir(pNome, pTelefone);
            return cliDao.vInserido;
        }

        public bool alterar(int pId, string pNome, string pTelefone)
        {
            cliDao.alterar(pId, pNome, pTelefone);
            return cliDao.vAlterado;
        }

        public bool excluir(int pid)
        {
            cliDao.excluir(pid);
            return cliDao.vExcluido;
        }

    }

}
