using ClubeLeitura.ConsoleApp.Dominio;
using System;
using System.Collections.Generic;

namespace ClubeLeitura.ConsoleApp.Controladores
{
    public class Controlador<T> where T : EntidadeBase
    {
        protected List<T> itens = new List<T>();
        private int ultimoId;

       public string Adicionar(T item)
        {
            string resultadoValidacao = item.Validar();

            if (resultadoValidacao == "VALIDO")
            {
                item.id = NovoId();
                itens.Add(item);
            }

            return resultadoValidacao;
        }

        public bool ExisteRegistro(int id)
        {
            return itens.Exists(x => x.id == id);
        }

        public bool ExcluirRegistro(int id)
        {
            return itens.Remove(SelecionarRegistroPorId(id));
        }

        public List<T> SelecionarTodosRegistros()
        {
            return itens;
        }

        public T SelecionarRegistroPorId(int id)
        {
            T item = null;
            if (ExisteRegistro(id))
                item = itens.Find(x => x.id == id);
            return item;
        }

        public string Editar(int id, T item)
        {
            int index = itens.FindIndex(x => x.id == id);
            string resultadoValidacao = item.Validar();

            if (resultadoValidacao == "VALIDO")
            {
                item.id = id;
                itens.Insert(index, item);
                itens.RemoveAt(index+1);
            }
            return resultadoValidacao;
        }

        protected int QtdRegistrosCadastrados()
        {
            return itens.Count;
        }

        protected int NovoId()
        {
            return ++ultimoId;
        }
    }
}