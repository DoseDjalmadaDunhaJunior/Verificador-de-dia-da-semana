using System;

namespace ConsoleApp1
{
    internal class Program
    {
        /// <summary>
        /// Retorna a chave do mês
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        private int chaveMes(int mes)
        {
            int chave = -1;
            if (mes == 4 || mes == 7)
            {
                chave = 0;
            }
            else if (mes == 1 || mes == 10)
            {
                chave = 1;
            }
            else if (mes == 5)
            {
                chave = 2;
            }
            else if (mes == 8)
            {
                chave = 3;
            }
            else if (mes == 3 || mes == 2 || mes == 11)
            {
                chave = 4;
            }
            else if (mes == 6)
            {
                chave = 5;
            }
            else if (mes == 12 || mes == 9)
            {
                chave = 6;
            }
            return chave;
        }

        /// <summary>
        /// Retorna a chave do ano
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        private int chaveAno(int ano)
        {
            int pivo;
            bool maior = false;
            if (ano > 1999 && ano < 2100)
            {
                maior = true;
                pivo = ano - 2000;
            }
            else if (ano > 1900)
            {
                pivo = ano - 1900;
            }
            else
            {
                return -1;
            }

            int chave = 6;
            if (pivo == 0 || pivo == 6 || pivo == 17
                || pivo == 23 || pivo == 28 || pivo == 34 || pivo == 45
                || pivo == 51 || pivo == 56 || pivo == 62 || pivo == 73
                || pivo == 19 || pivo == 84 || pivo == 90)
            {
                chave = 0;
            }
            else if (pivo == 1 || pivo == 7 || pivo == 12
                || pivo == 18 || pivo == 29 || pivo == 35 || pivo == 40
                || pivo == 46 || pivo == 57 || pivo == 63 || pivo == 68
                || pivo == 74 || pivo == 85 || pivo == 91 || pivo == 96)
            {
                chave = 1;
            }
            else if (pivo == 2 || pivo == 13 || pivo == 19
                || pivo == 24 || pivo == 30 || pivo == 41 || pivo == 47
                || pivo == 52 || pivo == 58 || pivo == 69 || pivo == 75
                || pivo == 80 || pivo == 86 || pivo == 97)
            {
                chave = 2;
            }
            else if (pivo == 3 || pivo == 8 || pivo == 14
                || pivo == 25 || pivo == 31 || pivo == 36 || pivo == 42
                || pivo == 53 || pivo == 59 || pivo == 64 || pivo == 70
                || pivo == 81 || pivo == 87 || pivo == 92 || pivo == 98)
            {
                chave = 3;
            }
            else if (pivo == 9 || pivo == 15 || pivo == 20
                || pivo == 26 || pivo == 37 || pivo == 43 || pivo == 48
                || pivo == 54 || pivo == 65 || pivo == 71 || pivo == 76
                || pivo == 82 || pivo == 93 || pivo == 99)
            {
                chave = 4;
            }
            else if (pivo == 4 || pivo == 10 || pivo == 21
                || pivo == 27 || pivo == 32 || pivo == 38 || pivo == 66
                || pivo == 49 || pivo == 55 || pivo == 60 || pivo == 77
                || pivo == 83 || pivo == 88 || pivo == 94)
            {
                chave = 5;
            }
            if (maior)
            {
                chave--;
            }
            return chave;
        }

        /// <summary>
        /// Para separar os valores da data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="po"></param>
        /// <returns></returns>
        private int separaValor(string data, int po)
        {
            try
            {
                string temp = string.Empty;
                if (po == 1)
                {   //primeiro caso (dia)
                    int i = 0;
                    for (i = 0; (data[i] != '/'); i++)
                    {
                        temp = temp + data[i];
                    }
                    return Int32.Parse(temp);
                }
                else if (po == 2)
                {
                    //Segundo caso (mes)
                    int i = 0;
                    for (i = 0; (data[i] != '/'); i++)
                    {

                    }
                    i++;
                    while (data[i] != '/')
                    {
                        temp = temp + data[i];
                        i++;
                    }
                    return Int32.Parse(temp);
                }
                else if (po == 3)
                {
                    //Terceiro caso (ano)
                    data = data + "/";
                    int i = 0;
                    for (i = 0; (data[i] != '/'); i++)
                    {

                    }
                    i++;
                    while (data[i] != '/')
                    {
                        i++;
                    }
                    i++;
                    while (data[i] != '/')
                    {
                        temp = temp + data[i];
                        i++;
                    }
                    return Int32.Parse(temp);
                }
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        /// <summary>
        /// Verifica se o ano é bisexto
        /// </summary>
        /// <param name="ano"></param>
        /// <returns></returns>
        private bool bisexto(int ano)
        {
            bool resp = false;
            if (((ano % 4 == 0) && (ano % 100 != 0) || (ano % 400 == 0)))
            {
                resp = true;
            }

            return resp;
        }

        /// <summary>
        /// Faz o calculo do dia da semana e imprime o dia na tela
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="mes"></param>
        /// <param name="ano"></param>
        private void dia(int dia, int mes, int ano)
        {
            int m, a;
            m = chaveMes(mes);
            a = chaveAno(ano);
            int pivo = dia + m + a;
            while (pivo > 6)
            {
                pivo = pivo - 7;
            }

            if (bisexto(ano))
            {
                pivo--;
                if (pivo > 0)
                {
                    pivo = 6;
                }
            }
            if (pivo == 1)
            {
                Console.WriteLine("Domingo");
            }
            else if (pivo == 2)
            {
                Console.WriteLine("Segunda");
            }
            else if (pivo == 3)
            {
                Console.WriteLine("Terça");
            }
            else if (pivo == 4)
            {
                Console.WriteLine("Quarta");
            }
            else if (pivo == 5)
            {
                Console.WriteLine("Quinta");
            }
            else if (pivo == 6)
            {
                Console.WriteLine("Sexta");
            }
            else
            {
                Console.WriteLine("Domingo");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("insira uma data no formato dd/mm/aaaa");
            string txt = Console.ReadLine();
            Program calculo = new Program();
            int dia = calculo.separaValor(txt, 1);
            int mes = calculo.separaValor(txt, 2);
            int ano = calculo.separaValor(txt, 3);
            calculo.dia(dia, mes, ano);

        }
    }
}
