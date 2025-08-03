namespace ps_study.Chapters;

public class Chapter5_DFS : BaseClass
{
    protected override string SetTitle()
    {
        return "DFS";
    }

    void DFS(ref int[][] graph, int start, ref bool[] visited)
    {
        visited[start] = true;
        Console.Write(start + " ");
        foreach (int i in graph[start])
        {
            if (!visited[i])
                DFS(ref graph, i, ref visited);
        }
    }

    protected override void Example()
    {
        int[][] graph =
        [
            [],
            [2, 3, 8],
            [1, 7],
            [1, 4, 5],
            [3, 5],
            [3, 4],
            [7],
            [2, 6, 8],
            [1, 7]
        ];
        
        bool[] visited = new bool[graph.Length];
        DFS(ref graph, 1, ref visited);
    }
}

public class Chapter5_BFS : BaseClass
{
    protected override string SetTitle()
    {
        return "BFS";
    }

    void BFS(ref int[][] graph, int start, ref bool[] visited)
    {
        Queue<int> queue = new Queue<int>();
        
        queue.Enqueue(start);
        visited[start] = true;

        while (queue.Count > 0)
        {
            int v = queue.Dequeue();
            Console.Write(v + " ");

            foreach (int i in graph[v])
            {
                if (!visited[i])
                {
                    queue.Enqueue(i);
                    visited[i] = true;
                }
            }
        }
    }

    protected override void Example()
    {
        int[][] graph =
        [
            [],
            [2, 3, 8],
            [1, 7],
            [1, 4, 5],
            [3, 5],
            [3, 4],
            [7],
            [2, 6, 8],
            [1, 7]
        ];
        
        bool[] visited = new bool[graph.Length];
        
        BFS(ref graph, 1, ref visited);
    }
}

class Chapter5_1 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 1012 유기농 배추";
    }

    private int N, M;
    int[,] map = new int[50, 50];

    bool DFS(int x, int y)
    {
        if ( x < 0 || x >= N || y < 0 || y >= M )
            return false;

        if (map[x,y] == 1)
        {
            map[x,y] = 0;
            DFS(x - 1, y);
            DFS(x + 1, y);
            DFS(x, y - 1);
            DFS(x, y + 1);
            return true;
        }
        else
        {
            return false;
        }
    }

    protected override void Example()
    {
        int T = int.Parse(Console.ReadLine());
        
        while (T-- > 0)
        {
            int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            N = inputs[0];
            M = inputs[1];
            int K = inputs[2];

            

            while (K-- > 0)
            {
                int[] xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
                map[xy[0], xy[1]] = 1;
            }
            
            int result = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (DFS(i, j))
                        result++;
                }
            }
            
            Console.WriteLine(result);
        }
    }
}