using System.Collections.Generic;

namespace Financeiro_Pessoal.Helpers
{
    public class Rotinas
    {
        public class Model
        {
            public string Descricao { get; set; }
            public string Icone { get; set; }
            public string URL { get; set; }
        }

        #region CADASTROS
        public static Model Categorias = new Model { Descricao = "Categorias", Icone = "icon fas fa-layer-group", URL = "/categorias" };
        public static Model FormasPagamento = new Model { Descricao = "Formas de Pagamento", Icone = "icon fas fa-credit-card", URL = "/formaspagamento" };

        public static List<Model> Cadastros = new List<Model> { Categorias, FormasPagamento };
        #endregion

        #region FINANCEIRO
        public static Model Titulos = new Model { Descricao = "Títulos", Icone = "icon fas fa-money-check-alt", URL="/titulos" };

        public static List<Model> Financeiro = new List<Model> { Titulos };
        #endregion
    }
}