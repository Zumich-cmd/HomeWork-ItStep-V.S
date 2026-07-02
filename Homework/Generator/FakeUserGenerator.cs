using FakeUsersApp.Models;
using Serilog;

namespace FakeUsersApp.Generators;

public class FakeUserGenerator
{
    private readonly Random _random = new();
    private readonly ILogger _logger;

    private static readonly (string Ua, string En)[] MaleFirstNames =
    {
        ("Олександр", "Oleksandr"),
        ("Андрій", "Andrii"),
        ("Богдан", "Bohdan"),
        ("Володимир", "Volodymyr"),
        ("Дмитро", "Dmytro"),
        ("Іван", "Ivan"),
        ("Максим", "Maksym"),
        ("Микола", "Mykola"),
        ("Олег", "Oleh"),
        ("Тарас", "Taras"),
    };

    private static readonly (string Ua, string En)[] FemaleFirstNames =
    {
        ("Анна", "Anna"),
        ("Вікторія", "Viktoriia"),
        ("Дарина", "Daryna"),
        ("Катерина", "Kateryna"),
        ("Марія", "Mariia"),
        ("Наталія", "Nataliia"),
        ("Оксана", "Oksana"),
        ("Олена", "Olena"),
        ("Софія", "Sofiia"),
        ("Юлія", "Yuliia"),
    };

    private static readonly (string Ua, string En)[] LastNames =
    {
        ("Бондаренко", "Bondarenko"),
        ("Коваленко", "Kovalenko"),
        ("Кравченко", "Kravchenko"),
        ("Мельник", "Melnyk"),
        ("Олійник", "Oliinyk"),
        ("Пилипенко", "Pylypenko"),
        ("Савченко", "Savchenko"),
        ("Ткаченко", "Tkachenko"),
        ("Шевченко", "Shevchenko"),
        ("Яценко", "Yatsenko"),
    };

    private static readonly string[] Cities =
    {
        "Київ", "Львів", "Одеса", "Харків", "Дніпро",
        "Вінниця", "Полтава", "Чернігів", "Житомир", "Івано-Франківськ"
    };

    private static readonly string[] Streets =
    {
        "вул. Шевченка", "вул. Франка", "вул. Соборна", "вул. Незалежності",
        "вул. Грушевського", "вул. Лесі Українки", "вул. Європейська",
        "вул. Миру", "вул. Центральна", "вул. Садова"
    };

    private static readonly string[] EmailDomains =
    {
        "gmail.com", "ukr.net", "i.ua", "outlook.com", "meta.ua"
    };

    private static readonly string[] OperatorCodes =
    {
        "050", "063", "066", "067", "068", "073", "093", "095", "096", "097", "098", "099"
    };

    public FakeUserGenerator(ILogger logger)
    {
        _logger = logger.ForContext<FakeUserGenerator>();
    }

    public FakeUser GenerateUser()
    {
        bool isMale = _random.Next(2) == 0;

        var (firstUa, firstEn) = isMale ? Pick(MaleFirstNames) : Pick(FemaleFirstNames);
        var (lastUa, lastEn) = Pick(LastNames);

        var user = new FakeUser
        {
            FirstName = firstUa,
            LastName = lastUa,
            PhoneNumber = GeneratePhoneNumber(),
            Email = GenerateEmail(firstEn, lastEn),
            Address = GenerateAddress()
        };

        _logger.Debug("Згенеровано користувача: {@User}", user);
        return user;
    }

    public List<FakeUser> GenerateUsers(int count)
    {
        if (count < 0)
        {
            _logger.Error("Спроба згенерувати від'ємну кількість користувачів: {Count}", count);
            throw new ArgumentOutOfRangeException(nameof(count), "Кількість користувачів не може бути від'ємною");
        }

        _logger.Information("Початок генерації {Count} фейкових користувачів", count);

        var users = new List<FakeUser>(count);
        for (int i = 0; i < count; i++)
        {
            users.Add(GenerateUser());
        }

        _logger.Information("Успішно згенеровано {Count} користувачів", users.Count);
        return users;
    }

    private T Pick<T>(T[] array) => array[_random.Next(array.Length)];

    private string GeneratePhoneNumber()
    {
        string code = Pick(OperatorCodes);
        string number = _random.Next(0, 10_000_000).ToString("D7");
        return $"+38{code}{number}";
    }

    private string GenerateEmail(string firstEn, string lastEn)
    {
        string domain = Pick(EmailDomains);
        int suffix = _random.Next(1, 999);

        string localPart = _random.Next(3) switch
        {
            0 => $"{firstEn}.{lastEn}",
            1 => $"{firstEn[0]}{lastEn}",
            _ => $"{lastEn}{firstEn[0]}"
        };

        return $"{localPart.ToLowerInvariant()}{suffix}@{domain}";
    }

    private string GenerateAddress()
    {
        string city = Pick(Cities);
        string street = Pick(Streets);
        int building = _random.Next(1, 150);
        int apartment = _random.Next(1, 300);
        return $"м. {city}, {street}, буд. {building}, кв. {apartment}";
    }
}
