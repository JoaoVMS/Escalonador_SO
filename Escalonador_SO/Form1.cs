using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todas_as_Estruturas_de_Dados;


namespace Escalonador_SO
{
    public partial class Form1 : Form
    {
        Escalonador Escalonador { get; set; }

        public Form1()
        {
            InitializeComponent();
            //Da pra transformar aquele tanto de listViewers em um vetor, por causa da referência dos objetos ListView
            ListView[] listViews = { listViewFilaPrioridade1 , listViewFilaPrioridade2, listViewFilaPrioridade3, listViewFilaPrioridade4, listViewFilaPrioridade4, listViewFilaPrioridade6, listViewFilaPrioridade7, listViewFilaPrioridade8, listViewFilaPrioridade9, listViewFilaPrioridade10};
        }

        #region Métodos Auxiliares
        /// <summary>
        /// Adiciona o processo ao listView Correto
        /// </summary>
        /// <param name="processo">Processo que será adicionado ao listView</param>
        private void AdicionarListView(Processo processo)
        {
            
            ListViewItem aux = new ListViewItem(Convert.ToString(processo.PID));
            aux.SubItems.Add(processo.Nome);
            aux.SubItems.Add(Convert.ToString(processo.Prioridade));
            aux.SubItems.Add(Convert.ToString(processo.QtdeCiclos));

            switch (processo.Prioridade)
            {
                case 1: listViewFilaPrioridade1.Items.Add(aux); break;
                case 2: listViewFilaPrioridade2.Items.Add(aux); break;
                case 3: listViewFilaPrioridade3.Items.Add(aux); break;
                case 4: listViewFilaPrioridade4.Items.Add(aux); break;
                case 5: listViewFilaPrioridade5.Items.Add(aux); break;
                case 6: listViewFilaPrioridade6.Items.Add(aux); break;
                case 7: listViewFilaPrioridade7.Items.Add(aux); break;
                case 8: listViewFilaPrioridade8.Items.Add(aux); break;
                case 9: listViewFilaPrioridade9.Items.Add(aux); break;
                case 10: listViewFilaPrioridade10.Items.Add(aux); break;
                default: break;
            }
        }


        /// <summary>
        /// Retira o processo na fila de processos
        /// </summary>
        /// <param name="processo">Processo que será retirado</param>
        //public void RetirarListView(Processo processo)
        //{
        //    switch (processo.Prioridade)
        //    {
        //        case 1: listViewFilaPrioridade1.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 2: listViewFilaPrioridade2.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 3: listViewFilaPrioridade3.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 4: listViewFilaPrioridade4.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 5: listViewFilaPrioridade5.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 6: listViewFilaPrioridade6.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 7: listViewFilaPrioridade7.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 8: listViewFilaPrioridade8.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 9: listViewFilaPrioridade9.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        case 10: listViewFilaPrioridade10.Items.RemoveByKey(Convert.ToString(processo.PID)); break;
        //        default: Console.WriteLine("Erro: "); break;
        //    }
        //}
        #endregion

        #region Botões
        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("O processo será perdido, tem certeza que deseja fechar o escalonador?", "Sair", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
        private void LeituraDoArquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ler arquivo e colocar no escalonador
            //Colocar na listview também
            string nomeArquivo = "processos.txt";
            Escalonador = new Escalonador(10, 1, 10);

            if (!File.Exists(nomeArquivo))
                return;

            string[] info;

            //Fazer a leitura do arquivo e organizar entre as 10 listas Circulares
            using (StreamReader entrada = new StreamReader(nomeArquivo))
            {
                while (!entrada.EndOfStream)
                {
                    info = entrada.ReadLine().Split(';');
                    Processo processo = new Processo(Convert.ToInt32(info[0]), info[1], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]));
                    Escalonador.AdicionarProcesso(processo);
                    this.AdicionarListView(processo);
                }
            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CriarProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criar novo forms para pegar os dados que a pessoa quiser para criar o novo processo
            //Pego esse processo, crio, e por meio da prioridade dele encaixo em sua respectiva fila de processos
        }
    }
}
