using System;
using System.Threading;

namespace Contador
{
    public class ContadorParalelo
    {
        public int Id { get; }
        public int TiempoIntervalo { get; }
        public int Conteo { get; private set; }
        private Thread _hiloProceso;
        private bool _enEjecucion;

        public ContadorParalelo(int id, int tiempoIntervalo)
        {
            Id = id;
            TiempoIntervalo = tiempoIntervalo;
            Conteo = 0;
        }

        public void Comenzar()
        {
            if (!_enEjecucion)
            {
                _enEjecucion = true;
                _hiloProceso = new Thread(EjecutarConteo);
                _hiloProceso.Start();
                Console.WriteLine($"Contador {Id} iniciado.");
            }
            else
            {
                Console.WriteLine($"El contador {Id} ya está en ejecución.");
            }
        }

        public void Finalizar()
        {
            if (_enEjecucion)
            {
                _enEjecucion = false;
                _hiloProceso?.Join();
                Console.WriteLine($"Contador {Id} detenido.");
            }
            else
            {
                Console.WriteLine($"El contador {Id} ya está detenido.");
            }
        }

        private void EjecutarConteo()
        {
            while (_enEjecucion)
            {
                Conteo++;
                Thread.Sleep(TiempoIntervalo);
            }
        }

        public void VerEstado()
        {
            string estado = _enEjecucion ? "En ejecución" : "Detenido";
            Console.WriteLine($"Contador: {Id} Estado: {estado} - Valor actual: {Conteo}");
        }
    }
}
