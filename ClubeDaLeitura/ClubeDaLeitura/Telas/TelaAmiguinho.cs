using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    class TelaAmiguinho : TelaBase, IRegistravel, IVisualizavel, IEditavel, IExcluivel
    {
        private readonly ControladorAmiguinho controladorAmiguinho;

        public TelaAmiguinho(ControladorAmiguinho controladorAmiguinho) : base("Controle de Amiguinhos")
        {
            this.controladorAmiguinho = controladorAmiguinho;
        }

        public override string ObterOpcao()
        {
            //apresenta as opções
            Console.WriteLine("Digite 1 para inserir novo amiguinho");
            Console.WriteLine("Digite 2 para visualizar amiguinhos");
            Console.WriteLine("Digite 3 para editar um amiguinho");
            Console.WriteLine("Digite 4 para excluir um amiguinho");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        public void Editar()
        {
            //visualiza os amiguinhos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual amiguinho atualizar
            try
            {
                Console.Write("Digite o número do amiguinho que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorAmiguinho.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id amiguinho com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id amiguinho não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Excluir()
        {
            //visualização dos amiguinhos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual amiguinho excluir
            try
            {
                Console.Write("Digite o número do amiguinho que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorAmiguinho.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorAmiguinho.ExcluirAmiguinho(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Amiguinho excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir o amiguinho");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id amiguinho com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id amiguinho não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Visualizar()
        {
            Console.Clear();

            if (controladorAmiguinho.SelecionarTodosAmiguinhos().Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum amiguinho cadastrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Amiguinhos");
                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10}";

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(configuraColunasTabela, "Id", "Nome", "Responsável", "Telefone");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                Amiguinho[] amiguinhos = controladorAmiguinho.SelecionarTodosAmiguinhos();

                for (int i = 0; i < amiguinhos.Length; i++)
                {
                    Console.Write(configuraColunasTabela,
                       amiguinhos[i].id, amiguinhos[i].nome, amiguinhos[i].nomeResponsavel, amiguinhos[i].telefone);

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
                Console.Write("Digite o nome do amiguinho: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o nome do responsável do amiguinho: ");
                string nomeResponsavel = Console.ReadLine();

                Console.Write("Digite o telefone do amiguinho: ");
                string telefone = Console.ReadLine();

                Console.Write("Digite o local onde o amiguinho mora: ");
                string localResidencia = Console.ReadLine();

                resultadoValidacao = controladorAmiguinho.RegistrarAmiguinho(
                    id, nome, nomeResponsavel, telefone, localResidencia);
                   
                


                if (resultadoValidacao != "AMIGUINHO_VALIDO")
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

            } while (resultadoValidacao != "AMIGUINHO_VALIDO");
        }

    }
}
