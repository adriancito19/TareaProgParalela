using System;
using System.Collections.Generic;
using System.Threading;

namespace Contador
{
    class Aplicacion
    {
        static void Main(string[] args)
        {
            List<ContadorParalelo> listaContadores = new List<ContadorParalelo>
            {
                new ContadorParalelo(1, 500),
                new ContadorParalelo(2, 1000),
                new ContadorParalelo(3, 1500)
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menú de Control de Contadores:");
                Console.WriteLine("1 - Activar Contador 1");
                Console.WriteLine("2 - Activar Contador 2");
                Console.WriteLine("3 - Activar Contador 3");
                Console.WriteLine("4 - Pausar Contador 1");
                Console.WriteLine("5 - Pausar Contador 2");
                Console.WriteLine("6 - Pausar Contador 3");
                Console.WriteLine("7 - Ver Estado de los Contadores");
                Console.WriteLine("8 - Cerrar Aplicación");

                var eleccion = Console.ReadKey().KeyChar;
                Console.Clear();

                switch (eleccion)
                {
                    case '1':
                        listaContadores[0].Comenzar();
                        break;
                    case '2':
                        listaContadores[1].Comenzar();
                        break;
                    case '3':
                        listaContadores[2].Comenzar();
                        break;
                    case '4':
                        listaContadores[0].Finalizar();
                        break;
                    case '5':
                        listaContadores[1].Finalizar();
                        break;
                    case '6':
                        listaContadores[2].Finalizar();
                        break;
                    case '7':
                        MostrarEstado(listaContadores);
                        break;
                    case '8':
                        TerminarPrograma(listaContadores);
                        return;
                }

                Thread.Sleep(1000);
            }
        }

        static void MostrarEstado(List<ContadorParalelo> listaContadores)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Estado de los contadores en tiempo real:");

                for (int i = 0; i < listaContadores.Count; i++)
                {
                    Console.WriteLine($"Contador {i + 1}:");
                    listaContadores[i].VerEstado();
                }

                Console.WriteLine("\nPresione 'Esc' para regresar al menú principal. El estado se actualizará automáticamente.");

                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;

                Thread.Sleep(500);
            }
        }

        static void TerminarPrograma(List<ContadorParalelo> listaContadores)
        {
            foreach (var contador in listaContadores)
            {
                contador.Finalizar();
            }
            Console.WriteLine("Cerrando el programa. Todos los contadores han sido detenidos.");
        }
    }
}

