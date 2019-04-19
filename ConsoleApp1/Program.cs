using System;
using System.IO;
namespace Tool
{
    public class StampClass
    {
        public string usin;
        public string TipoQuadro;
        public string comment;
        public string summary;
        public string pubInt;
        public string getSet;
        public string nomeQuadro;
        public int numRiga;
        public int numColonna;
        public string campo;
        public int[] vecR; //vec di righe
        public int[] vecC; //vec contendo il numero di colonne per righe
        public int num; //numero di di righe
        public string[] IndiceRepeater = new string[10] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };
        public string rep1;
        public int maxRep;
        public string rep2;
        public string pubNum;

        StampClass() { }

        public void StampaQ()//stampa il summary et il campo
        {
            pubNum = "number;";

            Console.Write("\t"+ campo + ": ");
            Console.WriteLine(pubNum);                        
        }

        public void StampapCampiQ(int i, int j)//stampa piu campi rispetto al numero della  riga e dell numero di colonne per la riga
        {
            numRiga = i;
            numColonna = j;
            Campi();
            StampaQ();
        }

        public void StampaClasseQuadroQ()
        {
            int[] vecR = new int[num];
            int[] vecC = new int[num];

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Inserire il numero della riga rispetto al quadro\n");
                vecR[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Per la riga " + vecR[i] + " quante colonne vuole?\n");
                vecC[i] = Convert.ToInt32(Console.ReadLine());
            }       
            for (int i = 0; i < num; i++)
            {
                for (int j = 1; j <= vecC[i]; j++)
                {
                    StampapCampiQ(vecR[i], j);
                }
            }                        
        }

        public void StampaC()//stampa il summary et il campo
        {
            pubNum = "//";

            Console.Write(pubNum + campo + "\n");            
        }

        public void StampapCampiC(int i, int j)//stampa piu campi rispetto al numero della  riga e dell numero di colonne per la riga
        {
            numRiga = i;
            numColonna = j;
            Campi();
            StampaC();
        }

        public void StampaClasseQuadroC()
        {
            int[] vecR = new int[num];
            int[] vecC = new int[num];

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Inserire il numero della riga rispetto al quadro\n");
                vecR[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Per la riga " + vecR[i] + " quante colonne vuole?\n");
                vecC[i] = Convert.ToInt32(Console.ReadLine());
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = 1; j <= vecC[i]; j++)
                {
                    StampapCampiC(vecR[i], j);
                }
            }
        }

        public void Stampa()//stampa il summary et il campo
        {
            comment = "///";
            summary = "summary";
            pubInt = "public int";
            getSet = "{ get; set; }";

            Console.WriteLine("\t" + comment + " <" + summary + ">");
            Console.WriteLine("\t" + comment + " ");
            Console.WriteLine("\t" + comment + " </" + summary + ">");
            Console.Write("\t" + pubInt);
            Console.Write(" " + campo + " ");
            Console.WriteLine(" " + getSet + "\n");
        }

        public void RepeaterUp()//stampa la parte di dichiarazione del repeater
        {
            for (int i = 0; i < maxRep; i++)
            {
                Console.WriteLine("\t\t\tthis.Righe_" + IndiceRepeater[i] + " = new List<Quadro" + nomeQuadro + "_" + IndiceRepeater[i] + ">();");
            }

            Console.WriteLine("\n\t\t}\n");

            for (int i = 0; i < maxRep; i++)
            {
                Console.WriteLine("\tpublic List<Quadro" + nomeQuadro + "_" + IndiceRepeater[i] + "> Righe_" + IndiceRepeater[i] + " { get; set; }");
            }
        }

        public void RepeaterDown()//stampa la sotto classe del repeater
        {
            for (int i = 0; i < maxRep; i++)
            {
                Console.WriteLine("\tpublic class Quadro" + nomeQuadro + "_" + IndiceRepeater[i] + "\n\t{ }");
            }
        }

        public string Campi()//restitiusce il nome del campo 
        {
            if ((numRiga >= 0 && numRiga <= 9))
            {
                if (numColonna >= 0 && numColonna <= 9)
                {
                    campo = nomeQuadro + "00" + numRiga + "00" + numColonna;
                }

                if (numColonna >= 10 && numColonna <= 99)
                {
                    campo = nomeQuadro + "00" + numRiga + "0" + numColonna;
                }

                if (numColonna >= 100 && numColonna <= 999)
                {
                    campo = nomeQuadro + "00" + numRiga + numColonna;
                }
            }

            if ((numRiga >= 10 && numRiga <= 99))
            {
                if (numColonna >= 0 && numColonna <= 9)
                {
                    campo = nomeQuadro + "0" + numRiga + "00" + numColonna;
                }

                if (numColonna >= 10 && numColonna <= 99)
                {
                    campo = nomeQuadro + "0" + numRiga + "0" + numColonna;
                }

                if (numColonna >= 100 && numColonna <= 999)
                {
                    campo = nomeQuadro + "0" + numRiga + numColonna;
                }
            }

            if ((numRiga >= 100 && numRiga <= 999))
            {
                if (numColonna >= 0 && numColonna <= 9)
                {
                    campo = nomeQuadro + numRiga + "00" + numColonna;
                }

                if (numColonna >= 10 && numColonna <= 99)
                {
                    campo = nomeQuadro + numRiga + "0" + numColonna;
                }

                if (numColonna >= 100 && numColonna <= 999)
                {
                    campo = nomeQuadro + numRiga + numColonna;
                }
            }
            return campo;
        }

        public void StampapCampi(int i, int j)//stampa piu campi rispetto al numero della  riga e dell numero di colonne per la riga
        {
            numRiga = i;
            numColonna = j;
            Campi();
            Stampa();
        }

        public void StampaClasseQuadro()
        {
            int[] vecR = new int[num];
            int[] vecC = new int[num];
            usin = "using System;\nusing System.Collections.Generic;\n\nnamespace BackOffice.Models.Quadri." + TipoQuadro +
                   "\n{\n\tpublic class Quadro" + nomeQuadro + " : AbstractQuadro\n\t{\n\t\tpublic Quadro" + nomeQuadro +
                   "()\n\t\t{\n\t\t\tthis.TipoQuadro = TipoQuadro." + nomeQuadro + ";";

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Inserire il numero della riga rispetto al quadro\n");
                vecR[i] = Convert.ToInt32(Console.ReadLine());
            }

            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Per la riga " + vecR[i] + " quante colonne vuole?\n");
                vecC[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine(usin);
            RepeaterUp();
            if (maxRep == 0)
            {
                Console.WriteLine("\n\t\t}\n");
            }

            for (int i = 0; i < num; i++)
            {
                for (int j = 1; j <= vecC[i]; j++)
                {
                    StampapCampi(vecR[i], j);
                }
            }
            RepeaterDown();
            Console.WriteLine("\n\t}\n}");
            Console.WriteLine();
        }
      
        static void Main(string[] args)
        {
            StampClass a = new StampClass();

            Console.WriteLine("Inserire nomeQuadro\n");
            a.nomeQuadro = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Inserire TipoQuadro\n");
            a.TipoQuadro = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Inserire numero totale di Righe nel quadro\n");
            a.num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Inserire numero totale di RepeaterUp\n");
            a.maxRep = Convert.ToInt32(Console.ReadLine());

            //a.StampaClasseQuadro(); //{}

            a.StampaClasseQuadroQ(); //Riga : number;

            //a.StampaClasseQuadroC();// --> //NF001001

            //for(int i = 0; i <366; i++)
            //{
            //    Console.WriteLine(i+",");
            //}

            Console.ReadLine();
        }
    }
}