using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOLA
{
    [System.Serializable]
    internal class TURMA : ESCOLA, IINTERFACE
    {
        public string TURMAS;

        public TURMA (string TURMAS)
        {
            this.TURMAS = TURMAS;
        }

        public void EXIBIR2()
        {

        }

        void IINTERFACE.EXIBIR()
        {
            Console.WriteLine($"TURMA: {TURMAS}");
            Console.WriteLine("");
        }
    }
}
