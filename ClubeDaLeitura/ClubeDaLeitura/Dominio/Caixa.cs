using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Dominio
{
    public class Caixa : EntidadeBase
    {
        //atributos
        
        public string cor;
        public string etiqueta;
        public double numero;
        public Revista[] revistas;
        

        public Caixa(int id)
        {
            this.id = id;
        }
        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public string Validar()
        {
            string validar = "CAIXA_VALIDO";
            return validar;
        }

        public override bool Equals(object obj)
        {
            Caixa c = (Caixa)obj;

            if (c != null && c.id == this.id)
                return true;

            return false;
        }

    }
}
