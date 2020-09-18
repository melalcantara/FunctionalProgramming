using System;
using static System.Console;
using System.Collections.Generic;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine("\n[1] = FIBONACCI\n[2] = PRIMOS\n[3] = NATURALES\n[4] = EXIT");
                int opt = int.Parse(ReadLine());

                switch (opt)
                {
                    case 1:
                        var Fibonacci = FibonacciCounter();
                        Write("Porfavor, indique la cantidad de números: ");
                        int cant = int.Parse(ReadLine());
                        WriteLine();
                        for (int i = 0; i < 9; i++)
                        {
                            WriteLine(Fibonacci());
                        }
                        break;
                    case 2:
                        Write("Introduzca el número máximo: ");
                        int max = int.Parse(ReadLine());
                        var PrimosNum = GeneratePrime(max);
                        foreach (var num in PrimosNum)
                            WriteLine(num);
                        break;
                    case 3:
                        Write("Introduzca el número máximo: ");
                        int maxN = int.Parse(ReadLine());
                        var NaturalsNum = GenerateNaturals(maxN);
                        foreach (var natural in NaturalsNum)
                        {
                            WriteLine(natural);
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Se ha producido un error, por favor seleccione una opción válida.");
                        break;
                }
            }
        }

        static Func<int> FibonacciCounter()
        {
            int a = 0, b = 1;

            return delegate () {
                int c = a, d = b;
                b += a;
                a = d;
                return c;
            };
        }
        static IEnumerable<int> GeneratePrime(int cant)
        {
            List<int> listado = new List<int>();
            for (int i = 2; i <= cant; i++)
            {
                listado.Add(i);
            }

            for (int i = 0; i < listado.Count; i++)
            {
                for (int j = 0; j < listado.Count; j++)
                {
                    if (listado[i] != listado[j] && listado[j] % listado[i] == 0)
                    {
                        listado.RemoveAt(j);
                    }
                }
            }

            foreach (var i in listado)
                yield return i;

            WriteLine("\n¡Proceso terminado!");
        }

        static IEnumerable<int> GenerateNaturals(int cant)
        {
            for (int i = 0; i <= cant; i++)
            {
                yield return i;
            }

            WriteLine("\n¡Proceso terminado!");
        }
    }
}
