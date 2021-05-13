using ClubeDaLeitura.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Telas
{
    public class TelaPrincipal : TelaBase
    {
        private readonly ControladorAmiguinho controladorAmiguinho;
        private readonly ControladorCaixa controladorCaixa;
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly ControladorRevista controladorRevista;

        public TelaPrincipal(ControladorAmiguinho controladorAmiguinho, ControladorCaixa controladorCaixa,
            ControladorEmprestimo controladorEmprestimo, ControladorRevista controladorRevista) : base("Tela Principal")
        {
            this.controladorAmiguinho = controladorAmiguinho;
            this.controladorCaixa = controladorCaixa;
            this.controladorEmprestimo = controladorEmprestimo;
            this.controladorRevista = controladorRevista;
        }

        public TelaBase ObterTela()
        {
            string opcao;
            TelaBase telaSelecionada = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Digite 1 para o Controle de Amiguinhos");
                Console.WriteLine("Digite 2 para o Controle de Caixas");
                Console.WriteLine("Digite 3 para o Controle de Emprestimos");
                Console.WriteLine("Digite 4 para o Controle de Revistas");

                Console.WriteLine("Digite S para Sair");

                opcao = Console.ReadLine();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    telaSelecionada = null;
                    return telaSelecionada;
                }
                else if (opcao == "1")
                {
                    telaSelecionada = new TelaAmiguinho(controladorAmiguinho);
                    return telaSelecionada;
                }
                else if (opcao == "2")
                {
                    telaSelecionada = new TelaCaixa(controladorCaixa);
                    return telaSelecionada;
                }
                else if (opcao == "3")
                {
                    telaSelecionada = new TelaEmprestimo(controladorEmprestimo, controladorAmiguinho, controladorRevista);
                    return telaSelecionada;
                }
                else if (opcao == "4")
                {
                    telaSelecionada = new TelaRevista(controladorRevista, controladorCaixa);
                    return telaSelecionada;
                }
                else
                {
                    Console.WriteLine("Opcao inválida, tente novamente");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (true);
        }

    }
}
