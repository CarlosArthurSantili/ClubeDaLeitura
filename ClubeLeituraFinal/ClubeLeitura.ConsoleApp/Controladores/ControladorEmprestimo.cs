using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : Controlador<Emprestimo>
    {
        public string RegistrarEmprestimo(Amigo amigo, Revista revista, DateTime data)
        {
            Emprestimo emprestimo = new Emprestimo(amigo, revista, data);

            string resultadoValidacao = emprestimo.Validar();

            if (resultadoValidacao == "VALIDO")
            {
                string dasdsadsaa = Adicionar(emprestimo);
                amigo.RegistrarEmprestimo(emprestimo);
                revista.RegistrarEmprestimo(emprestimo);
            }

            return resultadoValidacao;
        }

        public bool RegistrarDevolucao(int idEmprestimo, DateTime data)
        {
            Emprestimo emprestimo = SelecionarRegistroPorId(idEmprestimo);
            emprestimo.Fechar(data);
            return true;
        }

        internal List<Emprestimo> SelecionarEmprestimosEmAberto()
        {
            return itens.FindAll(emprestimo => emprestimo.estaAberto);
        }

        internal List<Emprestimo> SelecionarEmprestimosFechados(int mes)
        {
            return itens.FindAll(emprestimo => emprestimo.EstaFechado() && emprestimo.Mes == mes);
        }
    }
}