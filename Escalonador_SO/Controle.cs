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

    }
}
