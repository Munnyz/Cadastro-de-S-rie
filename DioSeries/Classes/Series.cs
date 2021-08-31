using System;

namespace DioSeries
{
    public class Series : EntidadeBase
    {
        public Series(int id, string titulo, string descricao, Genero genero, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Genero = genero;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
            {
                string retorno = "";

                retorno += "Genero = " + this.Genero + Environment.NewLine;
                retorno += "Titulo = " + this.Titulo + Environment.NewLine;
                retorno += "Descrição = " + this.Descricao + Environment.NewLine;
                retorno += "Ano de Inicio = " + this.Ano + Environment.NewLine;
                retorno += "Excluido = " + this.Excluido;
                return retorno;
            }

            public string retornaTitulo()
            {
                return this.Titulo;
            }
            public int retornaId()
            {
                return this.Id;
            }
            public bool retornaExcluido()
            {
                return this.Excluido;
            }
            public void Excluir() {
                this.Excluido = true;
            }


        public int Ano { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private Genero Genero { get; set; }
        private bool Excluido { get; set; }
    }
}