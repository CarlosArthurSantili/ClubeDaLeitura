using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    public class TelaRevista: TelaBase, IRegistravel, IVisualizavel, IEditavel, IExcluivel
    {
        private ControladorCaixa controladorCaixa;
        private ControladorRevista controladorRevista;

        public TelaRevista(ControladorRevista controladorRevista, ControladorCaixa controladorCaixa) : base("Controle de Revistas")
        {
            this.controladorRevista = controladorRevista;
            this.controladorCaixa = controladorCaixa;
        }

        public void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            try
            {
                Console.Write("Digite o id do revista que deseja excluir: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorRevista.VerificaIdExistente(idSelecionado))
                {
                    bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);
                    if (conseguiuExcluir)
                    {
                        Console.WriteLine("Revista excluído com sucesso");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Erro ao excluir o revista");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Não existe id revista com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }


            }
            catch
            {
                Console.WriteLine("Valor digitado de id revista não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();
            try
            {
                Console.Write("Digite o id do revista que deseja editar: ");
                int idSelecionado = Convert.ToInt32(Console.ReadLine());

                if (controladorRevista.VerificaIdExistente(idSelecionado))
                    Registrar(idSelecionado);
                else
                {
                    Console.WriteLine("Não existe id revista com esse valor de id, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch
            {
                Console.WriteLine("Valor digitado de id revista não é um 'int', tente novamente");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void Visualizar()
        {
            Console.Clear();
            Revista[] revistas = controladorRevista.SelecionarTodosRevistas();

            if (revistas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhuma revista registrado!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Visualização de Revistas");

                string configuraColunasTabela = "{0,-4} | {1,-8} | {2,-8} | {3,-8}";
                Console.ForegroundColor = ConsoleColor.Red;


                Console.WriteLine(configuraColunasTabela, "Id", "Caixa", "Tipo Coleção", "Ano Publicacao");

                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

                Console.ResetColor();

                foreach (Revista revista in revistas)
                {
                    Console.WriteLine("{0,-10} | {1,-30} | {2,-55} | {3,-25}",
                        revista.id, revista.caixa.etiqueta, revista.tipoColecao, revista.anoPublicacao);
                }

            }
        }

        public void VisualizarCaixas()
        {
            Console.Clear();

            Console.WriteLine("Visualização Caixas");
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

            if (caixas.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Nenhum caixa cadastrado!");
                Console.ResetColor();
            }
        }

        public void Registrar(int idRevistaSelecionado)
        {
            Console.Clear();
            string resultadoValidacao = "";
            if (controladorCaixa.SelecionarTodosCaixas().Length == 0)
            {
                Console.WriteLine("Não é possível cadastrar revistas sem caixas cadastrados");
                Console.ReadLine();
                Console.Clear();
                resultadoValidacao = "QTD_ID_CAIXA_INVALIDO";
            }
            else
            {
                do
                {
                    try
                    {
                        VisualizarCaixas();
                        Console.Write("Digite o id da caixa para a revista: ");
                        int idCaixaRevista = Convert.ToInt32(Console.ReadLine());
                        Console.Clear();
                        if (controladorCaixa.VerificaIdExistente(idCaixaRevista))
                        {
                            Console.Write("Digite o tipo de colecao da revista: ");
                            string tipoColecao = Console.ReadLine();

                            Console.Write("Digite o numero da edicao da revista: ");
                            string numeroEdicao = Console.ReadLine();
                            try
                            {
                                Console.Write("Digite o ano de publicacao da revista: ");
                                int anoPublicacao = Convert.ToInt32(Console.ReadLine());

                                resultadoValidacao = controladorRevista.RegistrarRevista(idRevistaSelecionado, idCaixaRevista, tipoColecao, numeroEdicao, anoPublicacao);

                                if (resultadoValidacao != "REVISTA_VALIDO")
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
                                Console.WriteLine("Valor de ano de publicacao digitado não é um 'int', tente novamente");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Valor de id caixa digitado não está cadastrado, tente novamente");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    catch 
                    {
                        Console.WriteLine("Valor de id caixa digitado não é um 'int', tente novamente");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    
                } while (resultadoValidacao != "REVISTA_VALIDO");
            }
        }

        public override string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para inserir novo revista");
            Console.WriteLine("Digite 2 para visualizar revistas");
            Console.WriteLine("Digite 3 para editar um revista");
            Console.WriteLine("Digite 4 para excluir um revista");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}
