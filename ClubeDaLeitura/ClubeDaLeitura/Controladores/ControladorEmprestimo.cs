using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private ControladorAmiguinho controladorAmiguinho;
        private ControladorRevista controladorRevista;

        public ControladorEmprestimo(int capacidadeRegistros, ControladorAmiguinho controleAmiguinho, ControladorRevista controleRevista) : base(capacidadeRegistros)
        {
            this.controladorAmiguinho = controleAmiguinho;
            this.controladorRevista = controleRevista;
        }

        public string RegistrarEmprestimo(int idEmprestimo, int idAmiguinhoEmprestimo, int idRevistaEmprestimo)
        {
            Emprestimo novoEmprestimo;
            int posicao;
            string resultadoValidacao = "";

            novoEmprestimo = new Emprestimo();
            posicao = ObterPosicaoVazia();

            novoEmprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);
            novoEmprestimo.revista.disponibilidade = false;
            novoEmprestimo.amiguinho = controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinhoEmprestimo);
            novoEmprestimo.dataEmprestimo = DateTime.Now;
            novoEmprestimo.dataDevolucao = DateTime.MinValue;
            

            resultadoValidacao = novoEmprestimo.Validar();
            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
                registros[posicao] = novoEmprestimo;

            return resultadoValidacao;
        }

        public bool DevolverEmprestimo(int idRevista)
        {
            if (VerificaIdExistente(idRevista))
            {
                Emprestimo emprestimoAlterado = SelecionarEmprestimoPorId(idRevista);
                if (emprestimoAlterado.dataDevolucao == DateTime.MinValue)
                {
                    emprestimoAlterado.dataDevolucao = DateTime.Now;
                    emprestimoAlterado.revista.disponibilidade = true;
                    return true;
                }
                else 
                {
                    return false;
                }
                    
            }
            else
            {
                return false;
            }
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistro(new Emprestimo(id));
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            Emprestimo[] emprestimosAux = new Emprestimo[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), emprestimosAux, emprestimosAux.Length);

            return emprestimosAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Emprestimo e in SelecionarTodosEmprestimos())
            {
                if (e.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public bool VerificaAmiguinhoValidoParaEmprestar(int idCheck)
        {
            foreach (Emprestimo e in SelecionarTodosEmprestimos())
            {
                if ((e.amiguinho.id == idCheck)&&(e.dataDevolucao==DateTime.MinValue))
                {
                    return false;
                }
            }
            return true;
        }

        public int QtdAmiguinhosValidosParaEmprestar()
        {
            int qtdAmiguinhos = controladorAmiguinho.SelecionarTodosAmiguinhos().Length;
            foreach (Emprestimo e in SelecionarTodosEmprestimos())
            {
                if(e.dataDevolucao == DateTime.MinValue)
                    qtdAmiguinhos--;
            }

            return qtdAmiguinhos;
        }
    }
}
