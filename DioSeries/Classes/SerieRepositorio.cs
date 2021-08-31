using System;
using System.Collections.Generic;
using DioSeries.Interfaces;

namespace DioSeries
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaserie = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            listaserie[id] = objeto;
        }
        public void Excluir(int id)
        {
            listaserie[id].Excluir();
        }
        public void Insere(Series objeto)
        {
            listaserie.Add(objeto);
        }
        public List<Series> Lista()
        {
            return listaserie;
        }
        public int ProximoId()
        {
            return listaserie.Count;
        }
        public Series RetornaPorId(int id)
        {
            return listaserie[id];
        }
    }
}