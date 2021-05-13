using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Dominio
{
    public class Revista : EntidadeBase
    {
        //caixa, tipo de coleção, número da edição e ano da revista
        //atributos
        public Caixa caixa;
        public string tipoColecao;
        public string numeroEdicao;
        public int anoPublicacao;
        public bool disponibilidade;

        public Revista(int id)
        {
            this.id = id;
        }
        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public string Validar()
        {
            string validar = "";
            if (anoPublicacao > DateTime.Now.Year)
            {
                validar = "Erro: Ano de Publicação Inválida";
            }
            else
            {
                validar = "REVISTA_VALIDO";
            }
            return validar;
        }

        public override bool Equals(object obj)
        {
            Revista r = (Revista)obj;

            if (r != null && r.id == this.id)
                return true;

            return false;
        }
    }
}
