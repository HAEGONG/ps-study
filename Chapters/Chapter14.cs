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