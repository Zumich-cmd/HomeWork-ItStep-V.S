using System;
using System.Collections.Generic;
using System.Linq;

// Клас студента
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }

    public Student(int id, string name, string group)
    {
        Id = id;
        Name = name;
        Group = group;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name}, група: {Group}";
    }
}

// Прогрес студента в курсі
class CourseProgress
{
    public string CourseName { get; set; }
    public double Score { get; set; }
    public List<string> CompletedTopics { get; set; }
    public string CurrentTopic { get; set; }

    public CourseProgress(string courseName, double score, List<string> completedTopics, string currentTopic)
    {
        CourseName = courseName;
        Score = score;
        CompletedTopics = completedTopics;
        CurrentTopic = currentTopic;
    }

    public override string ToString()
    {
        return $"  Course: {CourseName}, Score: {Score}, Current topic: {CurrentTopic}, Completed topics: {CompletedTopics.Count}";
    }
}

class Program
{
    // Головна структура - словник студент -> список прогресів
    static Dictionary<Student, List<CourseProgress>> data = new Dictionary<Student, List<CourseProgress>>();

    static void Main()
    {
        // Додаємо студентів
        AddStudent(new Student(1, "Ivanenko Oleg", "CS-21"));
        AddStudent(new Student(2, "Petrenko Maria", "CS-21"));
        AddStudent(new Student(3, "Sydorenko Dmytro", "IT-22"));

        // Додаємо прогрес
        AddCourse(1, new CourseProgress("C#", 92, new List<string> { "Variables", "Loops", "OOP" }, "Generics"));
        AddCourse(1, new CourseProgress("Algorithms", 78, new List<string> { "Sorting" }, "Graphs"));
        AddCourse(2, new CourseProgress("C#", 55, new List<string> { "Variables" }, "Loops"));
        AddCourse(3, new CourseProgress("C#", 88, new List<string> { "Variables", "Loops" }, "OOP"));
        AddCourse(3, new CourseProgress("Algorithms", 95, new List<string> { "Sorting", "Graphs" }, "DP"));

        // Оновлюємо бал студента 2 на курсі C#
        UpdateCourse(2, "C#", 70, new List<string> { "Variables", "Loops" }, "OOP");

        // Виводимо всі дані
        Console.WriteLine("=== All students ===");
        PrintAll();

        // Пошук за групою
        Console.WriteLine("\n=== Students in group CS-21 ===");
        foreach (var s in GetByGroup("CS-21"))
            Console.WriteLine(s);

        // Пошук за мінімальним балом
        Console.WriteLine("\n=== Students with score > 80 in at least one course ===");
        foreach (var s in GetByMinScore(80))
            Console.WriteLine(s);

        // Рейтинг за середнім балом
        Console.WriteLine("\n=== Ranking by average score ===");
        PrintRanking();
    }

    // Додати нового студента (або оновити якщо вже є)
    static void AddStudent(Student student)
    {
        var existing = data.Keys.FirstOrDefault(s => s.Id == student.Id);
        if (existing != null)
        {
            existing.Name = student.Name;
            existing.Group = student.Group;
            Console.WriteLine($"Updated: {student}");
        }
        else
        {
            data[student] = new List<CourseProgress>();
            Console.WriteLine($"Added: {student}");
        }
    }

    // Додати курс студенту
    static void AddCourse(int studentId, CourseProgress progress)
    {
        var student = data.Keys.FirstOrDefault(s => s.Id == studentId);
        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }
        data[student].Add(progress);
    }

    // Оновити прогрес по курсу
    static void UpdateCourse(int studentId, string courseName, double newScore, List<string> completed, string currentTopic)
    {
        var student = data.Keys.FirstOrDefault(s => s.Id == studentId);
        if (student == null) return;

        var course = data[student].FirstOrDefault(c => c.CourseName == courseName);
        if (course == null) return;

        course.Score = newScore;
        course.CompletedTopics = completed;
        course.CurrentTopic = currentTopic;
        Console.WriteLine($"Progress updated: {student.Name} -> {courseName}");
    }

    // Вивести всіх студентів та їх курси
    static void PrintAll()
    {
        foreach (var pair in data)
        {
            Console.WriteLine(pair.Key);
            foreach (var course in pair.Value)
                Console.WriteLine(course);
        }
    }

    // Фільтр за групою
    static List<Student> GetByGroup(string group)
    {
        return data.Keys.Where(s => s.Group == group).ToList();
    }

    // Фільтр за мінімальним балом
    static List<Student> GetByMinScore(double minScore)
    {
        return data.Where(pair => pair.Value.Any(c => c.Score >= minScore))
                   .Select(pair => pair.Key)
                   .ToList();
    }

    // Рейтинг за середнім балом
    static void PrintRanking()
    {
        var ranking = data
            .Select(pair => new
            {
                Student = pair.Key,
                Avg = pair.Value.Count > 0 ? pair.Value.Average(c => c.Score) : 0
            })
            .OrderByDescending(x => x.Avg)
            .ToList();

        for (int i = 0; i < ranking.Count; i++)
            Console.WriteLine($"{i + 1}. {ranking[i].Student.Name} — average score: {ranking[i].Avg:F1}");
    }
}