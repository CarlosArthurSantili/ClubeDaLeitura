using ClubeLeitura.ConsoleApp.Controladores;
using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaCadastroBasico<Caixa>, ICadastravel
    {
        public TelaCaixa(Controlador<Caixa> controlador)
            : base("Cadastro de Caixas", controlador)
        {
        }

        public override Caixa ObterRegistro(TipoAcao acao)
        {
            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            return new Caixa(cor, etiqueta);
        }
    }
}