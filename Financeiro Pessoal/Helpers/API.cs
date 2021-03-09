using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Identity;
using Financeiro_Pessoal.Models;


namespace Financeiro_Pessoal.Helpers
{
    public class API : ComponentBase
    {
        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected HttpClient Http { get; set; }

        #region INDIVÍDUO
        public const string IndividuoApi = "api/individuos";

        public async Task<Individuo> GetIndividuo(int ID)
        {
            string url = $"{IndividuoApi}/GetIndividuo/{ID}";
            return await Http.GetFromJsonAsync<Individuo>(url);
        }

        public async Task<List<Individuo>> GetIndividuos()
        {
            return await GetIndividuosPesquisar(string.Empty);
        }

        public async Task<List<Individuo>> GetIndividuosPesquisar(string info)
        {
            string url = $"{IndividuoApi}/GetPesquisar/{CodificarString(info)}";
            return await Http.GetFromJsonAsync<List<Individuo>>(url);
        }

        public async Task PostIndividuo(Individuo individuo)
        {
            await Http.PostAsJsonAsync(IndividuoApi, individuo);
        }

        public async Task PutIndividuo(Individuo individuo)
        {
            string strPutApi = $"{IndividuoApi}/{individuo.ID}";
            await Http.PutAsJsonAsync(strPutApi, individuo);            
        }
        #endregion

        #region CATEGORIA
        public const string CategoriaApi = "api/categorias";

        public async Task<Categoria> GetCategoria(int ID)
        {
            string url = $"{CategoriaApi}/GetCategoria/{ID}";
            return await Http.GetFromJsonAsync<Categoria>(url);
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await GetCategoriasPesquisar(string.Empty, 0, 0);
        }

        public async Task<List<Categoria>> GetCategoriasPesquisar(string info, int tipo, int status)
        {
            int id = CodificarInt(info);
            info = CodificarString(info);
            string stats = CodificarBoolString(status);

            string url = $"{CategoriaApi}/GetPesquisar/{id}/{info}/{tipo}/{stats}";
            return await Http.GetFromJsonAsync<List<Categoria>>(url);
        }

        public async Task PostCategoria(Categoria categoria)
        {
            await Http.PostAsJsonAsync(CategoriaApi, categoria);
        }

        public async Task PutCategoria(Categoria categoria)
        {
            string strPutApi = $"{CategoriaApi}/{categoria.ID}";
            await Http.PutAsJsonAsync(strPutApi, categoria);
        }
        #endregion

        #region FINANCEIRO
        public const string FinanceiroApi = "api/financeiro";

        public async Task<Financeiro> GetFinanceiro(int ID)
        {
            string url = $"{FinanceiroApi}/GetFinanceiro/{ID}";
            return await Http.GetFromJsonAsync<Financeiro>(url);
        }

        public async Task<List<Financeiro>> GetFinanceiros()
        {
            return await GetFinanceiroPesquisar(string.Empty);
        }

        public async Task<List<Financeiro>> GetFinanceiroPesquisar(string info)
        {
            string url = $"{FinanceiroApi}/GetPesquisar/{CodificarString(info)}";
            return await Http.GetFromJsonAsync<List<Financeiro>>(url);
        }

        public async Task PostFinanceiro(Financeiro financeiro)
        {
            await Http.PostAsJsonAsync(FinanceiroApi, financeiro);
        }

        public async Task PutFinanceiro(Financeiro financeiro)
        {
            string strPutApi = $"{FinanceiroApi}/{financeiro.ID}";
            await Http.PutAsJsonAsync(strPutApi, financeiro);
        }
        #endregion
    

        #region PESQUISA
        public static int CodificarInt(string info)
        {
            int i = 0;
            int.TryParse(info, out i);

            return i;
        }

        public static string CodificarString(string info)
        {
            if (string.IsNullOrEmpty(info)) return "-";
            else return info.ToLower();
        }

        public static string DecodificarString(string info)
        {
            if (info == "-") return string.Empty;
            else return info.ToLower();
        }

        public static string CodificarBoolString(int i)
        {
            return i switch { 1 => "true", 2 => "false", _ => "-" };
        }
        #endregion
    }
}