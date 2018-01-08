using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApi.Models
{
    public class QuaseOrdenado
    {
        //validações
        public static bool calcular(string linhas, List<string> retorno)
        {
            //​2 <= n​ ​<=​ ​100000
            //0 <= Di​ ​<=​ ​1000000
            int i = 0;
            int tamMatriz = 0;
            foreach (string linha in linhas.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None))
            {
                // Use a tab to indent each line of the file.
                if (i==0)
                {
                    if (!int.TryParse(linha, out tamMatriz))
                    {
                        retorno.Add("Valor da primeira linha não é um númerico!");
                        return false;
                    }
                    if (tamMatriz < 2 || tamMatriz > 100000)
                    {
                        retorno.Add("primeira linha deve ser maior que 2 e menor que 100000!");
                        return false;
                    }
                    i++;
                }
                else
                {
                    return ordenar(tamMatriz, linha, retorno);
                }
            }

            return true;
        }

        private static bool ordenar(int tamMatriz, string linhas, List<string> retorno)
        {
            String[] coluna = linhas.Split(' ');
            if (coluna.Length != tamMatriz)
            {
                retorno.Add("Tamanho​ ​da​ ​matriz informada não é valida!");
                return false;
            }

            retorno.Add(site(tamMatriz, coluna));
            return true;
            /*
            //testa swap
            if (tamMatriz == 2)
            {
                if (int.Parse(coluna[0]) > int.Parse(coluna[1]))
                {
                    retorno.Add("Sim \r\n Swap 1 2");
                }
                else if (int.Parse(coluna[1]) > int.Parse(coluna[0]))
                {
                    retorno.Add("Sim");
                }
            }
            else
            {
                String[] arrayOrdenado = null;
                Array.Copy(coluna, arrayOrdenado, coluna.Length);
                Array.Sort(arrayOrdenado);

                if (Array.Equals(coluna, arrayOrdenado))
                {
                    retorno.Add("Sim");
                }
            }
            return true;*/
        }

        public string Inverter(string texto)
        {
            if (texto == null)
            {
                return null;
            }
            char[] array = texto.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        private static string site(int n, string[] arrayPass)
        {
            int[] a = new int[n];
            int count = 0;
            int u = 0, v = 0;
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(arrayPass[i]);
                if (i > 0 && a[i - 1] > a[i])
                {
                    ++count;
                    if (u == 0)
                    {
                        u = i;
                    }
                    v = i;
                }
            }
            if (count == 1)
            {
                if (n > 2 && a[u - 1] < a[v + 1] && a[v] > a[u - 2 >= 0 ? u - 2 : 0])
                {
                    return "Sim\nswap " + u + " " + (v + 1);
                }
                else if (n == 2)
                {
                    return "Sim\nswap " + u + " " + (v + 1);
                }
                else
                {
                    return "Não";
                }
            }
            else if (count == 2)
            {
                return "Sim\nswap " + u + " " + (v + 1);
            }
            else if (count > 1)
            {
                if (a[u - 2] < a[v] && a[u - 1] < a[v + 1] && v - u == count - 1)
                {
                    return "Sim\nreverse " + u + " " + (v + 1);
                }
                else
                {
                    return "Não";
                }
            }
            else if (count == 0)
            {
                return "Sim";
            }

            return "erro";
        }

    }
}