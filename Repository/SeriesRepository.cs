using System;
using System.Text;
using System.Collections.Generic;
using DIO.PSeries.Interfaces;

namespace DIO.PSeries
{
    public class SeriesRepository : IRepository<Series>
    {
        private List<Series> SeriesList;

        public SeriesRepository()
        {
            this.SeriesList = new List<Series>();
        }

        public void Delete(int id)
        {
            SeriesList[id].Disable();
        }

        public Series GetById(int id)
        {
            return SeriesList[id];
        }

        public void Insert(Series entity)
        {
            SeriesList.Add(entity);
        }

        public List<Series> List()
        {
            return SeriesList;
        }

        public int NextId()
        {
            return SeriesList.Count;
        }

        public void Update(int id, Series entidade)
        {
            SeriesList[id] = entidade;
        }

        public string ListSeries()
        {
            if (this.NextId() == 0)
            {
                return "no series registered";
            }

            var txt = new StringBuilder();
            txt.AppendLine(" Series List");

            foreach (var series in SeriesList)
            {
                txt.AppendLine($"#ID: {series.GetId()} - {series.GetTitle()}");
            }

            return txt.ToString();
        }
    }
}