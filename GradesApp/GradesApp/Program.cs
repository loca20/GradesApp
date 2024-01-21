using GradesApp;

string selectEnglish = "Please select language: press 1 for English or 2 for Polish. If you want to quit, press 'q'.";
string selectPolish = "Proszę wybrać język: naciśnij 1 dla angielskiego lub 2 dla polskiego. Jeśli chcesz zamknąć dziennik naciśnij 'q'.";
Console.WriteLine(selectEnglish);
Console.WriteLine(selectPolish);

string currentLanguage = "";
string farewellEnglish = "See you soon!";
string farewellPolish = "Do zobaczenia!";

string nameOfStudent;
string surnameOfStudent;

static void WriteLineColor(ConsoleColor color, string message)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ResetColor();
}

ConsoleColor errorColor = ConsoleColor.Red;

static bool ContainsDigits(string input)
{
    return input.Any(char.IsDigit);
}

while (true)
{
    var languageInput = Console.ReadLine();
    if (languageInput == "1")
    {
        currentLanguage = "English";
        Console.WriteLine("\nWelcome to the electronic journal! \n================================== \n\nEnter the student`s name:");

        var student = new StudentInMemory("Anna", "Kos", Language.English);

        while (true)
        {
            nameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(nameOfStudent) && !ContainsDigits(nameOfStudent))
            {
                Console.WriteLine("\nEnter the student`s surname:");
                break;
            }
            else
            {
                WriteLineColor(errorColor, "You didn't enter the student's name or you accidentally used a digit. Try again.");
                Console.WriteLine("Enter the student's name:");
            }
        }

        while (true)
        {
            surnameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(surnameOfStudent) && !ContainsDigits(surnameOfStudent))
            {
                nameOfStudent = char.ToUpper(nameOfStudent[0]) + nameOfStudent.Substring(1).ToLower();
                surnameOfStudent = char.ToUpper(surnameOfStudent[0]) + surnameOfStudent.Substring(1).ToLower();
                Console.WriteLine($"\nYou add grades for the student: {nameOfStudent} {surnameOfStudent}. Add grade:");
                break;
            }
            else
            {
                WriteLineColor(errorColor, "You didn't enter the student's surname or you accidentally used a digit. Try again.");
                Console.WriteLine("Enter the student's surname:");
            }
        }

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }
            else if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                WriteLineColor(errorColor, "You must enter a grade. You cannot leave the field blank. Add a rating:");
            }
            else
            {
                try
                {
                    student.AddGrade(input.Trim());
                }
                catch (Exception e)
                {
                    WriteLineColor(errorColor, e.Message);
                }
                Console.WriteLine("Add another grade:");
            }
        }

        var statistics = student.GetStatistics();

        Console.WriteLine($"Average: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine(statistics.AverageWord);
        Console.WriteLine();
        Console.WriteLine("If you have finished adding grades and want to exit the journal, press 'q' one more time.");
    }
    else if (languageInput == "2")
    {
        currentLanguage = "Polish";
        Console.WriteLine("\nWitamy w dzienniku elektronicznym! \n================================== \n\nWpisz imię ucznia:");

        var student = new StudentInMemory("Anna", "Kos", Language.Polish);

        while (true)
        {
            nameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(nameOfStudent) && !ContainsDigits(nameOfStudent))
            {
                Console.WriteLine("\nWpisz nazwisko ucznia:");
                break;
            }
            else
            {
                WriteLineColor(errorColor, "Nie wpisałeś imienia ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.");
                Console.WriteLine( "Wpisz imię ucznia:");
            }
        }

        while (true)
        {
            surnameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(surnameOfStudent) && !ContainsDigits(surnameOfStudent))
            {
                nameOfStudent = char.ToUpper(nameOfStudent[0]) + nameOfStudent.Substring(1).ToLower();
                surnameOfStudent = char.ToUpper(surnameOfStudent[0]) + surnameOfStudent.Substring(1).ToLower();
                Console.WriteLine($"\nDodajesz oceny dla ucznia: {nameOfStudent} {surnameOfStudent}. Dodaj ocenę:");
                break;
            }
            else
            {
                WriteLineColor(errorColor, "Nie wpisałeś nazwiska ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.");
                Console.WriteLine("Wpisz nazwisko ucznia:");
            }
        }

        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q")
            {
                break;
            }
            else if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                WriteLineColor(errorColor, "Musisz wpisać ocenę. Nie możesz zostawić pustego pola. Dodaj ocenę:");
            }
            else
            {
                try
                {
                    student.AddGrade(input.Trim());
                }
                catch (Exception e)
                {
                    WriteLineColor(errorColor, e.Message);
                }
                Console.WriteLine("Dodaj kolejną ocenę:");
            }
        }

        var statistics = student.GetStatistics();

        Console.WriteLine($"Average: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine(statistics.AverageWord);
        Console.WriteLine("\nJeśli zakończyłeś dodawanie ocen i chcesz wyjść z dziennika, naciśnij jeszcze raz 'q'.");
    }
    else if (languageInput == "q")
    {
        Console.WriteLine();
        if (currentLanguage == "English")
        {
            Console.WriteLine(farewellEnglish);
        }
        else if (currentLanguage == "Polish")
        {
            Console.WriteLine(farewellPolish);
        }
        else
        {
            Console.WriteLine(farewellEnglish);
            Console.WriteLine(farewellPolish);
        }
        break;
    }
    else
    {
        WriteLineColor(errorColor, "\nInvalid character. You can only enter 1 or 2 or 'q'. Try again.");
        WriteLineColor(errorColor, "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
        Console.WriteLine("------------------------------------------------------------------------------------\n");
        Console.WriteLine(selectEnglish);
        Console.WriteLine(selectPolish);
    }
}