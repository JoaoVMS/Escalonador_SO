using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Todas_as_Estruturas_de_Dados;
using System.Windows.Forms;

namespace Escalonador_SO
{
    class Controle
    {
        //Escalonador
        public static int sleep = 300, trocaContexto = 200, quantum = 500;
        public static Escalonador Escalonador = new Escalonador(quantum, trocaContexto, sleep);
        public static Fila FilaProcessosSuspensos = new Fila();

        //Arquivo onde tem todos os processos
        public readonly static string nomeArquivo = "processos.txt";

        //ListView
        public static ListView ListViewSuspensa;
        public static ListView[] ListViewsFilasProcesso = new ListView[10];

        /// <summary>
        /// Adiciona o processo ao listView Correto
        /// </summary>
        /// <param name="processo">Processo que será adicionado ao listView</param>
        public static void AdicionarListView(Processo processo)
        {
            ListViewItem aux = new ListViewItem(Convert.ToString(processo.PID));
            aux.SubItems.Add(processo.Nome);
            aux.SubItems.Add(Convert.ToString(processo.Prioridade));
            aux.SubItems.Add(Convert.ToString(processo.QtdeCiclos));

            ListViewsFilasProcesso[processo.Prioridade - 1].Items.Add(aux);
        }

        /// <summary>
        /// Retira o processo na fila de processos
        /// </summary>
        /// <param name="processo">Processo que será retirado</param>
        public static void RetirarListView(Processo processo)
        {
            ListViewsFilasProcesso[processo.Prioridade - 1].Items.Remove(ListViewsFilasProcesso[processo.Prioridade - 1].FindItemWithText(Convert.ToString(processo.PID)));
        }

        /// <summary>
        /// Insere o processo na listView com processos que foram suspensos
        /// </summary>
        /// <param name="processo">Processo que será enviado para a listView Suspesos</param>
        public static void InserirListViewSuspensa(Processo processo)
        {
            ListViewItem aux = new ListViewItem(Convert.ToString(processo.PID));
            aux.SubItems.Add(processo.Nome);
            aux.SubItems.Add(Convert.ToString(processo.Prioridade));
            aux.SubItems.Add(Convert.ToString(processo.QtdeCiclos));

            ListViewSuspensa.Items.Add(aux);
        }
    }
}
    