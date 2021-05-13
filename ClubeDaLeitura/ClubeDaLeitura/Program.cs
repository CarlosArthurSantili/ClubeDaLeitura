using ClubeDaLeitura.Controladores;
using ClubeDaLeitura.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura
{
    class Program
    {
        const int CAPACIDADE_REGISTROS = 100;
        static void Main(string[] args)
        {
            ControladorCaixa controladorCaixa = new ControladorCaixa(CAPACIDADE_REGISTROS);

            ControladorAmiguinho controladorAmiguinho = new ControladorAmiguinho(CAPACIDADE_REGISTROS);
            
            ControladorRevista controladorRevista = new ControladorRevista(CAPACIDADE_REGISTROS, controladorCaixa);

            ControladorEmprestimo controladorEmprestimo = new ControladorEmprestimo(CAPACIDADE_REGISTROS, controladorAmiguinho, controladorRevista);

            

            TelaPrincipal telaPrincipal = new TelaPrincipal(controladorAmiguinho, controladorCaixa, controladorEmprestimo, controladorRevista);

            Console.Clear();

            while (true)
            {
                Console.Clear();
                TelaBase telaSelecionada = telaPrincipal.ObterTela();
                
                if (telaSelecionada == null)
                    break;
                string opcao = "";

                if (telaSelecionada is TelaBase)
                {
                    Console.Clear();
                    Console.WriteLine(((TelaBase)telaSelecionada).Titulo);
                    Console.WriteLine();
                    opcao = ((TelaBase)telaSelecionada).ObterOpcao();
                }

                if (telaSelecionada is TelaEmprestimo)
                {
                    if (opcao == "1")
                        ((TelaEmprestimo)telaSelecionada).Registrar(0);

                    else if (opcao == "2")
                    {
                        ((TelaEmprestimo)telaSelecionada).VisualizarEmprestimosAbertos();
                        Console.ReadLine();
                    }
                    else if (opcao == "3")
                    {
                        ((TelaEmprestimo)telaSelecionada).VisualizarEmprestimosEncerrados();
                        Console.ReadLine();
                    }
                    else if (opcao == "4")
                    {
                        ((TelaEmprestimo)telaSelecionada).DevolucaoEmprestimo();
                    }
                    else if (opcao == "5")
                    {
                        ((TelaEmprestimo)telaSelecionada).VisualizarEmprestimosEncerradosDoMes();
                        Console.ReadLine();
                    }
                }

                else if (telaSelecionada is TelaAmiguinho)
                {
                    if (opcao == "1")
                        ((TelaAmiguinho)telaSelecionada).Registrar(0);

                    else if (opcao == "2")
                    {
                        ((TelaAmiguinho)telaSelecionada).Visualizar();
                        Console.ReadLine();
                    }
                    else if (opcao == "3")
                    {
                        ((TelaAmiguinho)telaSelecionada).Editar();
                    }
                    else if (opcao == "4")
                    {
                        ((TelaAmiguinho)telaSelecionada).Excluir();
                    }
                }

                else if (telaSelecionada is TelaCaixa)
                {
                    if (opcao == "1")
                        ((TelaCaixa)telaSelecionada).Registrar(0);

                    else if (opcao == "2")
                    {
                        ((TelaCaixa)telaSelecionada).Visualizar();
                        Console.ReadLine();
                    }
                    else if (opcao == "3")
                    {
                        ((TelaCaixa)telaSelecionada).Editar();
                    }
                    else if (opcao == "4")
                    {
                        ((TelaCaixa)telaSelecionada).Excluir();
                    }
                }

                else if (telaSelecionada is TelaRevista)
                {
                    if (opcao == "1")
                        ((TelaRevista)telaSelecionada).Registrar(0);

                    else if (opcao == "2")
                    {
                        ((TelaRevista)telaSelecionada).Visualizar();
                        Console.ReadLine();
                    }
                    else if (opcao == "3")
                    {
                        ((TelaRevista)telaSelecionada).Editar();
                    }
                    else if (opcao == "4")
                    {
                        ((TelaRevista)telaSelecionada).Excluir();
                    }
                }


                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;


                Console.Clear();
            }
        }
    }
}
