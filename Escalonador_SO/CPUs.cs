using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Escalonador_SO
{
    class CPUs
    {
        
        Processo process;
        bool processando;

        public Processo getProcesso
        {
            set // "processo entrando na cpu"
            {
                Monitor.Enter(this);

                if (processando) // se a cou estiver ocupada, espera
                    Monitor.Wait(this);

                process = value;
                processando = true;

                for (int i = 0; i < process.Prioridade && i < process.QtdeCiclos - 1; i++) // simular execução do threads repete a quantidade de quantuns
                {
                    Thread.Sleep(300);
                    process.DiminuirQtdeCiclos();
                }

                if (process.QtdeCiclos != 0)
                    process.DiminuirPrioridade();

                processando = false;

                Monitor.Pulse(this);
                Monitor.Exit(this);
            }
            get // "processo saindo da cpu"
            {
                Monitor.Enter(this);

                if (processando || process == null)
                    Monitor.Wait(this);

                return process;
            }
        }

        ///// <summary>
        ///// Simulation of the process execution
        ///// </summary>
        ///// <param name="p">Process to be executed</param>
        ///// <returns>Returns 1, if the process was completed;
        ///// Returns -1, if the process was not completed.</returns>
        //private int CPU(Processo p)
        //{
        //    int aux = 1; // represents how much of the quantum was completed

        //    while (aux <= Quantum && p.QtdeCiclos > 0)
        //    {
        //        p.DiminuirQtdeCiclos();
        //        Thread.Sleep(sleep); // Simula o tempo gasto pela CPU
        //        aux++;
        //    }

        //    if (p.QtdeCiclos == 0)
        //        return 1;
        //    else
        //        p.DiminuirPrioridade();

        //    return -1;
        //}
    
}
}
