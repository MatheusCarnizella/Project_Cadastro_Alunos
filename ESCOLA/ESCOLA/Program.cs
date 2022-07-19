using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ESCOLA
{
    internal class Program
    {
        static List<IINTERFACE> escolas = new List<IINTERFACE>();
        enum MENU { TURMAS = 1, CADASTAR, EXCLUIR, ALUNOS, SAIR }
        static void Main(string[] args)
        {
            LOADING();
            bool fechar = false;
            while (fechar == false)
            {
                Console.WriteLine(" BEM-VINDO AO A LISTAGEM DE TURMAS E ALUNOS.");
                Console.WriteLine(" SELECIONE O NUMERO CORRESPONDENDE AO QUE DESEJA:");
                Console.WriteLine("");
                Console.WriteLine(" OPCOES:\n 1 - LISTA DE TURMAS.\n 2 - CADASTRAR TURMA.\n 3 - EXCLUIR TURMA.\n 4 - MENU DE ALUNOS\n 5 - FECHAR E SALVAR.");
                Console.WriteLine("");

                string escola1 = Console.ReadLine();
                int escola2 = int.Parse(escola1);

                MENU menu = (MENU)escola2;

                switch (menu)
                {
                    case MENU.TURMAS:
                        TURMAS();
                        break;
                    case MENU.CADASTAR:
                        CADASTAR();
                        break;
                    case MENU.EXCLUIR:
                        EXCLUIR();
                        break;
                    case MENU.ALUNOS:
                        ALUNOS();
                        break;
                    case MENU.SAIR:
                        fechar = true;
                        break;
                }
                Console.Clear();
            }
        }
        static void TURMAS()
        {
            Console.WriteLine("LISTA DE TURMAS: ");
            Console.WriteLine("");
            int i = 0;
            foreach (IINTERFACE escola in escolas)
            {
                Console.WriteLine("ID: " + i);
                escola.EXIBIR();
                i++;
            }
            Console.ReadLine();
            
        }

        static void CADASTAR()
        {
            Console.WriteLine(" CADASTRE UMA TURMA AQUI: ");
            Console.WriteLine("");
            Console.WriteLine(" DIGITE O ANO POR EXTENSO DA TURMA:");
            Console.WriteLine(" Exemplo: Primero Ano A, Segundo ano B, Primeiro Ano B [...]");
            Console.WriteLine("");
            string TURMA = Console.ReadLine();
            TURMA turm = new TURMA(TURMA);
            escolas.Add(turm);
            SAVE();
        }
        static void EXCLUIR()
        {
            TURMAS();
            Console.WriteLine(" DIGITE O ID DA TURMA A SER EXCLUIDO: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < escolas.Count)
            {
                escolas.RemoveAt(id);
                SAVE();
            }
        }
        enum MENUALUNOS {TURM = 1, ADDALUNO, REMOVALUNO}
        static void ALUNOS()
        {
            Console.WriteLine(" MENU DE ALUNOS");            
            Console.WriteLine(" SELECIONE O NUMERO CORRESPONDENDE AO QUE DESEJA:");
            Console.WriteLine("");
            Console.WriteLine(" OPCOES:\n 1 - ALUNOS DISPONIVEIS\n 2 - ADICIONAR ALUNO \n 3 - REMOVER ALUNO");
            string escola3 = Console.ReadLine();
            int escola4 = int.Parse(escola3);
            MENUALUNOS menualunos = (MENUALUNOS)escola4;

            switch (menualunos)
            {
                case MENUALUNOS.TURM:
                    ALISTA();
                    break;
                case MENUALUNOS.ADDALUNO:
                    AALUNO();
                    break;
                case MENUALUNOS.REMOVALUNO:                    
                    break;
            }
        }
        static void ALISTA()
        {
            Console.WriteLine("ALUNOS REGISTRADOS");
            Console.WriteLine("");
            int a = 0;
            foreach (IINTERFACE alun in escolas)
            {
                Console.WriteLine("ID: " + a);
                alun.EXIBIR2();
                a++;
            }
            Console.ReadLine();

        }

        static void AALUNO()
        {
            Console.WriteLine(" CADASTRE UM ALUNO AQUI: ");
            Console.WriteLine(" DIGITE O NOME:");
            string nome = Console.ReadLine();
            Console.WriteLine(" DIGITE AS NOTAS (UTILIZE VIRGULA PARA SEPARA-LAS):");
            float nota = float.Parse(Console.ReadLine());
            Console.WriteLine(" DIGITE A MEDIA DO ALUNO:");
            float media = float.Parse(Console.ReadLine());

            ALUNO alun = new ALUNO(nome, nota, media);
            escolas.Add(alun);
            SAVE();
        }
                     
        static void SAVE()
        {
            FileStream fileStream = new FileStream("escola.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fileStream, escolas);
            fileStream.Close();


        }
        static void LOADING()
        {
            FileStream fileStream = new FileStream("escola.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                escolas = (List<IINTERFACE>)formatter.Deserialize(fileStream);

                if (escolas == null)
                {
                    escolas = new List<IINTERFACE>();
                }
            }
            catch (Exception ex)
            {
                escolas = new List<IINTERFACE>();
            }
            fileStream.Close();
        }

    }
}