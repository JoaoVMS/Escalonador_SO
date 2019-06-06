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

namespace Escalonador_SO
{
    public partial class Form1 : Form
    {
        Escalonador Escalonador { get; set; }

        public Form1()
        {
            InitializeComponent();
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

        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("O processo será perdido, tem certeza que deseja fechar o escalonador?", "Sair", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
    }
}
