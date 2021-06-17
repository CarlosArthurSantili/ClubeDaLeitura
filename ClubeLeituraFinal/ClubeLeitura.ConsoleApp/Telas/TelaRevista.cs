using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaCadastroBasico<Revista>, ICadastravel
    {
        private readonly TelaCaixa telaCaixa;
        private readonly Controlador<Caixa> controladorCaixa;        

        public TelaRevista(Controlador<Revista> controlador, Controlador<Caixa> ctrlCaixa, TelaCaixa tlCaixa)
            : base("Cadastro de Revistas", controlador)
        {
            telaCaixa = tlCaixa;
            controladorCaixa = ctrlCaixa;
        }

        public override Revista ObterRegistro(TipoAcao acao)
        {
            telaCaixa.VisualizarRegistros(TipoVisualizacao.Pesquisando);

            Console.Write("\nDigite o número da caixa: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            bool numeroEncontrado = controladorCaixa.ExisteRegistro(idCaixa);
            if (numeroEncontrado == false)
            {
                ApresentarMensagem("Nenhuma caixa foi encontrada com este número: "
                    + idCaixa, TipoMensagem.Erro);

                ConfigurarTela($"{acao} uma revista ");

                return ObterRegistro(acao);
            }

            Caixa caixa = controladorCaixa.SelecionarRegistroPorId(idCaixa);

            Console.Write("Digite a nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a coleção da revista: ");
            string colecao = Console.ReadLine();

            Console.Write("Digite o número de edição da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            return new Revista(nome, colecao, numeroEdicao, caixa);
        }
    }
}
