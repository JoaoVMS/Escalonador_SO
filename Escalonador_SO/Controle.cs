using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Escalonador_SO
{
    class Controle
    {
        public static int sleep = 300, trocaContexto = 200, quantum = 500;
        public static Escalonador Escalonador = new Escalonador(quantum, trocaContexto, sleep);

        readonly static string nomeArquivo = "processos.txt";

        /// <summary>
        /// Aloca o processo na fila de processos correta
        /// </summary>
        public static void LeituraArquivo()
        {
            if (!File.Exists(nomeArquivo))
            {
                //Exibir mensagem de erro "Arquivo não foi encontrado ou não existe."

                return;
            }

            string[] info;

            //Fazer a leitura do arquivo e organizar entre as 10 filas
            using (StreamReader entrada = new StreamReader(nomeArquivo))
            {
                while (!entrada.EndOfStream)
                {
                    info = entrada.ReadLine().Split(';');
                    try
                    {
                        if (info.Length == 4)
                        {
                            Processo processo = new Processo(Convert.ToInt32(info[0]), info[1], Convert.ToInt32(info[2]), Convert.ToInt32(info[3]));
                            Escalonador.AdicionarProcesso(processo);
                            this.AdicionarListView(processo); //Esse this é referente a quê? 
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
    }
}
