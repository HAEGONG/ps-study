## switch문 활용
```C#
class Program
{
    enum Day : byte
    {
        Monday,
        Tuesday,
        Wednesday,
    }
    
    static void Main(string[] args)
    {
        Day day = Day.Monday;

        string msg = day switch
        {
            Day.Monday => "월요일",
            Day.Tuesday => "화요일",
            _ => "토요일" // default
        };
    }
}
```

## 대소문자 상관없이 문자열 비교
```C#
string text = "Hello World!";
text.Equals("world", StringComparison.OrdinalIgnoreCase);
```
