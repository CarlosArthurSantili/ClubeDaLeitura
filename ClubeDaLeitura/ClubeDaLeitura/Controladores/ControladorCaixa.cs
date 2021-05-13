using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorCaixa : ControladorBase
    {
        public ControladorCaixa(int capacidadeRegistros) : base(capacidadeRegistros)
        {
        }

        public string RegistrarCaixa(int id, string cor, string etiqueta, double numero)
        {
            Caixa caixa;
            int posicao = 0;

            if (id == 0)
            {
                caixa = new Caixa();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                Caixa caixaSubstituido = SelecionarCaixaPorId(id);
                posicao = ObterPosicaoOcupada(caixaSubstituido);
                caixa = (Caixa)registros[posicao];
            }

            caixa.cor = cor;
            caixa.etiqueta = etiqueta;
            caixa.revistas = null;
            caixa.numero = numero;

            string resultadoValidacao = caixa.Validar();

            if (resultadoValidacao == "CAIXA_VALIDO")
                registros[posicao] = caixa;

            return resultadoValidacao;
        }

        public bool ExcluirCaixa(int idSelecionado)
        {
            return ExcluirRegistro(new Caixa(idSelecionado));
        }

        public Caixa SelecionarCaixaPorId(int id)
        {
            return (Caixa)SelecionarRegistro(new Caixa(id));
        }

        public Caixa[] SelecionarTodosCaixas()
        {
            Caixa[] caixasAux = new Caixa[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), caixasAux, caixasAux.Length);

            return caixasAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Caixa c in SelecionarTodosCaixas())
            {
                if (c.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
