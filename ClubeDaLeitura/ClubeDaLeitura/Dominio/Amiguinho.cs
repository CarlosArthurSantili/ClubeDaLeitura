using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Dominio
{
    public class Amiguinho : EntidadeBase
    {
        //nome, nome do responsável, telefone e de onde é o amigo.
        //atributos
        public string nome;
        public string nomeResponsavel;
        public string telefone;
        public string endereco;

        public Amiguinho(int id) 
        {
            this.id = id;
        }
        public Amiguinho()
        {
            id = GeradorId.GerarIdAmiguinho();
        }

        public string Validar()
        {
            string validar = "AMIGUINHO_VALIDO";
            return validar;
        }

        public override bool Equals(object obj)
        {
            Amiguinho a = (Amiguinho)obj;

            if (a != null && a.id == this.id)
                return true;

            return false;
        }
    }
}
