using System;
using System.Text;
using System.Collections.Generic;
using DIO.PSeries.Interfaces;

namespace DIO.PSeries
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            var userOption = string.Empty;
            do
            {
                userOption = GetUserOption();

                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DisableSeries();
                        break;
                    case "5":
                        GetInformationSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }

                Console.WriteLine("");

            } while (userOption.ToUpper() != "X");

        }

        private static string GetUserOption()
        {
            var options = new StringBuilder();

            options.AppendLine("Enter the desired option");

            options.AppendLine("1 - List Series");
            options.AppendLine("2 - Insert a new series");
            options.AppendLine("3 - Update a series");
            options.AppendLine("4 - Delete a series");
            options.AppendLine("5 - series information");
            options.AppendLine("C - Clear screen");
            options.AppendLine("X - exit");

            Console.Write(options.ToString());

            var userOption = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return userOption;
        }

        private static void ListSeries()
        {
            Console.WriteLine(repository.ListSeries());
        }

        private static void GetInformationSeries()
        {
            ListSeries();
            Console.WriteLine("Enter with id of the series");
            var userOption = int.Parse(Console.ReadLine());

            Console.WriteLine(repository.GetById(userOption).ToString());
        }

        private static void DisableSeries()
        {
            ListSeries();
            Console.WriteLine("Enter with id of the series");

            var userOption = int.Parse(Console.ReadLine());

            repository.Delete(userOption);

            Console.WriteLine("Serie Desativada!");
        }


        private static void GetUserSeriesInformation(int? id = null)
        {
            var header = "Insert a new series";
            int idcadastro = repository.NextId();

            if (id != null)
            {
                header = "Update a new series";
                idcadastro = id.Value;
            }

            Console.WriteLine(header);

            Console.WriteLine(GetGenreoptions());
            Console.WriteLine("Enter the desired gnre:");
            var genre = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter title of the series :");
            var title = Console.ReadLine();


            Console.WriteLine("Enter the start year of the series:");
            var year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the description of the series:");
            var descrition = Console.ReadLine();

            var newSeries =
                              new Series(id: idcadastro
                                        , (Gender)genre
                                        , title
                                        , descrition
                                        , year);

            if (id == null)
            {
                repository.Insert(newSeries);
            }
            else
            {
                repository.Update(idcadastro, newSeries);
            }
        }


        private static void InsertSeries()
        {
            GetUserSeriesInformation();
        }


        private static void UpdateSeries()
        {
            Console.WriteLine("Enter the id of the series:");
            var id = int.Parse(Console.ReadLine());

            GetUserSeriesInformation(id);
        }

        private static string GetGenreoptions()
        {
            var options = new StringBuilder();

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                options.AppendLine($"{i} - {Enum.GetName(typeof(Gender), i)}");
            }

            return options.ToString();
        }
    }
}
