using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCOLA
{
    [System.Serializable]
    internal class ALUNO : ESCOLA, IINTERFACE
    {
        public float NOTA;
        public float MEDIA;

        public ALUNO (string NOME, float NOTA, float MEDIA)
        {
            this.NOME = NOME;
            this.NOTA = NOTA;
            this.MEDIA = MEDIA;
        }

        public void EXIBIR()
        {

        }

        public void EXIBIR2()
        {
            Console.WriteLine($"NOME: {NOME}");
            Console.WriteLine($"NOTA: {NOTA}");
            Console.WriteLine($"MEDIA: {MEDIA}");
            Console.WriteLine("");
        }
    }
}       