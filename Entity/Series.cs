using System;
using System.Text;

namespace DIO.PSeries
{
    public class Series : EntityBase
    {
        public Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int year { get; set; }
        private bool active { get; set; }

        public Series(int id, Gender gender, string title, string description, int year)
        {
            this.id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.year = year;
            this.active = true;
        }

        public override string ToString()
        {
            var retorno = new StringBuilder();
            retorno.AppendLine($"Genre : {this.Gender}");
            retorno.AppendLine($"Title : {this.Title}");
            retorno.AppendLine($"Description : {this.Description}");
            retorno.AppendLine($"Year : {this.year}");
            retorno.AppendLine($"Ativo : {this.active}");

            return retorno.ToString();
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.id;
        }

        public void Disable()
        {
            this.active = false;
        }
    }

}