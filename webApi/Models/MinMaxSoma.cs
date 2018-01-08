using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class MinMaxSoma
    {
        public static bool calcular(string linha, List<string> retorno)
        {
            //validação
            String[] coluna = linha.Split(' ');
            if (coluna.Length != 5)
            {
                retorno.Add("Número de parametros invalidos!");
                return false;
            }
            List<int> ret = new List<int>();
            min_max(coluna, 0, ret);
            int max = ret.Max();
            int min = ret.Min();
            retorno.Add(min.ToString() + " " + max.ToString());
            return true;
        }
        private static int[] min_max(string[] valores, int vezes, List<int> ret)
        {
            int soma = 0;
            for (int i = 0; i < valores.Length; i++)
            {
                if (i != vezes)
                {
                    soma += int.Parse(valores[i]);
                }
            }
            ret.Add(soma);
            if (vezes < valores.Length - 1)
            {
                vezes += 1;
                min_max(valores, vezes, ret);
            }
            return ret.ToArray();
        }
    }
}