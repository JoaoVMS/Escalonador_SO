using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Todas_as_Estruturas_de_Dados;
using System.Threading;

namespace Escalonador_SO
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Thread Adicional = new Thread(() => abrirJanelaInformacoes());
            Adicional.Name = "Thread Adicional";
            Adicional.SetApartmentState(ApartmentState.MTA);
            Adicional.Start();
        }

        private void abrirJanelaInformacoes()
        {
            Application.Run(new Form1()); //teste
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\nGustavo Ribeiro de Freitas Sena \nJoão Vitor Mendes Soares \nLorena Alves Aguilar \nNathan Ribeiro Ferreira Pinto");
        }
    }
}
