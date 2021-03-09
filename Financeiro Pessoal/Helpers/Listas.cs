using System.Collections.Generic;

namespace Financeiro_Pessoal.Helpers
{
    public class Listas
    {
        public class Model
        {
            public int ID { get; set; }
            public string Descricao { get; set; }
        }

        #region ORDENAÇÃO
        public static List<Model> OrdemCategorias()
        {
            return new List<Model>
            {
                new Model { ID = 0, Descricao = "ID Asc." },
                new Model { ID = 1, Descricao = "ID Desc." },
                new Model { ID = 2, Descricao = "Descrição Asc." },
                new Model { ID = 3, Descricao = "Descrição Desc." },
                new Model { ID = 4, Descricao = "Tipo Asc." },
                new Model { ID = 5, Descricao = "Tipo Desc." },
                new Model { ID = 6, Descricao = "Status Asc." },
                new Model { ID = 7, Descricao = "Status Desc." }
            };
        }
        #endregion
    }
}