namespace Financeiro_Pessoal.Helpers 
{
    public class StringFormat 
    {
         public static string Telefone(string tel)
        {
            try
            {
                switch (tel.Length)
                {
                    case 8:
                        if (tel.StartsWith("3"))
                            return $"(74) {tel.Substring(0, 4)}-{tel.Substring(4, 4)}";
                        else
                            return $"(74) 9 {tel.Substring(0, 4)}-{tel.Substring(4, 4)}";

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
    }
}