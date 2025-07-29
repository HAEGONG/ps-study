namespace ps_study.Chapters
{
    class Chapter4_1 : BaseClass
    {
        protected override string SetTitle()
        {
            return "4-1 상하좌우";
        }

        private void Move(char direction, ref (int x, int y) pos)
        {
            int newX = pos.x;
            int newY = pos.y;

            if (direction == 'U')
                newX--;
            else if (direction == 'D')
                newX++;
            else if (direction == 'L')
                newY--;
            else if (direction == 'R')
                newY++;
            
            if (newX >= 1 && newX <= n && newY >= 1 && newY <= n)
                pos = (newX, newY);
        }

        private int n;
        protected override void Example()
        {
            n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine().Replace(" ", "");

            (int x, int y) pos = (1, 1);

            foreach (char c in command)
            {
                Move(c, ref pos);
            }
            
            Console.WriteLine($"{pos.x} {pos.y}");
        }
    }
    
    class Chapter4_2 : BaseClass
    {
        protected override string SetTitle()
        {
            return "4-2 시각";
        }

        protected override void Example()
        {
            int N = int.Parse(Console.ReadLine());

            int count = 0;
            
            for (int i = 0; i <= N; i++)
            {
                string hour = i.ToString();
                if (hour.Contains('3'))
                {
                    count = count + 3600;
                    continue;
                }
                for (int j = 0; j < 60; j++)
                {
                    string min = j.ToString();
                    if (min.Contains('3'))
                    {
                        count = count + 60;
                        continue;
                    }
                    for (int k = 0; k < 60; k++)
                    {
                        string sec = k.ToString();
                        if (sec.Contains('3'))
                        {
                            count++;
                        }
                    }
                }
            }
            
            Console.WriteLine(count);
        }
    }
    
    class Chapter4_3 : BaseClass
    {
        protected override string SetTitle()
        {
            return "4-3 왕실의 나이트";
        }
        
        (int x, int y)[] steps = new []{(-2, 1), (-2,1), (2, 1), (2, -1), (1, -2), (1, 2), (-1, 2), (-1, -2)};

        protected override void Example()
        {
            string input = Console.ReadLine();

            int n = input[0] - 'a' + 1;
            int m = int.Parse(input.Substring(1));
            (int x, int y) pos = (n, m);
            
            int count = 0;
            
            foreach (var step in steps)
            {
                (int x, int y) newPos = (pos.x + step.x, pos.y + step.y);

                if (newPos.x >= 1 && newPos.x <= 8 && newPos.y >= 1 && newPos.y <= 8)
                {
                    count++;
                }
            }
            
            Console.WriteLine(count);
        }
    }
    
    class Chapter12_1 : BaseClass
    {
        protected override string SetTitle()
        {
            return "12-1 럭키 스트레이트";
        }

        protected override void Example()
        {
            string input = Console.ReadLine();

            int left = 0; 
            int right = 0;

            for (int i = 0; i < input.Length / 2; i++)
            {
                left = left + (input[i] - '0');
            }

            for (int i = input.Length / 2; i < input.Length; i++)
            {
                right = right + (input[i] - '0');
            }

            if (left == right)
                Console.WriteLine("LUCKY");
            else
                Console.WriteLine("READY");
        }
    }
    
    class Chapter12_2 : BaseClass
    {
        protected override string SetTitle()
        {
            return "12-2 문자열 재정렬";
        }

        protected override void Example()
        {
            string input = Console.ReadLine();

            string strPart = string.Concat(input.Where(c => Char.IsLetter(c)).Order());
            int numPart = input.Where(c => Char.IsDigit(c)).Sum(c => c - '0');
            Console.WriteLine(strPart + numPart);
        }
    }
    
    class Chapter12_5 : BaseClass
    {
        protected override string SetTitle()
        {
            return "12-5 뱀";
        }

        enum Status
        {
            empty,
            apple,
        }

        // 동 남 서 북
        int[] dx = {0, 1, 0, -1};
        int[] dy = {1, 0, -1, 0};
        private int dir = 0;
        private void Turn(char C)
        {
            if (C == 'L')
            {
                dir--;
            } else if (C == 'D')
            {
                dir++;
            }

            if (dir < 0)
                dir = 3;
            else if (dir > 3)
                dir = 0;
        }

        protected override void Example()
        {
            int N = int.Parse(Console.ReadLine());
            Status[,] board = new Status[N + 1, N + 1];
            
            int K = int.Parse(Console.ReadLine());

            for (int i = 0; i < K; i++)
            {
                string input = Console.ReadLine();
                int[] xy = input.Split(' ').Select(int.Parse).ToArray();
                int x = xy[0];
                int y = xy[1];
                board[x, y] = Status.apple;
            }
            
            int L = int.Parse(Console.ReadLine());

            (int X, char C)[] commands = new (int X, char C)[L];

            for (int i = 0; i < L; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                commands[i] = (int.Parse(input[0]), input[1][0]);
            }

            (int x, int y) currentPos = (1, 1);

            int countSec = 0;
            int countCommand = 0;
            Queue<(int x, int y)> snake = new Queue<(int x, int y)>();
            snake.Enqueue((1, 1));
            
            while (true)
            {
                (int x, int y) newPos = (currentPos.x + dx[dir], currentPos.y + dy[dir]);

                if (newPos.x < 1 || newPos.x > N || newPos.y < 1 || newPos.y > N || snake.Contains(newPos))
                {
                    countSec++;
                    break;
                }

                if (board[newPos.x, newPos.y] == Status.apple)
                {
                    board[newPos.x, newPos.y] = Status.empty;
                    snake.Enqueue(newPos);
                    currentPos = newPos;
                } else if (board[newPos.x, newPos.y] == Status.empty)
                {
                    snake.Dequeue();
                    snake.Enqueue(newPos);
                    currentPos = newPos;
                }

                countSec++;

                if (countCommand < L && commands[countCommand].X == countSec)
                {
                    Turn(commands[countCommand].C);
                    countCommand++;
                }
            }
            
            Console.WriteLine(countSec);
        }
    }
}