using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Dominio
{
    public class Emprestimo: EntidadeBase
    {
        //amiguinho que pegou a revista, qual foi a revista, a data doempréstimo e a data de devolução.
        //atributos
        public Amiguinho amiguinho;
        public Revista revista;
        public DateTime dataEmprestimo;
        public DateTime dataDevolucao;

        public Emprestimo(int id)
        {
            this.id = id;
        }
        public Emprestimo()
        {
            id = GeradorId.GerarIdEmprestimo();
        }

        public string Validar()
        {
            string validar = "EMPRESTIMO_VALIDO";
            return validar;
        }

        public override bool Equals(object obj)
        {
            Emprestimo e = (Emprestimo)obj;

            if (e != null && e.id == this.id)
                return true;

            return false;
        }
    }
}
