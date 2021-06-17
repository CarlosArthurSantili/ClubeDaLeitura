namespace ClubeLeitura.ConsoleApp.Dominio
{
    public class Caixa : EntidadeBase
    {
        public string cor;

        public string etiqueta;

        public Caixa()
        {
        }

        public Caixa(string cor, string etiqueta)
        {
            this.cor = cor;
            this.etiqueta = etiqueta;
        }

        override
        public string Validar()
        {
            return "VALIDO";
        }
        public override string ToString()
        {
            return $"id caixa: {id} etiqueta caixa: {etiqueta}";
        }
    }
}
