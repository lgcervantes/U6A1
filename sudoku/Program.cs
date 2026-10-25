using System;
using System.Diagnostics;

class SudokuSolver
{
    static long intentos;
    static long retrocesos;

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=========================================");
            Console.WriteLine(" SOLUCIÓN DE SUDOKU MEDIANTE BACKTRACKING");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Resolver Sudoku del ejercicio");
            Console.WriteLine("2. Resolver Sudoku de prueba #1");
            Console.WriteLine("3. Resolver Sudoku de prueba #2");
            Console.WriteLine("4. Capturar Sudoku manualmente");
            Console.WriteLine("5. Salir");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    EjecutarSudoku(SudokuEjercicio());
                    break;

                case "2":
                    EjecutarSudoku(SudokuPrueba1());
                    break;

                case "3":
                    EjecutarSudoku(SudokuPrueba2());
                    break;

                case "4":
                    EjecutarSudoku(CapturarSudoku());
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("\nOpción inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void EjecutarSudoku(int[,] tablero)
    {
        intentos = 0;
        retrocesos = 0;

        Console.Clear();

        Console.WriteLine("SUDOKU ORIGINAL\n");
        Imprimir(tablero);

        Stopwatch reloj = new Stopwatch();
        reloj.Start();

        bool solucion = Resolver(tablero);

        reloj.Stop();

        Console.WriteLine();

        if (solucion)
        {
            Console.WriteLine("SUDOKU RESUELTO\n");
            Imprimir(tablero);

            Console.WriteLine("\n========== ESTADÍSTICAS ==========");
            Console.WriteLine($"Intentos realizados : {intentos}");
            Console.WriteLine($"Retrocesos          : {retrocesos}");
            Console.WriteLine($"Tiempo de ejecución : {reloj.ElapsedMilliseconds} ms");
            Console.WriteLine("==================================");
        }
        else
        {
            Console.WriteLine("No existe solución para el Sudoku.");
        }

        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static bool Resolver(int[,] tablero)
    {
        for (int fila = 0; fila < 9; fila++)
        {
            for (int col = 0; col < 9; col++)
            {
                if (tablero[fila, col] == 0)
                {
                    for (int num = 1; num <= 9; num++)
                    {
                        intentos++;

                        if (EsValido(tablero, fila, col, num))
                        {
                            tablero[fila, col] = num;

                            if (Resolver(tablero))
                                return true;

                            tablero[fila, col] = 0;
                            retrocesos++;
                        }
                    }

                    return false;
                }
            }
        }

        return true;
    }

    static bool EsValido(int[,] tablero, int fila, int col, int num)
    {
        for (int i = 0; i < 9; i++)
        {
            if (tablero[fila, i] == num)
                return false;

            if (tablero[i, col] == num)
                return false;
        }

        int inicioFila = fila - fila % 3;
        int inicioCol = col - col % 3;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (tablero[inicioFila + i, inicioCol + j] == num)
                    return false;
            }
        }

        return true;
    }

    static void Imprimir(int[,] tablero)
    {
        Console.WriteLine("+-------+-------+-------+");

        for (int i = 0; i < 9; i++)
        {
            Console.Write("| ");

            for (int j = 0; j < 9; j++)
            {
                if (tablero[i, j] == 0)
                    Console.Write(". ");
                else
                    Console.Write(tablero[i, j] + " ");

                if ((j + 1) % 3 == 0)
                    Console.Write("| ");
            }

            Console.WriteLine();

            if ((i + 1) % 3 == 0)
                Console.WriteLine("+-------+-------+-------+");
        }
    }

    static int[,] CapturarSudoku()
    {
        int[,] tablero = new int[9, 9];

        Console.Clear();
        Console.WriteLine("CAPTURA DEL SUDOKU");
        Console.WriteLine("Use 0 para espacios vacíos.\n");

        for (int fila = 0; fila < 9; fila++)
        {
            for (int col = 0; col < 9; col++)
            {
                while (true)
                {
                    Console.Write($"Fila {fila + 1}, Columna {col + 1}: ");

                    if (int.TryParse(Console.ReadLine(), out int valor)
                        && valor >= 0
                        && valor <= 9)
                    {
                        tablero[fila, col] = valor;
                        break;
                    }

                    Console.WriteLine("Valor inválido.");
                }
            }
        }

        return tablero;
    }

    static int[,] SudokuEjercicio()
    {
        return new int[,]
        {
            {5,0,0,9,1,3,7,2,0},
            {3,0,0,0,8,0,5,0,9},
            {0,9,0,2,5,0,0,8,0},
            {6,8,0,4,7,0,2,3,0},
            {0,0,9,5,0,0,4,6,0},
            {7,0,4,0,0,0,0,0,5},
            {0,2,0,0,0,0,0,0,0},
            {4,0,0,8,9,1,6,0,0},
            {8,5,0,7,2,0,0,0,3}
        };
    }

    static int[,] SudokuPrueba1()
    {
        return new int[,]
        {
            {5,3,0,0,7,0,0,0,0},
            {6,0,0,1,9,5,0,0,0},
            {0,9,8,0,0,0,0,6,0},
            {8,0,0,0,6,0,0,0,3},
            {4,0,0,8,0,3,0,0,1},
            {7,0,0,0,2,0,0,0,6},
            {0,6,0,0,0,0,2,8,0},
            {0,0,0,4,1,9,0,0,5},
            {0,0,0,0,8,0,0,7,9}
        };
    }

    static int[,] SudokuPrueba2()
    {
        return new int[,]
        {
            {0,0,0,2,6,0,7,0,1},
            {6,8,0,0,7,0,0,9,0},
            {1,9,0,0,0,4,5,0,0},
            {8,2,0,1,0,0,0,4,0},
            {0,0,4,6,0,2,9,0,0},
            {0,5,0,0,0,3,0,2,8},
            {0,0,9,3,0,0,0,7,4},
            {0,4,0,0,5,0,0,3,6},
            {7,0,3,0,1,8,0,0,0}
        };
    }
}