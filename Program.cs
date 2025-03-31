using System;
using System.Collections.Generic;

class Livrolandia
{
    static List<int>[] grafoAdj;
    static bool[] visitadas;

    static void Main(string[] args)
    {

        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++)
        {

            string[] primeiraLinha = Console.ReadLine().Split();
            int N = int.Parse(primeiraLinha[0]);
            int M = int.Parse(primeiraLinha[1]);
            int B = int.Parse(primeiraLinha[2]);
            int E = int.Parse(primeiraLinha[3]);

            grafoAdj = new List<int>[N + 1];
            for (int i = 1; i <= N; i++)
            {
                grafoAdj[i] = new List<int>();
            }


            for (int i = 0; i < M; i++)
            {
                string[] estrada = Console.ReadLine().Split();
                int x = int.Parse(estrada[0]);
                int y = int.Parse(estrada[1]);
                grafoAdj[x].Add(y);
                grafoAdj[y].Add(x);
            }

            if (B <= E)
            {
                Console.WriteLine($"{((long)N * B)}");
                continue;
            }

            visitadas = new bool[N + 1];
            long custoTotal = 0;

            for (int i = 1; i <= N; i++)
            {
                if (!visitadas[i])
                {
                    int componentSize = BFS(i);
                    custoTotal += B + (long)(componentSize - 1) * E;
                }
            }

            Console.WriteLine($"{custoTotal}");
        }
    }
    static int BFS(int raiz)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(raiz);
        visitadas[raiz] = true;

        int comprimento = 0;

        while (queue.Count > 0)
        {
            int no = queue.Dequeue();
            comprimento++;

            foreach (int vizinho in grafoAdj[no])
            {
                if (!visitadas[vizinho])
                {
                    visitadas[vizinho] = true;
                    queue.Enqueue(vizinho);
                }
            }
        }

        return comprimento;
    }
}
