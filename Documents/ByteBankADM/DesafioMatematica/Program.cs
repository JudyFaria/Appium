

using Desafio_Matematica;
using System.ComponentModel;

Console.WriteLine("Operaçoes Básica");

Operacoes operacoes = new Operacoes();

Console.WriteLine("Soma: " + operacoes.Soma.Calcular(100,30));
Console.WriteLine("Subitração: " + operacoes.Subtracao.Calcular(99, 3));
Console.WriteLine("Multiplicação: " + operacoes.Multiplicacao.Calcular(55, 20));
Console.WriteLine("Divisão: " + operacoes.Divisao.Calcular(63, 3));
