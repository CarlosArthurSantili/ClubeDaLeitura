using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    public class TelaBase
    {
        private readonly string tituloTela;

        public TelaBase(string tituloTela)
        {
            this.tituloTela = tituloTela;
        }

        public string Titulo { get { return tituloTela; } }

        public virtual string ObterOpcao()
        {
            return "";
        }

        

        protected void ConfigurarTela(string subtitulo) { }

        protected void ApresentarMensagem(string mensagem) { }
    }
}
