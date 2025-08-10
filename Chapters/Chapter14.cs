using System.Text;

namespace ps_study.Chapters;

public class Chapter14_1 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 10825 국영수";
    }

    protected override void Example()
    {
        int N = int.Parse(Console.ReadLine()!);

        List<Student> list = new List<Student>();
        
        for (int i = 0; i < N; i++)
        {
            var input = Console.ReadLine()!.Split();
            var student = new Student(input[0], int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]));
            list.Add(student);
        }

        var result = list.OrderByDescending(s => s.Korean)
            .ThenBy(s => s.English)
            .ThenByDescending(s => s.Math)
            .ThenBy(s => s.Name);

        StringBuilder sb = new StringBuilder();
        
        foreach (var student in result)
        {
            sb.AppendLine(student.Name);
        }
        
        Console.WriteLine(sb.ToString());
    }

    class Student
    {
        public string Name { get; set; }
        public int Korean { get; set; }
        public int English { get; set; }
        public int Math { get; set; }

        public Student(string name, int korean, int english, int math)
        {
            Name = name;
            Korean = korean;
            English = english;
            Math = math;
        }
    }
}

class Chapter14_2 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 18310 안테나";
    }

    protected override void Example()
    {
        int N = int.Parse(Console.ReadLine()!);
        var list = Console.ReadLine()!.Split().Select(int.Parse).ToList();
        var sortedList = list.OrderBy(t => t).ToList();
        Console.WriteLine(sortedList[(N - 1)/ 2]);
    }
}

class Chapter14_4 : BaseClass
{
    protected override string SetTitle()
    {
        return "백준 1715 카드 정렬하기";
    }

    protected override void Example()
    {
        int N = int.Parse(Console.ReadLine()!);

        int result = 0;

        PriorityQueue<int, int> queue = new PriorityQueue<int, int>(); 
        for (int i = 0; i < N; i++)
        {
            int n = Convert.ToInt32(Console.ReadLine()!);
            queue.Enqueue(n, n);
        }

        while (queue.Count > 1)
        {
            int a = queue.Dequeue();
            int b = queue.Dequeue();
            result = result + a + b;
            queue.Enqueue(a + b, a + b);
        }


        Console.WriteLine(result);
    }
}