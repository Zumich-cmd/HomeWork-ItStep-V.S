using ContactValidatorLib;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Перевірка контактних даних через DLL-бібліотеку");
Console.WriteLine("Формат телефону: +380XXXXXXXXX");
Console.WriteLine();

RunCheck("ПІБ", "Іваненко Іван Іванович", ContactValidator.IsFullNameValid);
RunCheck("ПІБ", "Іваненко Іван123", ContactValidator.IsFullNameValid);

RunCheck("Вік", "19", ContactValidator.IsAgeValid);
RunCheck("Вік", "19 років", ContactValidator.IsAgeValid);

RunCheck("Телефон", "+380501234567", ContactValidator.IsPhoneValid);
RunCheck("Телефон", "050-123-45-67", ContactValidator.IsPhoneValid);

RunCheck("Email", "student@example.com", ContactValidator.IsEmailValid);
RunCheck("Email", "student.example.com", ContactValidator.IsEmailValid);

static void RunCheck(string fieldName, string value, Func<string, bool> validator)
{
    string result = validator(value) ? "правильно" : "помилка";
    Console.WriteLine($"{fieldName,-8}: {value,-25} -> {result}");
}
