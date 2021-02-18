using Dio.Series.Enums;
using System;

namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            return "Genero: " + Genero + Environment.NewLine +
                   "Titulo: " + Titulo + Environment.NewLine +
                   "Descricao: " + Descricao + Environment.NewLine +
                   "Ano de Lancamento: " + Ano + Environment.NewLine +
                   "Excluido: " + Excluido;
        }

        public string RetonaTitulo()
        {
            return this.Titulo;
        }

        public int RetonaID()
        {
            return this.Id;
        }

        public bool RetonaExcluido()
        {
            return this.Excluido;
        }

        public void Exclui()
        {
            Excluido = true;
        }
    }

}
