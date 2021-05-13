using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorRevista : ControladorBase
    {
        private ControladorCaixa controladorCaixa;

        public ControladorRevista(int capacidadeRegistros, ControladorCaixa controladorCaixa) : base(capacidadeRegistros)
        {
            this.controladorCaixa = controladorCaixa;
        }

        public string RegistrarRevista(int idRevista, int idCaixaRevista,
            string tipoColecao, string numeroEdicao, int anoPublicacao)
        {
            Revista novoRevista;
            int posicao;
            string resultadoValidacao = "";

            if (idRevista == 0)
            {
                novoRevista = new Revista();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                Revista revistaSubstituido = SelecionarRevistaPorId(idRevista);
                posicao = ObterPosicaoOcupada(revistaSubstituido);
                novoRevista = (Revista)registros[posicao];
            }

            //controladorCaixa.SelecionarCaixaPorId(idCaixaRevista).
            novoRevista.caixa = controladorCaixa.SelecionarCaixaPorId(idCaixaRevista);
            novoRevista.tipoColecao = tipoColecao;
            novoRevista.numeroEdicao = numeroEdicao;
            novoRevista.anoPublicacao = anoPublicacao;
            novoRevista.disponibilidade = true;

            resultadoValidacao = novoRevista.Validar();
            if (resultadoValidacao == "REVISTA_VALIDO")
                registros[posicao] = novoRevista;

            return resultadoValidacao;
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistro(new Revista(id));
        }

        public Revista[] SelecionarTodosRevistas()
        {
            Revista[] revistasAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistasAux, revistasAux.Length);

            return revistasAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Revista r in SelecionarTodosRevistas())
            {
                if (r.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificaRevistaDisponivel(int idCheck)
        {
            if (VerificaIdExistente(idCheck))
            {
                foreach (Revista r in SelecionarTodosRevistas())
                {
                    if (r.id == idCheck)
                    {
                        if (r.disponibilidade == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public int QtdRevistasEmprestadas()
        {
            int qtdRevistas = 0;
            foreach (Revista r in SelecionarTodosRevistas())
            {
                if (r.disponibilidade == false)
                {
                    qtdRevistas++;
                }
            }
            return qtdRevistas;
            
        }

        public int QtdRevistasDisponiveis()
        {
            int qtdRevistas = 0;
            foreach (Revista r in SelecionarTodosRevistas())
            {
                if (r.disponibilidade == true)
                {
                    qtdRevistas++;
                }
            }
            return qtdRevistas;

        }
    }
}
