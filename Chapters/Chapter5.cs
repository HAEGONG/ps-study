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

class Chapter5_2 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 2178 미로 탐색";
    }
    
    int[] dx = {0, 0, 1, -1};
    int[] dy = {1, -1, 0, 0};

    protected override void Example()
    {
        int[] nm = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        int[,] map = new int[nm[0], nm[1]];

        for (int n = 0; n < nm[0]; n++)
        {
            string input = Console.ReadLine()!;

            for (int m = 0; m < input.Length; m++)
            {
                map[n, m] = input[m] - '0';
            }
        }
        
        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue((0, 0));
        while (queue.Count > 0)
        {
            var currrent = queue.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                int nx = currrent.x + dx[i];
                int ny = currrent.y + dy[i];
                
                if (nx < 0 || nx >= nm[0] || ny < 0 || ny >= nm[1])
                    continue;
                
                if (map[nx, ny] == 0)
                    continue;

                if (map[nx, ny] == 1)
                {
                    map[nx, ny] = map[currrent.x, currrent.y] + 1;
                    queue.Enqueue((nx, ny));
                }
            }
        }
        Console.WriteLine(map[nm[0] - 1, nm[1] - 1]);
    }
}

class Chapter13_1 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 18352 특정 거리의 도시 찾기";
    }

    protected override void Example()
    {
        int[] NMKX = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        List<int>[] road = new List<int>[NMKX[0] + 1];
        for (int i = 0; i < road.Length; i++)
        {
            road[i] = new List<int>();
        }

        for (int i = 0; i < NMKX[1]; i++)
        {
            int[] ab = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            road[ab[0]].Add(ab[1]);
        }

        int[] distance = Enumerable.Repeat(-1, NMKX[0] + 1).ToArray();
        distance[NMKX[3]] = 0;
            
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(NMKX[3]);
            
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            foreach (int next in road[current])
            {
                if (distance[next] == -1)
                {
                    distance[next] = distance[current] + 1;
                    queue.Enqueue(next);
                }
            }
        }

        bool canFind = false;
        for (int i = 0; i < distance.Length; i++)
        {
            if (distance[i] == NMKX[2])
            {
                canFind = true;
                Console.WriteLine(i);
            }
        }
        
        if (!canFind)
        {
            Console.WriteLine(-1);
        }
    }
}

class Chapter13_2 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 14502 연구소";
    }
    
    int[] dx = [1, 0, -1, 0];
    int[] dy = [0, 1, 0, -1];
    List<(int, int)> emptySpaces = new List<(int, int)>();
    List<(int, int)> virusSpaces = new List<(int, int)>();
    int[,] map;
    int[] NM;
    int result = 0;

    protected override void Example()
    {
        NM = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        
        map = new int[NM[0], NM[1]];
        
        for (int i = 0; i < NM[0]; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
            for (int j = 0; j < NM[1]; j++)
            {
                map[i, j] = input[j];
                
                if (map[i, j] == 0)
                    emptySpaces.Add((i, j));
                if (map[i, j] == 2)
                    virusSpaces.Add((i, j));
            }
        }
        
        BuildWalls(0, 0);
        Console.WriteLine(result);
    }

    void BuildWalls(int wallCount, int start)
    {
        if (wallCount == 3)
        {
            int[,] tempMap = new int[NM[0], NM[1]];
            for (int i = 0; i < NM[0]; i++)
            {
                for (int j = 0; j < NM[1]; j++)
                {
                    tempMap[i, j] = map[i, j];
                }
            }
            foreach (var (x, y) in virusSpaces)
            {
                SpreadVirus(x, y, tempMap);
            }
            
            result = Math.Max(result, CountSafeArea(tempMap));
            
            return;
        }

        for (int i = start; i < emptySpaces.Count; i++)
        {
            var (x, y) = emptySpaces[i];
            map[x, y] = 1;
            BuildWalls(wallCount + 1, i + 1);
            map[x, y] = 0;
        }
    }

    void SpreadVirus(int x, int y, int[,] tempMap)
    {
        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            
            if (nx < 0 || ny < 0 || nx >= NM[0] || ny >= NM[1])
                continue;

            if (tempMap[nx, ny] == 0)
            {
                tempMap[nx, ny] = 2;
                SpreadVirus(nx, ny, tempMap);
            }
        }
    }

    int CountSafeArea(int[,] tempMap)
    {
        int count = 0;
        for (int i = 0; i < tempMap.GetLength(0); i++)
        {
            for (int j = 0; j < tempMap.GetLength(1); j++)
            {
                if (tempMap[i, j] == 0)
                    count++;
            }
        }
        return count;
    }
}

class Chapter13_3 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 18405 경쟁적 전염";
    }

    int[] dx = { 1, 0, -1, 0 };
    int[] dy = { 0, 1, 0, -1 };

    class Virus
    {
        public int x;
        public int y;
        public int virusNum;
        public int second;

        public Virus((int x, int y) pos, int virusNum, int second)
        {
            this.x = pos.x;
            this.y = pos.y;
            this.virusNum = virusNum;
            this.second = second;
        }
    }

    protected override void Example()
    {
        int[] nm = Console.ReadLine()!.Split().Select(Int32.Parse).ToArray();
        int[,] map = new int[nm[0], nm[1]];
        var pq = new PriorityQueue<Virus, (int, int)>();

        for (int i = 0; i < nm[0]; i++)
        {
            int[] input = Console.ReadLine()!.Split().Select(Int32.Parse).ToArray();
            for (int j = 0; j < input.Length; j++)
            {
                map[i, j] = input[j];

                if (map[i, j] != 0)
                {
                    pq.Enqueue(new Virus((i, j), map[i, j], 0), (0, map[i, j]));
                }
            }
        }
        
        int[] SXY = Console.ReadLine()!.Split().Select(Int32.Parse).ToArray();

        int second = 0;
        while (pq.Count > 0)
        {
            if (second == SXY[0])
                break;
            
            var virus = pq.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nx = virus.x + dx[i];
                int ny = virus.y + dy[i];
                
                if (nx < 0 || ny < 0 || nx >= nm[0] || ny >= nm[1])
                    continue;

                if (map[nx, ny] == 0)
                {
                    map[nx, ny] = virus.virusNum;
                    pq.Enqueue(new Virus((nx, ny), virus.virusNum, virus.second + 1), (virus.second + 1, virus.virusNum));
                }
            }

            if (second <= virus.second)
                second++;
        }
        
        Console.WriteLine(map[SXY[1] - 1, SXY[2] - 1]);
    }
}

class Chapter13_5 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 14888 연산자 끼워 넣기";
    }

    private int N;
    private int[] numbers;
    private int[] operators;
    
    int resultMin = int.MaxValue;
    int resultMax = int.MinValue;

    protected override void Example()
    {
        N = int.Parse(Console.ReadLine()!);
        numbers = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        operators = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

        Solve(1, numbers[0]);
        
        Console.WriteLine(resultMax);
        Console.WriteLine(resultMin);
    }

    private void Solve(int numIndex, int currentResult)
    {
        if (numIndex == N)
        {
            resultMin = Math.Min(resultMin, currentResult);
            resultMax = Math.Max(resultMax, currentResult);
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            if (operators[i] > 0)
            {
                operators[i]--;

                switch (i)
                {
                    case 0:
                        Solve(numIndex + 1, currentResult + numbers[numIndex]);
                        break;
                    case 1:
                        Solve(numIndex + 1, currentResult - numbers[numIndex]);
                        break;
                    case 2:
                        Solve(numIndex + 1, currentResult * numbers[numIndex]);
                        break;
                    case 3:
                        Solve(numIndex + 1, currentResult / numbers[numIndex]);
                        break;
                }
                
                operators[i]++;
            }
        }
    }
}