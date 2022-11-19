# StringFormatter
Необходимо реализовать класс StringFormatter с единственным методом Format, который должен выполнять упрощённую "интерполяцию строк".
public interface IStringFormatter
{
    string Format(string template, object target);
}
Для упрощённого доступа к готовому экземпляру formatter'a рекомендуется в реализации класса объявить статическое поле с созданным экземпляром "по умолчанию" (такое объявление будет подразумеваться в примерах ниже):
public class StringFormatter : IStringFormatter
{
    public static readonly StringFormatter Shared = new StringFormatter();
    
    ...
}
Интерполяция строк
Полноценная интерполяция строк доступна начиная с C# 6.0 и позволяет выполнять подстановку переменных, полей, свойств и выражений по месту в строковых литералах:
int a = 2021;
string = "спп";
string result = $"{s.ToUpper()}-{a+1}"; // СПП-2022
В данной лабораторной работе необходимо реализовать упрощённую интерполяцию строк, когда выполняется подстановка только полей и свойств переданного объекта.
using StringFormatting;

class User
{
    public string FirstName { get; }
    public string LastName { get; }
    
    public User(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetGreeting()
    {
        return StringFormatter.Shared.Format(
            "Привет, {FirstName} {LastName}!", this);
    }
}

...

var user = new User("Петя", "Иванов");
var fullName = user.GetGreeting(); // Привет, Петя Иванов!
При разборе форматной строки пользоваться регулярными выражениями запрещается.
Для использования символов { и } как части строки предусмотреть экранирование:
string formatted = StringFormatter.Shared.Format(
    "{{FirstName}} транслируется в {FirstName}", user); 
// {FirstName} транслируется в Петя
При передаче в метод Format строки, содержащей несбалансированные фигурные скобки, должно выбрасываться исключение с описанием ошибки.
Должны поддерживать свойства любых типов, при этом не строковые свойства перед подстановкой достаточно преобразовать к строке используя стандартную реализацию метода ToString().
Кэширование кода с помощью деревьев выражений
Для увеличения производительности метода Format необходимо динамически генерировать и кэшировать код доступа к найденным полям с помощью деревьев выражений (см. Creating Expression Trees by Using the API).
В примере выше должно будет сгенерировано два выражения:
Expression<Func<User, string>> firstNameAccessor = (User user) => user.FirstName;
Expression<Func<User, string>> lastNameAccessor = (User user) => user.LastName;
Выражения должны компилироваться только один раз и храниться в виде делегатов. 
Кэш должен быть потокобезопасным, так как метод Format может вызываться одновременно из нескольких потоков.
Работа Formatter'a должны быть полностью проверена с помощью модульных тестов. Использование для этого вспомогательной консольной программы запрещается.