using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorBase
    {
        protected readonly Object[] registros = null;

        public ControladorBase(int capacidadeRegistros)
        {
            registros = new object[capacidadeRegistros];
        }

        protected virtual bool ExcluirRegistro(object obj)
        {
            bool conseguiuExcluir = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    registros[i] = null;
                    conseguiuExcluir = true;
                    break;
                }
            }

            return conseguiuExcluir;
        }

        protected virtual object SelecionarRegistro(object obj)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(obj))
                {
                    return registros[i];
                }
            }

            return null;
        }

        protected virtual Object[] SelecionarTodosRegistros()
        {
            Object[] objectAux = new Object[registros.Length];

            int i = 0;

            foreach (Object obj in registros)
            {
                if (obj != null)
                    objectAux[i++] = obj;
            }

            return objectAux;
        }

        protected int QtdRegistrosCadastrados()
        {
            int quantidadeRegistros = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null)
                {
                    quantidadeRegistros++;
                }
            }

            return quantidadeRegistros;
        }

        protected int ObterPosicaoVazia()
        {
            int posicao = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }

        protected int ObterPosicaoOcupada(object objSelecionado)
        {
            int posicao = -1;

            for (int i = 0; i < registros.Length; i++)
            {
                if (objSelecionado.Equals(registros[i]))
                {
                    posicao = i;
                    break;
                }
            }

            return posicao;
        }
    }
}
