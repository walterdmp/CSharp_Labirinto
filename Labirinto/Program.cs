﻿using System;
using System.Collections.Generic;



namespace LabirintodoRato
{
    internal class LabirintodoRato
    {

        private const int limit = 20;


        static void mostrarLabirinto(char[,] array, int l, int c)
        {
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
            }
            Console.WriteLine();
        }

        static void criaLabirinto(char[,] meuLab)
        {
            Random random = new Random();
            for (int i = 0; i < limit; i++)
            {
                for (int j = 0; j < limit; j++)
                {
                    meuLab[i, j] = random.Next(4) == 1 ? '*' : ' ';
                }
            }


            for (int i = 0; i < limit; i++)
            {
                meuLab[0, i] = '*';
                meuLab[limit - 1, i] = '*';
                meuLab[i, 0] = '*';
                meuLab[i, limit - 1] = '*';
            }


            int x = random.Next(1, limit - 1);
            int y = random.Next(1, limit - 1);
            meuLab[x, y] = 'Q';
        }

        static void buscarQueijo(char[,] meuLab, int i, int j)
        {
            Stack<int> pilha = new Stack<int>();
            int linha = 0, coluna = 0;
            char sentido = '0';


            do
            {

                meuLab[i, j] = '¢';

                if (meuLab[i - 1, j] == 'Q' || meuLab[i + 1, j] == 'Q' || meuLab[i, j + 1] == 'Q' || meuLab[i, j - 1] == 'Q')
                {
                    Console.Clear();
                    mostrarLabirinto(meuLab, limit, limit);
                    Console.WriteLine("O rato encontrou o queijo!");
                    break;
                }


                if (meuLab[i, j + 1] == ' ')
                {
                    linha = i;
                    coluna = j;
                    pilha.Push(i);
                    pilha.Push(j);
                    j++;
                    sentido = '-';

                }
                else if (meuLab[i + 1, j] == ' ')
                {
                    linha = i;
                    coluna = j;
                    pilha.Push(i);
                    pilha.Push(j);
                    i++;
                    sentido = '|';
                }
                else if (meuLab[i, j - 1] == ' ')
                {
                    linha = i;
                    coluna = j;
                    pilha.Push(i);
                    pilha.Push(j);
                    j--;
                    sentido = '-';
                }
                else if (meuLab[i - 1, j] == ' ')
                {
                    linha = i;
                    coluna = j;
                    pilha.Push(i);
                    pilha.Push(j);
                    i--;
                    sentido = '|';
                }
                else if (pilha.Count > 0)
                {
                    linha = i;
                    coluna = j;
                    j = pilha.Pop();
                    i = pilha.Pop();
                }

                else
                {
                    Console.WriteLine("Não foi possível encontrar o queijo.");
                    break;
                }

                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                mostrarLabirinto(meuLab, limit, limit);
                meuLab[linha, coluna] = sentido;

            } while (meuLab[i, j] != 'Q');
        }


        public static void Main(String[] args)
        {
            char[,] labirinto = new char[limit, limit];
            criaLabirinto(labirinto);
            mostrarLabirinto(labirinto, limit, limit);
            buscarQueijo(labirinto, 1, 1);
            Console.ReadKey();
        }
    }
}