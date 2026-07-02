using FakeUsersApp.Generators;
using FakeUsersApp.Models;
using Serilog;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;

// Налаштування Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .WriteTo.File(
        path: "logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

try
{
    Log.Information("=== Запуск застосунку генерації фейкових користувачів ===");

    var generator = new FakeUserGenerator(Log.Logger);

    Console.WriteLine("Скільки фейкових користувачів згенерувати?");
    Console.Write("> ");
    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int count) || count <= 0)
    {
        Log.Warning("Некоректне введення від користувача: '{Input}'. Використано значення за замовчуванням = 5", input);
        count = 5;
    }

    List<FakeUser> users = generator.GenerateUsers(count);

    Console.WriteLine();
    Console.WriteLine($"Згенеровано {users.Count} користувач(ів):");
    Console.WriteLine(new string('-', 100));
    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
    Console.WriteLine(new string('-', 100));

    TestUsers(users);

    Log.Information("=== Роботу застосунку завершено успішно ===");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Застосунок завершився з критичною помилкою");
}
finally
{
    Log.CloseAndFlush();
}

// Тестування згенерованих користувачів
void TestUsers(List<FakeUser> users)
{
    Log.Information("Початок тестування згенерованих користувачів (перевірка коректності даних)");

    int errors = 0;

    foreach (var user in users)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            Log.Error("Тест не пройдено: порожнє ім'я у користувача {@User}", user);
            errors++;
        }

        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            Log.Error("Тест не пройдено: порожнє прізвище у користувача {@User}", user);
            errors++;
        }

        if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains('@') || !user.Email.Contains('.'))
        {
            Log.Error("Тест не пройдено: некоректний email '{Email}'", user.Email);
            errors++;
        }

        if (string.IsNullOrWhiteSpace(user.PhoneNumber) || !user.PhoneNumber.StartsWith("+380") || user.PhoneNumber.Length != 13)
        {
            Log.Error("Тест не пройдено: некоректний номер телефону '{Phone}'", user.PhoneNumber);
            errors++;
        }

        if (string.IsNullOrWhiteSpace(user.Address))
        {
            Log.Error("Тест не пройдено: порожня адреса у користувача {@User}", user);
            errors++;
        }
    }

    Console.WriteLine();
    if (errors == 0)
    {
        Console.WriteLine("Тестування пройшло успішно: помилок не виявлено.");
        Log.Information("Тестування завершено успішно, помилок не виявлено (перевірено {Count} користувачів)", users.Count);
    }
    else
    {
        Console.WriteLine($"Тестування завершено з помилками: {errors}.");
        Log.Warning("Тестування завершено, виявлено помилок: {Errors} (перевірено {Count} користувачів)", errors, users.Count);
    }
}
