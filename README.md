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
string text = "WORLD";
text.Equals("world", StringComparison.OrdinalIgnoreCase);
```

## Trim 문자열 제거
```C#
string withSpaces = "  Hello  ";
string trimmed = withSpaces.Trim(); // "Hello"

string withChars = "---Hello---";
string trimmed2 = withChars.Trim('-'); // "Hello"

string withLeadingSpaces = "  Hello  ";
string trimmed3 = withLeadingSpaces.TrimStart(); // "Hello  "

string withTrailingSpaces = "  Hello  ";
string trimmed4 = withTrailingSpaces.TrimEnd(); // "  Hello"

string mixedChars = "-*_Hello_*_";
string trimmed5 = mixedChars.Trim('*', '-', '_'); // "Hello"
string trimmed6 = mixedChars.TrimStart('-', '*', '_'); // "Hello_*_"
string trimmed7 = mixedChars.TrimEnd('-', '*', '_'); // "-*_Hello"
```

## 문자열 결합
```C#
string[] colors = ["Red", "Green", "Blue"];
string joined = string.Join(", ", colors); // Red, Green, Blue
```

## 문자열 가변
값을 변경할 때 마다 새로 생성되지 않고 추가되기 때문에 여러 문자열 조각이 필요한 경우 효율적
```C#
StringBuilder sb = new StringBuilder();
sb.Append("Hello");
sb.Append(" ");
sb.Append("World");
string msg = sb.ToString();
```

## out 키워드
```C#
string text = "a";
bool success = int.TryParse(text, out int result);
```

## 속성 Property
```C#
public class Person
{
    private string name;

    public string Name
    {
        get => name;
        set => name = value; // value는 약속된 키워드
    }
}
```
```C#
public class Person
{
    public Person(string name)
    {
        Name = name;
    }
    
    private string name;

    public string Name
    {
        get => name;
        init => name = value; // 생성자에서만 접근 가능해짐
    }
}
```

## readonly
선언할 때 값을 초기화하거나, 생성자에서 값 할당
```C#
class Person
{
    readonly string name = "ㅇㅇㅇ";

    public Person()
    {
        name = "AAA";
    }
}
```

## Extension Method
* static class일 것
* static method일 것
* 첫번째 매개변수에 this 키워드
```C#
string name = "AAA";
name.Print("BB");

static class MyClass
{
    public static void Print(this string str, string extraStr)
    {
        Console.WriteLine(str + " " + extraStr);
    }
}
```

## new 키워드
new 키워드를 사용하면 업캐스팅시 부모 함수가 호출됨
```C#
Animal dog = new Dog();
dog.Bark(); // 짖다!

class Animal
{
    public virtual void Bark()
    {
        Console.WriteLine("짖다!");
    }
}

class Dog : Animal
{
    public new void Bark()
    {
        Console.WriteLine("멍멍!");
    }
}
```

## sealed 키워드
함수나 클래스에 작성시 더 이상 상속할 수 없음
```C#
sealed class Dog : Animal
{
    public sealed override void Bark()
    {
        Console.WriteLine("멍멍!");
    }
}
```

## 명시적 인터페이스 구현
```C#
public class SampleClass : IControl, ISurface
{
    void IControl.Paint()
    {
        System.Console.WriteLine("IControl.Paint");
    }
    void ISurface.Paint()
    {
        System.Console.WriteLine("ISurface.Paint");
    }
}
```

## Type 변환(Convert Class)
```C#
byte[] bytes = {1, 2, 3};
string base64String = Convert.ToBase64String(bytes);
Console.WriteLine(base64String);
```

## Type 변환(is)
```C#
object obj = "Hello";
if (obj is string str)
{
    Console.WriteLine(str);
}
```

## 제네릭 제약조건
```C#
void Swap<T>(ref T a, ref T b) 
    where T : class // or struct
{
    T temp = a;
    a = b;
    b = temp;
}



```
new 제약 조건은 제네릭 클래스 또는 메서드 선언의 형식 인수에 매개 변수가 없는 공용 생성자가 있어야 함을 지정
```C#
void CreateInstance<T, T2>(out T a, out T2 b)
    where T : class, new() // new 제약조건
    where T2 : class, new()
{
    a = new T();
    b = new T2();
}

T CreateInstance<T>() 
    where T : class, new()
{
    return new T();
}

var animal = CreateInstance<Dog>();
```
```C#
T CreateInstance<T>() 
    where T : IAnimal, new() // 인터페이스 제약조건
{
    T instance = new T();
    instance.Bark();
    return instance;
}
```