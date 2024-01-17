using GradesApp;

string selectEnglish = "Please select language: press 1 for English or 2 for Polish. If you want to quit, press 'q'.";
string selectPolish = "Proszę wybrać język: naciśnij 1 dla angielskiego lub 2 dla polskiego. Jeśli chcesz zamknąć dziennik naciśnij 'q'.";
Console.WriteLine(selectEnglish);
Console.WriteLine(selectPolish);

while (true)
{
    var languageInput = Console.ReadLine();
    if (languageInput == "1")
    {
        Console.WriteLine();
        Console.WriteLine("Welcome to the electronic journal!");
        Console.WriteLine("==================================");
        Console.WriteLine();
        Console.WriteLine("Add a grade:");

        var student = new Student("Anna", "Kos");

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }
            student.AddGrade(input);
            Console.WriteLine("Add another grade:");
        }

        var statistics = student.GetStatistics();

        Console.WriteLine($"Average: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine(statistics.AverageWord);
    }
    else if (languageInput == "2")
    {
        Console.WriteLine();
        Console.WriteLine("Witamy w dzienniku elektronicznym!");
        Console.WriteLine("==================================");
        Console.WriteLine();
        Console.WriteLine("Dodaj ocenę:");

        var student = new Student("Anna", "Kos");

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }
            student.AddGrade(input);
            Console.WriteLine("Dodaj kolejną ocenę:");
        }

        var statistics = student.GetStatistics();

        Console.WriteLine($"Average: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine(statistics.AverageWord);
    }
    else if (languageInput == "q")
    {
        Console.WriteLine();
        Console.WriteLine("See you soon!");
        Console.WriteLine("Do zobaczenia!");
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Invalid character. You can only enter 1 or 2 or 'q'. Try again.");
        Console.WriteLine("Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
        Console.WriteLine("------------------------------------------------------------------------------------");
        Console.WriteLine(selectEnglish);
        Console.WriteLine(selectPolish);
    }
}