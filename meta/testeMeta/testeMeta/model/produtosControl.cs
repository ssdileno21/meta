using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testeMeta.dal;

namespace testeMeta.model
{
    public class produtosControl
    {
        produtoDao PrdDao = new produtoDao();

        string vLiista;

        public DataTable Listar(int pId)
        {
            PrdDao.Listar(pId);
            return PrdDao.vLista;
        }

        public bool Existe(int pId)
        {
            PrdDao.Existe(pId);
            return PrdDao.vExiste;
        }

        public bool inserir(string pNome, float pValor)
        {
            PrdDao.inserir(pNome, pValor);
            return PrdDao.vInserido;
        }

        public bool alterar(int pId, string pNome, float pValor)
        {
            PrdDao.alterar(pId, pNome, pValor);
            return PrdDao.vAlterado;
        }

        public bool excluir(int pid)
        {
            PrdDao.excluir(pid);
            return PrdDao.vExcluido;
        }
    }
}
