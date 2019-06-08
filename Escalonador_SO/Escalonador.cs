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
        public Fila[] Todoscesss { get; set; }
        readonly int Quantum, tContexto, sleep;

        public Escalonador(int Quantum, int tContexto, int sleep)
        {
            Todoscesss = new Fila[10];

            for (int i = 0; i < Todoscesss.Length; i++)
                Todoscesss[i] = new Fila();

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
            while (!TodosVazia() && pos < Todoscesss.Length) // Enquanto todas as filas de processos não estiverem vazias
            {
                //Console.WriteLine("\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));

                while (!Todoscesss[pos].Vazio()) // Enquanto uma fila especifica não estiver vazia
                {
                    //Console.ForegroundColor = ConsoleColor.DarkYellow;
                    //Console.WriteLine("\nTroca de contexto...");
                    //Console.ForegroundColor = ConsoleColor.White;

                    Thread.Sleep(tContexto); // Simulando o tempo gasto pela troca de contexto

                    Processo processo = (Processo)(Todoscesss[pos].Retirar()); // Retira o processo em execução da fila de processos

                    //Console.WriteLine("Processando: " + processo.ToString());

                    if (CPUs(processo) > 0) // Se o retorno da CPU for maior que 0, o processo foi finalizado
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkGreen;
                        //Console.WriteLine("Processo Finalizado");
                        //Console.ForegroundColor = ConsoleColor.White;
                    }
                    else // O processo não terminou
                    {
                        AdicionarProcesso(processo); // Adiciona o processo em uma nova fila de prioridade (prioridade -1)
                        //Console.ForegroundColor = ConsoleColor.DarkRed;
                        //Console.WriteLine("Processo REBAIXADO para prioridade {0}", processo.Prioridade);
                        //Console.ForegroundColor = ConsoleColor.White;
                    }

                    //Console.WriteLine("\n\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));
                    //Console.WriteLine("\n" + Todos[pos].ToString());
                }
                pos++;
            }
        }

        /// <summary>
        /// Allocate the process to it's new priority queue
        /// </summary>
        /// <param name="p">The process to be alocated</param>
        public void AdicionarProcesso(Processo p)
        {
            switch (p.Prioridade)
            {
                case 1: Todoscesss[0].Inserir(p); break;
                case 2: Todoscesss[1].Inserir(p); break;
                case 3: Todoscesss[2].Inserir(p); break;
                case 4: Todoscesss[3].Inserir(p); break;
                case 5: Todoscesss[4].Inserir(p); break;
                case 6: Todoscesss[5].Inserir(p); break;
                case 7: Todoscesss[6].Inserir(p); break;
                case 8: Todoscesss[7].Inserir(p); break;
                case 9: Todoscesss[8].Inserir(p); break;
                case 10: Todoscesss[9].Inserir(p); break;
                default: break;
            }
        }

        /// <summary>
        /// Verify if all priority queues are empty
        /// </summary>
        /// <returns></returns>
        public bool TodosVazia()
        {
            return Todoscesss[0].Vazio() && Todoscesss[1].Vazio() && Todoscesss[2].Vazio() && Todoscesss[3].Vazio() && Todoscesss[4].Vazio() && Todoscesss[5].Vazio() && Todoscesss[6].Vazio() && Todoscesss[7].Vazio() && Todoscesss[8].Vazio() && Todoscesss[9].Vazio();
        }

        /// <summary>
        /// Ta de brincation wit me?
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder auxImpressao = new StringBuilder();

            for (int pos = 0; pos < Todoscesss.Length; pos++)
            {
                auxImpressao.AppendLine("\tPrioridade " + (pos + 1));
                auxImpressao.AppendLine(Todoscesss[pos].ToString());
            }

            return auxImpressao.ToString();
        }
    }
}
