using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class Canguru
    {
        public static bool saltos(string linha, List<string> retorno)
        {
            String[] coluna = linha.Split(' ');

            //validações
            if (coluna.Length < 3 )
            {
                retorno.Add("Quantidade de parametros invalidos!");
                return false;
            }
            int x1 = int.Parse(coluna[0]);
            int v1 = int.Parse(coluna[1]);
            int x2 = int.Parse(coluna[2]);
            int v2 = int.Parse(coluna[3]);

            //validações
            if (x1 < 0 || x1 > 1000 || x2 < 0 || x2 > 1000 || x1 > x2)
            {
                retorno.Add("Erro no parametro");
                return false;
            }
            if (v1 <= 1 || v1 > 10000 || v2 <= 1 || v2 > 10000)
            {
                retorno.Add("Erro no parametro");
                return false;
            }

            for (int i = 1; i < 10000; i++)
            {
                //saldo do camguru
                x1 = x1 + v1;
                x2 = x2 + v2;

                if (x1 == x2)
                {
                    retorno.Add("YES");
                    return true;
                }
            }
            retorno.Add("NO");
            return true;
        }
    }
}