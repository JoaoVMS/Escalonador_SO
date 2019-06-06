using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Todas_as_Estruturas_de_Dados;

namespace Escalonador_SO
{
    class Escalonador
    {
        public Fila[] Todos { get; set; }
        readonly int Quantum, tContexto, sleep;

        public Escalonador(int Quantum, int tContexto, int sleep)
        {
            Todos = new Fila[10];

            for (int i = 0; i < Todos.Length; i++)
                Todos[i] = new Fila();

            this.Quantum = Quantum;
            this.tContexto = tContexto;
            this.sleep = sleep;
        }

        /// <summary>
        /// Simula a execução do escalonador
        /// </summary>
        public void Run()
        {
            int pos = 0;
            while (!TodosVazia() && pos < Todos.Length) // Enquanto todas as filas de processos não estiverem vazias
            {
                Console.WriteLine("\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));

                while (!Todos[pos].Vazio()) // Enquanto uma fila especifica não estiver vazia
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nTroca de contexto...");
                    Console.ForegroundColor = ConsoleColor.White;

                    Thread.Sleep(tContexto); // Simulando o tempo gasto pela troca de contexto

                    Processo processo = (Processo)(Todos[pos].Retirar()); // Retira o processo em execução da fila de processos

                    Console.WriteLine("Processando: " + processo.ToString());

                    if (CPU(processo) > 0) // Se o retorno da CPU for maior que 0, o processo foi finalizado
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Processo Finalizado");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else // O processo não terminou
                    {
                        AdicionarProcesso(processo); // Adiciona o processo em uma nova fila de prioridade (prioridade -1)
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Processo REBAIXADO para prioridade {0}", processo.Prioridade);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("\n\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));
                    Console.WriteLine("\n" + Todos[pos].ToString());
                }
                pos++;
            }
        }

        /// <summary>
        /// Simulation of the process execution
        /// </summary>
        /// <param name="p">Process to be executed</param>
        /// <returns>Returns 1, if the process was completed;
        /// Returns -1, if the process was not completed.</returns>
        private int CPU(Processo p)
        {
            int aux = 1; // represents how much of the quantum was completed

            while (aux <= Quantum && p.QtdeCiclos > 0)
            {
                p.DiminuirQtdeCiclos();
                Thread.Sleep(sleep); // Simula o tempo gasto pela CPU
                aux++;
            }

            if (p.QtdeCiclos == 0)
                return 1;
            else
                p.DiminuirPrioridade();

            return -1;
        }
        
        /// <summary>
        /// Allocate the process to it's new priority queue
        /// </summary>
        /// <param name="p">The process to be alocated</param>
        public void AdicionarProcesso(Processo p)
        {
            switch (p.Prioridade)
            {
                case 1: Todos[0].Inserir(p); break;
                case 2: Todos[1].Inserir(p); break;
                case 3: Todos[2].Inserir(p); break;
                case 4: Todos[3].Inserir(p); break;
                case 5: Todos[4].Inserir(p); break;
                case 6: Todos[5].Inserir(p); break;
                case 7: Todos[6].Inserir(p); break;
                case 8: Todos[7].Inserir(p); break;
                case 9: Todos[8].Inserir(p); break;
                case 10: Todos[9].Inserir(p); break;
                default: break;
            }
        }

        /// <summary>
        /// Verify if all priority queues are empty
        /// </summary>
        /// <returns></returns>
        public bool TodosVazia()
        {
            return Todos[0].Vazio() && Todos[1].Vazio() && Todos[2].Vazio() && Todos[3].Vazio() && Todos[4].Vazio() && Todos[5].Vazio() && Todos[6].Vazio() && Todos[7].Vazio() && Todos[8].Vazio() && Todos[9].Vazio();
        }
        
        /// <summary>
        /// Ta de brincation wit me?
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder auxImpressao = new StringBuilder();

            for (int pos = 0; pos < Todos.Length; pos++)
            {
                auxImpressao.AppendLine("\tPrioridade " + (pos + 1));
                auxImpressao.AppendLine(Todos[pos].ToString());
            }

            return auxImpressao.ToString();
        }
    }
}
