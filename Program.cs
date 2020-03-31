using System;

namespace EstruturaObjetosComplexos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Nome aluno | trabalho 1 | AV1 | trabalho 2 | AV2 | Média Aluno | Aprovado (Sim|Não)
            //

            //notaAluno1 -> variavel
            //NotaAluno -> Tipo da variavel, classe
            var notaAluno1 = new NotaAluno();
            notaAluno1.Nome = "Pedro";
            notaAluno1.Trabalho1 = 8;
            notaAluno1.Avaliacao1 = 6.5F;
            notaAluno1.Trabalho2 = 9;
            notaAluno1.Avaliacao2 = 7;


            var cabecalho = new Cabecalho();
            cabecalho.Colunas = new Coluna[7];

            cabecalho.Colunas[0] = new Coluna("Nome aluno");
            cabecalho.Colunas[1] = new Coluna("Trabalho 1");
            cabecalho.Colunas[2] = new Coluna("AV1");
            cabecalho.Colunas[3] = new Coluna("Trabalho 2");
            cabecalho.Colunas[4] = new Coluna("AV2");
            cabecalho.Colunas[5] = new Coluna("Média Aluno");
            cabecalho.Colunas[6] = new Coluna("Aprovado (Sim|Não)\n");

            cabecalho.ImprimirLinha(cabecalho.Colunas);


            var linha = new Linha();
            linha.Colunas = new Coluna[7];
            linha.Colunas[0] = new Coluna(notaAluno1.Nome,                               cabecalho.Colunas[0].QteLetras);
            linha.Colunas[1] = new Coluna(notaAluno1.Trabalho1.ToString(),               cabecalho.Colunas[1].QteLetras);
            linha.Colunas[2] = new Coluna(notaAluno1.Avaliacao1.ToString(),              cabecalho.Colunas[2].QteLetras);
            linha.Colunas[3] = new Coluna(notaAluno1.Trabalho2.ToString(),               cabecalho.Colunas[3].QteLetras);
            linha.Colunas[4] = new Coluna(notaAluno1.Avaliacao2.ToString(),              cabecalho.Colunas[4].QteLetras);
            linha.Colunas[5] = new Coluna(notaAluno1.CalcularMedia().ToString(),         cabecalho.Colunas[5].QteLetras);
            linha.Colunas[6] = new Coluna(notaAluno1.VerificarAprovacao().ToString(),    cabecalho.Colunas[6].QteLetras);

            linha.ImprimirLinha(linha.Colunas);


            //Console.WriteLine("Nome aluno | trabalho 1 | AV1 | trabalho 2 | AV2 | Média Aluno | Aprovado (Sim|Não)");
            //Console.WriteLine($"{notaAluno1.Nome} | {notaAluno1.Trabalho1} | {notaAluno1.Avaliacao1} | { notaAluno1.Trabalho2} | {notaAluno1.Avaliacao2} | {notaAluno1.CalcularMedia()} | {notaAluno1.VerificarAprovacao() }");





            //IF/ELSE
            //if (notaAluno1.VerificarAprovacao())
            //    Console.WriteLine("Sim");
            //else
            //    Console.WriteLine("Não");

            Console.ReadKey();
        }
    }

    class NotaAluno
    {
        public string Nome;
        public float Trabalho1;
        public float Avaliacao1;
        public float Trabalho2;
        public float Avaliacao2;

        //Trabalhos - 40%;
        //Avaliação - 60%
        public float CalcularMedia()
        {
            var media = (Trabalho1 + Trabalho2 + Avaliacao1 + Avaliacao2) / 4;

            return media;
        }

        public bool VerificarAprovacao()
        {
            var media = CalcularMedia();

            if (media >= 7)
                return true;
            else
                return false;

            //return media >= 7;
        }

        //>7
    }

    public class Coluna
    {
        //Método construtor não tem retorno e possui o mesmo nome da classe
        public Coluna(string conteudo)
        {
            Conteudo = conteudo;
        }

        public Coluna(string conteudo, int qtdeParaCompletar)
        {
            Conteudo = conteudo.PadRight(qtdeParaCompletar, ' ');          
        }

        public string Conteudo;
        public int QteLetras => Conteudo.Length;

    }

    public class Cabecalho : Tabela
    {
        public Coluna[] Colunas;
    }

    public class Linha : Tabela
    {
        public Coluna[] Colunas;
    }

    public class Tabela
    {
        public void ImprimirLinha(Coluna[] Colunas)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Write(Colunas[i].Conteudo);

                if (i < 6)
                {
                    Console.Write(" | ");
                }

            }
        }
    }


}
