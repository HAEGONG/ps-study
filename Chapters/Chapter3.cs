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

        public override void Run()
        {
            base.Run();
            
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

        public override void Run()
        {
            base.Run();
            
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
        
        public override void Run()
        {
            base.Run();
            
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
}