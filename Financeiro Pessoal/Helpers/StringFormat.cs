using System;
using System.Linq;
using System.Net.Http;
using System.Collections.Generic;

namespace Financeiro_Pessoal.Helpers 
{
    public class StringFormat 
    {
         public static string CPF_CNPJ(string cpfCnpj)
        {
            try
            {
                if (cpfCnpj.Length != 0 && !cpfCnpj.Contains("."))
                {
                    switch (cpfCnpj.Length)
                    {
                        case 11:
                            return $"{cpfCnpj.Substring(0, 3)}.{cpfCnpj.Substring(3, 3)}.{cpfCnpj.Substring(6, 3)}-{cpfCnpj.Substring(9, 2)}";

                        case 14:
                            return $"{cpfCnpj.Substring(0, 2)}.{cpfCnpj.Substring(2, 3)}.{cpfCnpj.Substring(5, 3)}/{cpfCnpj.Substring(8, 4)}-{cpfCnpj.Substring(12, 2)}";

                        default:
                            return cpfCnpj;
                    }
                }
                else
                {
                    return cpfCnpj;
                }
               
            }
            catch
            {
                return cpfCnpj;
            }

        }

        public static string Telefone(string tel)
        {
            try
            {
                switch (tel.Length)
                {
                    case 8:
                        if (tel.StartsWith("3"))
                            return $"(87) {tel.Substring(0, 4)}-{tel.Substring(4, 4)}";
                        else
                            return $"(87) 9 {tel.Substring(0, 4)}-{tel.Substring(4, 4)}";

                    case 9:
                        return $"(87) {tel.Substring(0, 1)} {tel.Substring(1, 4)}-{tel.Substring(5, 4)}";

                    case 10:
                        return $"({tel.Substring(0, 2)}) {tel.Substring(2, 4)}-{tel.Substring(6, 4)}";

                    case 11:
                        return $"({tel.Substring(0, 2)}) {tel.Substring(2, 1)} {tel.Substring(3, 4)}-{tel.Substring(7, 4)}";

                    default:
                        return tel;
                }
            }
            catch
            {
                return tel;
            }
        }

        public static string CEP(string cep)
        {
            try
            {
                if (cep.Length == 8) 
                    return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
                else 
                    return cep;
            }
            catch
            {
                return cep;
            }
        }

        public static string RemoverEspaços(string info)
        {
            if (info.Last() == ' ') return info.Substring(0, (info.Length - 1));
            else return info;
        }

        public static string TagsTratamentoGravacao(string str)
        {
            bool aberto = false;
            string composicao = null;         
            
            if (!string.IsNullOrEmpty(str))
            {
                foreach (var s in str.ToCharArray())//Negrito Gravação
                {
                    if (s.ToString() == "*")
                    {
                        if (!aberto)
                        {
                            composicao += "<b>";
                            aberto = true;
                        }
                        else
                        {
                            composicao += "</b>";
                            aberto = false;
                        }
                    }
                    else
                    {
                        composicao += s.ToString();
                    }
                }
            }
                             
            return composicao;
        }

        public static string TagsTratamentoLeitura(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Contains("<b>") || str.Contains("</b>")) //Negrito Leitura
                {
                    str = str.Replace("<b>", "*");
                    str = str.Replace("</b>", "*");
                }
            }
            
            return str;
        }
    
        public static string Dinheiro(double valor)
        {
            if (valor < 1000) return $"R${valor.ToString("0.00")}";
            else if (valor >= 1000 && valor < 10000) return $"R${valor.ToString("0,000.00")}";
            else return $"R${valor.ToString("0,000,000.00")}";
        }

        public static string ContextErrors(IEnumerable<string> erros)
        {
            string Erros = $"<b>{erros.Count().ToString("00")} erro(s) encontrado(s):</b><br/>";
            
            foreach (var erro in erros) Erros = string.Concat(Erros, "<br/>", erro);

            return Erros;
        }

        public static int ResponseMessage(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode) return Convert.ToInt32(result.Headers.Location.Query.Replace("?id=", ""));
            else return 0;
        }
    }
}