namespace ps_study.Chapters
{
    public class Chapter3_1 : BaseClass
    {
        protected override string SetTitle()
        {
            return "예제 3-1";
        }

        protected override bool ShouldRun()
        {
            return true;
        }

        protected override void Example()
        {
            int n = 1260;
            int count = 0;

            int[] list = [500, 100, 50, 10];

            foreach (int i in list)
            {
                count = count + n / i;
                n = n % i;
            }
                
            Console.WriteLine(count);
        }
    }

    public class Chapter3_2 : BaseClass
    {
        protected override string SetTitle()
        {
            return "예제 3-2";
        }
        
        protected override bool ShouldRun()
        {
            return false;
        }

        protected override void Example()
        {
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int n = int.Parse(numbers[0]);
            int m = int.Parse(numbers[1]);
            int k = int.Parse(numbers[2]);
            
            string input2 = Console.ReadLine();
            int[] numbers2 = input2.Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
                
            int first = numbers2[0];
            int second = numbers2[1];
            
            int result = 0;
            
            int addSecondNTimes = m / (k + 1);
            
            result = addSecondNTimes * second + (m - addSecondNTimes) * first;
                
            Console.WriteLine(result);
        }
    }

    class Chapter3_4 : BaseClass
    {
        protected override string SetTitle()
        {
            return "예제 3-4";
        }
        
        protected override bool ShouldRun()
        {
            return false;
        }

        protected override void Example()
        {
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');
            int n = int.Parse(numbers[0]);
            int k = int.Parse(numbers[1]);

            int count = 0;
                
            while (n != 1)
            {
                if (n % k == 0)
                {
                    n = n / k;
                    count++;
                }
                else
                {
                    n = n - 1;
                    count++;
                }
            }
                
            Console.WriteLine(count);
        }
    }
    
    class Chapter11_1 : BaseClass
    {
        protected override string SetTitle()
        {
            return "11-1 모험가 길드";
        }

        protected override bool ShouldRun()
        {
            return true;
        }

        protected override void Example()
        {
            string n = Console.ReadLine();
            string m = Console.ReadLine();
            int[] num = m.Split(' ').Select(int.Parse).Order().ToArray();

            int result = 0;
            int count = 0;

            for (int i = 0; i < num.Length; i++)
            {
                count++;
                if (count >= num[i])
                {
                    result++;
                    count = 0;
                }
            }
            
            Console.WriteLine(result);
        }
    }
    
    class Chapter11_2 : BaseClass
    {
        protected override string SetTitle()
        {
            return "11-2 곱하기 혹은 더하기";
        }
        
        protected override void Example()
        {
            string input = Console.ReadLine();

            int result = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                int n = int.Parse(input[i].ToString());
                if (result <= 1 || n <= 1)
                    result = result + n;
                else
                    result = result * n;
            }
            
            Console.WriteLine(result);
        }
    }

    class Chapter11_3 : BaseClass
    {
        protected override string SetTitle()
        {
            return "문자열 뒤집기 https://www.acmicpc.net/problem/1439";
        }

        protected override bool ShouldRun()
        {
            return true;
        }

        protected override void Example()
        {
            string input = Console.ReadLine();

            int count = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] != input[i + 1])
                    count++;
            }

            int result = (count + 1) / 2;
            Console.WriteLine(result);
        }
    }

    class Chapter11_4 : BaseClass
    {
        protected override string SetTitle()
        {
            return "11-4 만들 수 없는 금액";
        }

        protected override void Example()
        {
            int n = int.Parse(Console.ReadLine());
            int[] coins = Console.ReadLine().Split(' ').Select(int.Parse).Order().ToArray();

            int target = 1;

            foreach (int coin in coins)
            {
                if (coin > target)
                    break;
                target = target + coin;
            }
            
            Console.WriteLine(target);
        }
    }

    class Chapter11_5 : BaseClass
    {
        protected override string SetTitle()
        {
            return "11-5 볼링공 고르기";
        }

        protected override void Example()
        {
            string nm = Console.ReadLine();
            int n = int.Parse(nm.Split(' ')[0]);
            int m = int.Parse(nm.Split(' ')[1]);

            int[] balls = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] ballCountByWeight = new int[m + 1];

            foreach (int weight in balls)
            {
                ballCountByWeight[weight]++;
            }

            int result = 0;
            
            for (int i = 1; i <= m; i++)
            {
                n = n - ballCountByWeight[i];
                result = result + ballCountByWeight[i] * n;
            }
            
            Console.WriteLine(result);
        }
    }
}