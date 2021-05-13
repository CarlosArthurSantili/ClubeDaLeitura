using ClubeDaLeitura.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.Controladores
{
    public class ControladorAmiguinho : ControladorBase
    {
        public ControladorAmiguinho(int capacidadeRegistros) : base (capacidadeRegistros)
        {
        }

        public string RegistrarAmiguinho(int id, string nome, string nomeResponsavel,
            string telefone, string localResidencia)
        {
            Amiguinho amiguinho;
            int posicao = 0;

            if (id == 0)
            {
                amiguinho = new Amiguinho();
                posicao = ObterPosicaoVazia();
            }
            else
            {
                Amiguinho amiguinhoSubstituido = SelecionarAmiguinhoPorId(id);
                posicao = ObterPosicaoOcupada(amiguinhoSubstituido);
                amiguinho = (Amiguinho)registros[posicao];
            }
            //nome, nome do responsável, telefone e de onde é o amigo.
            amiguinho.nome = nome;
            amiguinho.nomeResponsavel = nomeResponsavel;
            amiguinho.telefone = telefone;
            amiguinho.endereco = localResidencia;

            string resultadoValidacao = amiguinho.Validar();

            if (resultadoValidacao == "AMIGUINHO_VALIDO")
                registros[posicao] = amiguinho;

            return resultadoValidacao;
        }

        public bool ExcluirAmiguinho(int idSelecionado)
        {
            return ExcluirRegistro(new Amiguinho(idSelecionado));
        }

        public Amiguinho SelecionarAmiguinhoPorId(int id)
        {
            return (Amiguinho)SelecionarRegistro(new Amiguinho(id));
        }

        public Amiguinho[] SelecionarTodosAmiguinhos()
        {
            Amiguinho[] amiguinhosAux = new Amiguinho[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), amiguinhosAux, amiguinhosAux.Length);

            return amiguinhosAux;
        }

        public bool VerificaIdExistente(int idCheck)
        {
            foreach (Amiguinho e in SelecionarTodosAmiguinhos())
            {
                if (e.id == idCheck)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
