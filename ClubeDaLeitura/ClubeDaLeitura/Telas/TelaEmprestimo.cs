using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    class TelaEmprestimo: TelaBase, IRegistravel
    {
        private ControladorEmprestimo controladorEmprestimo;
        private ControladorAmiguinho controladorAmiguinho;
        private ControladorRevista controladorRevista;


        public TelaEmprestimo(ControladorEmprestimo controladorEmprestimo, ControladorAmiguinho controladorAmiguinho, ControladorRevista controladorRevista) : base("Controle de Emprestimos")
        {
            this.controladorEmprestimo = controladorEmprestimo;
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorRevista = controladorRevista;
        }

        public void DevolucaoEmprestimo()
        {
            Console.Clear();

            VisualizarEmprestimosAbertos();

            Console.WriteLine();
            if (controladorRevista.QtdRevistasEmprestadas()==0)
            {
                Console.WriteLine("Não há nenhuma revista emprestadas para fazer devolução");
                Console.ReadLine();
                Console.Clear();
            }
            else 
            {
                try
                {
                    Console.Write("Digite o id do emprestimo que deseja devolver: ");
                    int idSelecionado = Convert.ToInt32(Console.ReadLine());

                    if (controladorEmprestimo.VerificaIdExistente(idSelecionado))
                    {
                        if(!controladorRevista.VerificaRevistaDisponivel(idSelecionado))
                        {
                            bool conseguiuDevolver = controladorEmprestimo.DevolverEmprestimo(idSelecionado);
                            if (conseguiuDevolver)
                            {
                                Console.WriteLine("Emprestimo encerrado com sucesso");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Erro ao encerrar o emprestimo");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Erro: Essa revista não estava emprestada");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    
                    }
                    else
                    {
                        Console.WriteLine("Não existe id emprestimo com esse valor de id, tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }


                }
                catch
                {
                    Console.WriteLine("Valor digitado de id emprestimo não é um 'int', tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }

        public void VisualizarEmprestimosAbertos()
        {
            Console.Clear();
            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum emprestimo registrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Emprestimos Abertos");

                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10}";
                Console.ForegroundColor = ConsoleColor.Red;


                Console.WriteLine(configuraColunasTabela, "Id", "Revista id", "Amiguinho", "Abertura");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                foreach (Emprestimo emprestimo in emprestimos)
                {
                    if (emprestimo.dataDevolucao == DateTime.MinValue)
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10}",
                            emprestimo.id, emprestimo.revista.id, emprestimo.amiguinho.nome, emprestimo.dataEmprestimo);
                    }
                }

            }
        }

        public void VisualizarEmprestimosEncerrados()
        {
            Console.Clear();
            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();

            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum emprestimo registrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Emprestimos Encerrados");

                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}";
                Console.ForegroundColor = ConsoleColor.Red;


                Console.WriteLine(configuraColunasTabela, "Id", "Revista id", "Nome Amiguinho", "Abertura", "Devolucao");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                foreach (Emprestimo emprestimo in emprestimos)
                {
                    if (emprestimo.dataDevolucao != DateTime.MinValue)
                    {
                        Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}",
                            emprestimo.id, emprestimo.revista.id, emprestimo.amiguinho.nome, emprestimo.dataEmprestimo, emprestimo.dataDevolucao);
                    }
                }

            }
        }

        public void VisualizarEmprestimosEncerradosDoMes()
        {
            Console.Clear();
            Emprestimo[] emprestimos = controladorEmprestimo.SelecionarTodosEmprestimos();


            if (emprestimos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum emprestimo registrado!");
                Console.ResetColor();
            }
            else
            {

                Console.WriteLine("Visualização de Emprestimos Encerrados no Último Mês: ", DateTime.Now.Month);

                string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}";
                Console.ForegroundColor = ConsoleColor.Red;


                Console.WriteLine(configuraColunasTabela, "Id", "Revista id", "Nome Amiguinho", "Abertura", "Devolucao");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                foreach (Emprestimo emprestimo in emprestimos)
                {
                    if (emprestimo.dataDevolucao != DateTime.MinValue)
                    {
                        if (emprestimo.dataDevolucao.Month == DateTime.Now.Month)
                        {
                            Console.WriteLine("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}",
                                emprestimo.id, emprestimo.revista.id, emprestimo.amiguinho.nome, emprestimo.dataEmprestimo, emprestimo.dataDevolucao);
                        }
                    }
                }

            }
        }

        public void VisualizarAmiguinhos()
        {
            Console.Clear();

            Console.WriteLine("Visualização Amiguinhos");
            string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10}";

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuraColunasTabela, "Id", "Nome", "Responsável", "Telefone", "Endereco");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            Amiguinho[] amiguinhos = controladorAmiguinho.SelecionarTodosAmiguinhos();

            for (int i = 0; i < amiguinhos.Length; i++)
            {
                Console.Write(configuraColunasTabela,
                   amiguinhos[i].id, amiguinhos[i].nome, amiguinhos[i].nomeResponsavel, amiguinhos[i].telefone, amiguinhos[i].endereco);

                Console.WriteLine();
            }

            if (amiguinhos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum amiguinho cadastrado!");
                Console.ResetColor();
            }
        }

        public void VisualizarRevistas()
        {
            Console.Clear();

            Console.WriteLine("Visualização de Revistas");
            string configuraColunasTabela = "{0,-10} | {1,-10} | {2,-10} | {3,-10}";

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuraColunasTabela, "Id", "Tipo de Colecao", "Numero Edicao", "Ano Publicacao");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();

            Revista[] revistas = controladorRevista.SelecionarTodosRevistas();

            for (int i = 0; i < revistas.Length; i++)
            {
                Console.Write(configuraColunasTabela,
                    revistas[i].id, revistas[i].tipoColecao, revistas[i].numeroEdicao, revistas[i].anoPublicacao);

                Console.WriteLine();
            }
        }

        public void Registrar(int idEmprestimoSelecionado)
        {
            Console.Clear();
            string resultadoValidacao = "";
            if (controladorAmiguinho.SelecionarTodosAmiguinhos().Length == 0)
            {
                Console.WriteLine("Não é possível cadastrar emprestimos sem amiguinhos cadastrados");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_AMIGUINHO_INVALIDO";
            }
            else if (controladorRevista.SelecionarTodosRevistas().Length == 0)
            {
                Console.WriteLine("Não é possível cadastrar emprestimos sem revistas cadastrados");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_REVISTA_INVALIDO";
            }
            else if(controladorRevista.QtdRevistasDisponiveis() == 0)
            {
                Console.WriteLine("Não é possível cadastrar emprestimos sem revistas disponiveis para emprestimo");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_REVISTA_DISPONIVEIS_INVALIDO";
            }
            else if (controladorEmprestimo.QtdAmiguinhosValidosParaEmprestar() == 0)
            {
                Console.WriteLine("Não é possível cadastrar emprestimos sem amiguinhos disponiveis para emprestimo\n(Todos amiguinhos cadastrados tem pelo menos um emprestimo)");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_REVISTA_DISPONIVEIS_INVALIDO";
            }
            else
            {
                do
                {
                    try
                    {
                        VisualizarAmiguinhos();
                        Console.Write("Digite o id do amiguinho que solicitou o emprestimo: ");
                        int idAmiguinhoEmprestimo = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        
                        if (controladorAmiguinho.VerificaIdExistente(idAmiguinhoEmprestimo))
                        {
                            if(controladorEmprestimo.VerificaAmiguinhoValidoParaEmprestar(idAmiguinhoEmprestimo))
                            {
                                try
                                {
                                    VisualizarRevistas();
                                    Console.Write("Digite o id do revista solicitado para o emprestimo: ");
                                    int idRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    if (controladorRevista.VerificaIdExistente(idRevistaEmprestimo))
                                    {

                                        if (controladorRevista.VerificaRevistaDisponivel(idRevistaEmprestimo))
                                        {
                                            resultadoValidacao = controladorEmprestimo.RegistrarEmprestimo(idEmprestimoSelecionado, idAmiguinhoEmprestimo, idRevistaEmprestimo);

                                            if (resultadoValidacao != "EMPRESTIMO_VALIDO")
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
                                        else
                                        {
                                            Console.WriteLine("Erro: Essa revista não está disponivel para emprestimo, tente novamente");
                                            Console.ReadLine();
                                            Console.Clear();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor de id revista digitado não está cadastrado, tente novamente");
                                        Console.ReadLine();
                                        Console.Clear();
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("Valor de id revista digitado não é um 'int', tente novamente");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                            else 
                            {
                                Console.WriteLine("Erro: Amiguinho já fez emprestimo, devolva a revista antes de fazer outro empréstimo");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Valor de id amiguinho digitado não está cadastrado, tente novamente");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Valor de id amiguinho digitado não é um 'int', tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }
                } while (resultadoValidacao != "EMPRESTIMO_VALIDO");
            }
        }

        public override string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo emprestimo");
            Console.WriteLine("Digite 2 para visualizar todos emprestimos em aberto");
            Console.WriteLine("Digite 3 para visualizar todos emprestimos encerrados");
            Console.WriteLine("Digite 4 para encerrar um emprestimo");
            Console.WriteLine("Digite 5 para visualizar emprestimos encerrados do mês");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
