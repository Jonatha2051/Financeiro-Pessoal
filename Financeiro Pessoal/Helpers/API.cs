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
        //[Inject] protected HttpClient Http { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }
        [Inject] protected HttpClient Http { get; set; }

        
        public string BaseURI(string url)
        {
            return string.Concat(Navigation.BaseUri, url);
        }

        #region INDIVÍDUO
        public const string IndividuoApi = "api/individuos";

        public async Task<Individuo> GetIndividuo(int ID)
        {
            string strGetApi = $"{IndividuoApi}/{ID}";
            return await Http.GetFromJsonAsync<Individuo>(strGetApi);
        }

        public async Task<List<Individuo>> GetIndividuos()
        {           
            return await Http.GetFromJsonAsync<List<Individuo>>(IndividuoApi);                    
        }

        public async Task<List<Individuo>> GetIndividuosPesquisa(string info)
        {
            int id;

            if (int.TryParse(info, out id))
                id = Convert.ToInt32(info);
            else
                id = 0;                      

            if (string.IsNullOrEmpty(info))
            {
                return await GetIndividuos();
            }                
            else
            {
                string strInfividuosPesquisa = $"{IndividuoApi}/{id}/{info.ToLower()}";
                return await Http.GetFromJsonAsync<List<Individuo>>(strInfividuosPesquisa);
            }
                
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
            string strGetApi = $"{CategoriaApi}/{ID}";
            return await Http.GetFromJsonAsync<Categoria>(strGetApi);
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            return await GetCategoriasPesquisar(string.Empty);
        }

        public async Task<List<Categoria>> GetCategoriasPesquisar(string info)
        {
            string url = $"{CategoriaApi}/GetPesquisar/{CodificarString(info)}";
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
        public const string FinanceiroApi = "api/financeiros";

        public async Task<Financeiro> GetFinanceiro(int ID)
        {
            string strGetApi = $"{FinanceiroApi}/{ID}";
            return await Http.GetFromJsonAsync<Financeiro>(strGetApi);
        }

        public async Task<List<Financeiro>> GetFinanceiros()
        {
            return await Http.GetFromJsonAsync<List<Financeiro>>(FinanceiroApi);
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
    
        #region OUTROS
        public static string CodificarString(string info)
        {
            if (string.IsNullOrEmpty(info)) return "-";
            else return info.ToLower();

        }

        public static string DecodificarString(string info)
        {
            if (info == "-") return string.Empty;
            else return info;
        }

        public static int DecodificarID(string info)
        {
            int id = 0;
            int.TryParse(info, out id);

            return id;
        }
        #endregion
    }
}