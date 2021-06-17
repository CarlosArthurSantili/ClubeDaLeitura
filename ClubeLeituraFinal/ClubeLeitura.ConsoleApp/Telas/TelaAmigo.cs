using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaAmigo : TelaCadastroBasico<Amigo>, ICadastravel
    {
        public TelaAmigo(Controlador<Amigo> controlador)
            : base("Cadastro de Amigos", controlador)
        {
        }

        public override Amigo ObterRegistro(TipoAcao acao)
        {
            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amiguinho: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite da onde é o amiguinho: ");
            string deOndeEh = Console.ReadLine();

            return new Amigo(nome, nomeResponsavel, telefone, deOndeEh);
        }

        public override string SubtituloDeInsercao()
        {
            return "Inserindo um novo amiguinho";
        }

        /*public bool VisualizarAmigos()
        {
            ConfigurarTela("Visualizando amigos...");

            List<Amigo> amigos = controlador.SelecionarTodosRegistros();

            if (amigos.Count == 0)
            {
                ApresentarMensagem("Nenhum amigo cadastrado", TipoMensagem.Atencao);
                return false;
            }

            string configuracaColunasTabela = "{0,-10} | {1,-25} | {2,-25} | {3,-25}";

            Console.WriteLine();

            MontarCabecalhoTabela(configuracaColunasTabela, "Id", "Nome", "Responsável", "Telefone");

            foreach (Amigo amigo in amigos)
            {
                Console.WriteLine(configuracaColunasTabela, amigo.id, amigo.nome, amigo.nomeResponsavel, amigo.telefone);
            }

            return true;
        }*/
    }
}