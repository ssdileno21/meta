using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testeMeta.lib
{
    public class MensagensLista
    {
        public string getMensagem(int pIdMens)
        {
            string vMens = "";

            switch (pIdMens)
            {
                case 1:
                    vMens = "Registro inserido com sucesso.";
                    break;
                case 2:
                    vMens = "Registro alterado com sucesso.";
                    break;
                case 3:
                    vMens = "Registro ecluído com sucesso.";
                    break;
                case 4:
                    vMens = "Confirma cadastro?";
                    break;
                case 5:
                    vMens = "Confirma alteração?";
                    break;
                case 6:
                    vMens = "Confirma exclusão?";
                    break;
                case 7:
                    vMens = "Erro ao listar clientes";
                    break;
                case 8:
                    vMens = "Erro ao listar produtos";
                    break;
            }

            return vMens;
        }

        public string getMensagemValCampo(int pIdMens, string pCampo)
        {
            string vMens = "";
            if (pCampo == "")
            {
                return "";
            }


            switch (pIdMens)
            {
                case 1:
                    vMens = "O preenchimento do campo " + pCampo + " é obrigatório.";
                    break;
                case 2:
                    vMens = "Valor do campo " + pCampo + " não informado.";
                    break;
            }
            return vMens;

        }
    }
}
