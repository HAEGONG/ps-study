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

## 대리자(Func)
반환값이 있는 메서드 캡슐화
```C#
// Func의 마지막 타입이 반환값, 나머지 타입들은 매개변수의 타입
void ApplyOperation(int x, int y, Func<int, int, int> operation)
{
    int result = operation(x, y);
    Console.WriteLine(result);
}

ApplyOperation(1, 2, Add);

int Add(int x, int y) => x + y;
```

## 대리자(Action)
반환값이 없는 메서드 캡슐화
```C#
void ActionMethod(String s, int i)
{
    Console.WriteLine(s + i);
}

Action<string, int> action = ActionMethod;
action.Invoke("Hello", 123);
```

## 대리자(Predicate)
조건에 따라 bool값을 반환하는 메서드 캡슐화
```C#
bool IsGreaterThanZero(int value)
{
    return value > 0;
}

Predicate<int> predicate = IsGreaterThanZero;
bool result = predicate.Invoke(1);
Console.WriteLine(result);
    
```

## 대리자(Comparison)
두 값을 비교하고 정렬 순서를 나타내는 int 반환
```C#
int Compare(int x, int y)
{
    return x.CompareTo(y);
}

Comparison<int> comparison = Compare;
Console.WriteLine(comparison(6, 2)); // 1
Console.WriteLine(comparison(2, 2)); // 0
Console.WriteLine(comparison(1, 4)); // -1
```

## 열거자(Enumerator)
컬렉션을 순회(iterate) 할 수 있게 해주는 객체  
주로 IEnumerable과 IEnumerator 인터페이스를 통해 구현
```C#
IEnumerator<int> GetEnumerator()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

var enumerator = GetEnumerator();
while (enumerator.MoveNext())
{
    Console.Write(enumerator.Current + " "); // 1 2 3
}
```
```C#
Collection collection = new Collection();

foreach (int value in collection)
{
    Console.WriteLine(value);
}

class Collection
{
    // 함수명은 반드시 GetEnumerator 가 되어야함
    public IEnumerator<int> GetEnumerator()
    {
        yield return 1;
        yield return 2;
        yield return 3;
    }
}
```

## 열거자(Enumerable)
```C#
IEnumerable<int> GetEnumerable()
{
    yield return 1;
    yield return 2;
    yield return 3;
}

var enumerable = GetEnumerable();
foreach (var value in enumerable)
{
    Console.WriteLine(value);
}

var enumerator = enumerable.GetEnumerator();
enumerator.MoveNext();
int i = enumerator.Current;
```

## 컬렉션(List)
```C#
var stringList = new List<string> {"a", "b", "c"};
List<string> stringList2 = ["가", "나", "다"]; // 컬렉션 표현식

// 요소 삽입
stringList.AddRange(stringList2);
stringList.Insert(1, "z");
stringList.InsertRange(2, stringList2);

// 요소 삭제
stringList.Remove("b");
stringList.RemoveAt(3);
stringList.RemoveAll(str =>
{
    return str == "a" || str == "c";  
});
stringList.Clear();

// 요소 검색
stringList = ["apple", "lemon", "lime"];
bool hasData = stringList.Contains("apple");
bool hasData2 = stringList.Contains("APPLE", StringComparer.OrdinalIgnoreCase);

int index = stringList.IndexOf("lemon"); // 1
int index2 = stringList.IndexOf("LEMON"); // -1

//Find: 조건에 맞는 첫번째 요소 반환
string? selected = stringList.Find(fruit =>
{
    return fruit.StartsWith("l"); // lemon
});
// FindAll: 조건에 맞는 모든 요소 반환
List<string> selectedList = stringList.FindAll(fruit =>
{
    return fruit.StartsWith("l"); // [lemon, lime]
});

// 정렬
List<int> intList = [3, 1, 6];
intList.Reverse(); // 6, 1, 3
intList.Sort(); // 1, 3, 6
intList.Sort((a, b) => b.CompareTo(a)); // 6, 3, 1

int count = intList.Count();
int[] ints = intList.ToArray(); // 배열로 변환
```

# Linq
```C#
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Transformation
var doubled = numbers.Select(n => n * 2); // [2, 4, 6, 8, 10, 12, 14, 16, 18, 20]
var numberObjects = numbers.Select(n => new { Value = n, IsEven = n % 2 == 0 });
// 위에 방법은 익명타입을 만들어서 method 내에서 구조화할 수 없음
// 새로운 클래스를 만들거나 아래처럼 튜플을 만드는 방법이 대안
var numberObjects2 = numbers.Select(n => (Value: n, IsEven: n % 2 == 0 ));

// Filtering
var evens = numbers.Where(n => n % 2 == 0); // [2, 4, 6, 8, 10]
var odds = from n in numbers 
    let isOdd = n % 2 != 0 
    where isOdd 
    select n; // [1, 3, 5, 7, 9]

// Ordering
var ascending = numbers.OrderBy(n => n); // [1, 2, 3, ...]
var descending = numbers.OrderByDescending(n => n); // [10, 9, 8, ...]
var complex = numbers.OrderBy(n => n % 3).ThenByDescending(n => n); // [9, 6, 3, 10, 7, 4, 1, 8, 5, 2]
// n % 3 == 0: 3, 6, 9 → 내림차순 → 9, 6, 3
// n % 3 == 1: 1, 4, 7, 10 → 내림차순 → 10, 7, 4, 1
// n % 3 == 2: 2, 5, 8 → 내림차순 → 8, 5, 2

// Grouping
var groups = numbers.GroupBy(n => n % 3); // 3으로 나누고 나머지값이 같은 숫자 끼리 묶임
foreach (var group in groups)
{
    Console.WriteLine($"Remainder {group.Key}: {string.Join(", ", group)}");
    // Remainder 1: 1, 4, 7, 10
    // Remainder 2: 2, 5, 8
    // Remainder 0: 3, 6, 9
}
var flattenGroup = groups.SelectMany(n => n); // [1, 4, 7, 10, 2, 5, 8, 3, 6, 9] flatMap

// Join
var result = from student in students
             join score in studentScores
             on students.Id equals score.StudentId
             select (student, score);
var result = students.Join(
        studentScores,
        student => student.Id,
        score => score.StudentId,
        (student, score) => (student, score));

// Aggregation
int sum = numbers.Sum();            // 55
int min = numbers.Min();            // 1
int max = numbers.Max();            // 10
double average = numbers.Average(); // 5.5
int sum2 = numbers.Aggregate((a, b) => a + b); // 55
int product = numbers.Aggregate((a, b) => a * b); // 3628800 (factorial of 10)

// Quantifiers
bool allEven = numbers.All(n => n % 2 == 0); // false
bool anyEven = numbers.Any(n => n % 2 == 0); // true
bool containsFive = numbers.Contains(5);     // true

// Partitioning
var firstThree = numbers.Take(4);     // [1, 2, 3, 4]
var skipFirstThree = numbers.Skip(5); // [6, 7, 8, 9, 10]
var takeLast = numbers.TakeLast(2);   // [9, 10]
var skipLast = numbers.SkipLast(2);   // [1, 2, 3, 4, 5, 6, 7, 8]

// Element operations
int first = numbers.First(); // 1
int firstEven = numbers.First(n => n % 2 == 0); // 2
int lastOdd = numbers.Last(n => n % 2 != 0);    // 9

// 시퀀스에서 지정된 조건에 맞는 유일한 요소를 반환하고
// 이러한 요소가 둘 이상 있거나 없으면 예외를 throw
int single = numbers.Where(n => n == 5).Single(); // 5
```