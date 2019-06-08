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
        public Form1()
        {
            InitializeComponent();
            InicializarListViews();
            LeituraArquivo();
        }

        /// <summary>	
        /// Aloca o processo na fila de processos correta	
        /// </summary>	
        public void LeituraArquivo()
        {	
            if (!File.Exists(Controle.nomeArquivo))	
            {	
                //Exibir mensagem de erro "Arquivo não foi encontrado ou não existe."	

                 return;	
            }	

             //Fazer a leitura do arquivo e organizar entre as 10 filas	
            using (StreamReader entrada = new StreamReader(Controle.nomeArquivo))	
            {	
                string[] info;	

                while (!entrada.EndOfStream)	
                {	
                    info = entrada.ReadLine().Split(';');	
                    try	
                    {	
                        if (info.Length == 4)	
                        {	
                            Processo processo = new Processo(Convert.ToInt32(info[0]), info[1], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]));	
                            Controle.Escalonador.AdicionarProcesso(processo);	
                            Controle.AdicionarListView(processo); //Esse this é referente a quê? 	
                        }	
                        else	
                        {	
                            //Exibir mensagem de erro "falta atributos"	

                         }	
                    }	
                    catch (Exception erro)	
                    {	
                        //Exibir mensagem de erro de conversão	

                     }	
                }	
            }	
        }	
        
        /// <summary>	
        /// A classe Controle recebe o ponteiro que aponta pras listViews
        /// </summary>	
        public void InicializarListViews()
        {
            //Da pra transformar aquele tanto de listViewers em um vetor, por causa da referência dos objetos ListView
            Controle.ListViewsFilasProcesso[0] = listViewFilaPrioridade1;
            Controle.ListViewsFilasProcesso[1] = listViewFilaPrioridade2;
            Controle.ListViewsFilasProcesso[2] = listViewFilaPrioridade3;
            Controle.ListViewsFilasProcesso[3] = listViewFilaPrioridade4;
            Controle.ListViewsFilasProcesso[4] = listViewFilaPrioridade5;
            Controle.ListViewsFilasProcesso[5] = listViewFilaPrioridade6;
            Controle.ListViewsFilasProcesso[6] = listViewFilaPrioridade7;
            Controle.ListViewsFilasProcesso[7] = listViewFilaPrioridade8;
            Controle.ListViewsFilasProcesso[8] = listViewFilaPrioridade9;
            Controle.ListViewsFilasProcesso[9] = listViewFilaPrioridade10;
            Controle.ListViewSuspensa = listViewFilaSuspesa;
        }

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
            LeituraArquivo();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CriarProcessoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criar novo forms para pegar os dados que a pessoa quiser para criar o novo processo
            //Pego esse processo, crio, e por meio da prioridade dele encaixo em sua respectiva fila de processos
        }
        #endregion
    }
}
