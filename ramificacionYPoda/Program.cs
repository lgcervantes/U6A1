using System;
using System.Collections.Generic;
using System.Diagnostics;

class Item
{
    public int Id;
    public int Valor; 
    public int Peso;

    public Item(int id, int valor, int peso)
    {
        Id = id;
        Valor = valor;
        Peso = peso;
    }
}

class MochilaBranchAndBound
{
    static int mejorValor;
    static List<int> mejorSolucion;

    static long nodosGenerados;
    static long ramasPodadas;

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("====================================");
            Console.WriteLine(" PROBLEMA DE LA MOCHILA");
            Console.WriteLine(" RAMIFICACIÓN Y PODA");
            Console.WriteLine("====================================");
            Console.WriteLine("1. Resolver ejemplo de la actividad");
            Console.WriteLine("2. Capturar problema personalizado");
            Console.WriteLine("3. Salir");
            Console.WriteLine("====================================");

            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ResolverEjemploActividad();
                    break;

                case "2":
                    ResolverPersonalizado();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void ResolverEjemploActividad()
    {
        int capacidad = 101;

        List<Item> items = new List<Item>()
        {
            new Item(1,79,85),
            new Item(2,32,26),
            new Item(3,47,48),
            new Item(4,18,21),
            new Item(5,26,22),
            new Item(6,85,95),
            new Item(7,33,43),
            new Item(8,40,45),
            new Item(9,45,55),
            new Item(10,59,52)
        };

        Ejecutar(capacidad, items);
    }

    static void ResolverPersonalizado()
    {
        Console.Clear();

        Console.Write("Capacidad de la mochila: ");
        int capacidad = int.Parse(Console.ReadLine());

        Console.Write("Cantidad de objetos: ");
        int cantidad = int.Parse(Console.ReadLine());

        List<Item> items = new List<Item>();

        for (int i = 1; i <= cantidad; i++)
        {
            Console.WriteLine($"\nObjeto {i}");

            Console.Write("Valor: ");
            int valor = int.Parse(Console.ReadLine());

            Console.Write("Peso: ");
            int peso = int.Parse(Console.ReadLine());

            items.Add(new Item(i, valor, peso));
        }

        Ejecutar(capacidad, items);
    }

    static void Ejecutar(int capacidad, List<Item> items)
    {
        mejorValor = 0;
        mejorSolucion = new List<int>();

        nodosGenerados = 0;
        ramasPodadas = 0;

        Stopwatch sw = new Stopwatch();
        sw.Start();

        BranchAndBound(
            items,
            capacidad,
            0,
            0,
            0,
            new List<int>()
        );

        sw.Stop();

        Console.Clear();

        Console.WriteLine("=========== RESULTADO ===========");

        int pesoFinal = 0;

        Console.WriteLine("\nObjetos seleccionados:");

        foreach (int id in mejorSolucion)
        {
            Item item = items.Find(x => x.Id == id);

            Console.WriteLine(
                $"Objeto {item.Id} -> Valor={item.Valor}, Peso={item.Peso}");

            pesoFinal += item.Peso;
        }

        Console.WriteLine();
        Console.WriteLine($"Peso total : {pesoFinal}");
        Console.WriteLine($"Valor total: {mejorValor}");

        Console.WriteLine("\n======= ESTADÍSTICAS =======");
        Console.WriteLine($"Nodos generados : {nodosGenerados}");
        Console.WriteLine($"Ramas podadas   : {ramasPodadas}");
        Console.WriteLine($"Tiempo ejecución: {sw.ElapsedMilliseconds} ms");
        Console.WriteLine("============================");

        Console.ReadKey();
    }

    static void BranchAndBound(
        List<Item> items,
        int capacidad,
        int indice,
        int pesoActual,
        int valorActual,
        List<int> seleccionados)
    {
        nodosGenerados++;

        if (pesoActual > capacidad)
        {
            ramasPodadas++;
            return;
        }

        if (indice == items.Count)
        {
            if (valorActual > mejorValor)
            {
                mejorValor = valorActual;
                mejorSolucion = new List<int>(seleccionados);
            }

            return;
        }

        List<int> incluir = new List<int>(seleccionados);
        incluir.Add(items[indice].Id);

        BranchAndBound(
            items,
            capacidad,
            indice + 1,
            pesoActual + items[indice].Peso,
            valorActual + items[indice].Valor,
            incluir);

        BranchAndBound(
            items,
            capacidad,
            indice + 1,
            pesoActual,
            valorActual,
            seleccionados);
    }
}