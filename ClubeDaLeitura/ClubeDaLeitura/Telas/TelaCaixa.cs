using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    public class TelaCaixa : TelaBase, IRegistravel, IVisualizavel, IEditavel, IExcluivel
    {
        private readonly ControladorCaixa controladorCaixa;

        public TelaCaixa(ControladorCaixa controladorCaixa):base("Tela Caixa")
        {
            this.controladorCaixa = controladorCaixa;
        }

        public override string ObterOpcao()
        {
            //apresenta as opções
            Console.WriteLine("Digite 1 para inserir novo caixa");
            Console.WriteLine("Digite 2 para visualizar caixas");
            Console.WriteLine("Digite 3 para editar um caixa");
            Console.WriteLine("Digite 4 para excluir um caixa");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Editar()
        {
            //visualiza os caixas
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual caixa atualizar
            try
            {
                Console.Write("Digite o id do caixa que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorCaixa.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id caixa com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id caixa não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Excluir()
        {
            //visualização dos caixas
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual caixa excluir
            try
            {
                Console.Write("Digite o número do caixa que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorCaixa.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Caixa excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir o caixa");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id caixa com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id caixa não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Visualizar()
        {
            Console.Clear();

            if (controladorCaixa.SelecionarTodosCaixas().Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum caixa cadastrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Caixas");
                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10}";

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(configuraColunasTabela, "Id", "Cor", "Etiqueta");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                Caixa[] caixas = controladorCaixa.SelecionarTodosCaixas();

                for (int i = 0; i < caixas.Length; i++)
                {
                    Console.Write(configuraColunasTabela,
                       caixas[i].id, caixas[i].cor, caixas[i].etiqueta);

                    Console.WriteLine();
                }
            }
        }

        public void Registrar(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                Console.Write("Digite a cor da caixa: ");
                string cor = Console.ReadLine();

                Console.Write("Digite a etiqueta da caixa: ");
                string etiqueta = Console.ReadLine();

                try
                {
                    Console.Write("Digite o numero da caixa: ");
                    double numero = Convert.ToDouble(Console.ReadLine());

                    resultadoValidacao = controladorCaixa.RegistrarCaixa(
                        id, cor, etiqueta, numero);

                    if (resultadoValidacao != "CAIXA_VALIDO")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(resultadoValidacao);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registro gravado com sucesso!");
                    }

                    Console.ReadLine();
                    Console.Clear();
                    Console.ResetColor();
                }
                catch 
                {
                    Console.WriteLine("Erro: Digite um valor que possa ser convertido para double");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (resultadoValidacao != "CAIXA_VALIDO");
        }
    }
}
