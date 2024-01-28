using GradesApp;

class Program
{
    static string selectEnglish = "Please select language: press 1 for English or 2 for Polish. If you want to quit, press 'q'.";
    static string selectPolish = "Proszę wybrać język: naciśnij 1 dla angielskiego lub 2 dla polskiego. Jeśli chcesz zamknąć dziennik naciśnij 'q'.";
    static string optionsEnglish = "- press 1 to save the grades to the .txt file " +
        "\n- press 2 to store the grades in program memory \n- press 'q' to close the journal \n- if you want to go back to the language selection, press 'x'";
    static string optionsPolish = "- naciśnij 1 aby zapisać oceny do pliku .txt " +
            "\n- naciśnij 2 aby zapisać oceny w pamięci programu \n- naciśnij 'q' aby zamknąć dziennik \n- jeśli chcesz wrócić do wyboru języka naciśnij 'x'";

    static string currentLanguage = "";
    static string farewellEnglish = "\nSee you soon!";
    static string farewellPolish = "\nDo zobaczenia!";

    static string nameOfStudent;
    static string surnameOfStudent;

    static StudentBase student;
    static string saveGradesMethod = "";

    static ConsoleColor errorColor = ConsoleColor.Red;
    static ConsoleColor correctColor = ConsoleColor.DarkGreen;
    static ConsoleColor welcomeColor = ConsoleColor.DarkYellow;
    static ConsoleColor optionsColor = ConsoleColor.DarkGray;
    static ConsoleColor studentResultColor = ConsoleColor.DarkCyan;


    static void Main(string[] args)
    {
        Console.WriteLine(selectEnglish);
        Console.WriteLine(selectPolish);

        ChooseLanguage();
    }

    static void ChooseLanguage()
    {
        while (true)
        {
            var languageInput = Console.ReadLine();
            if (languageInput == "1" || languageInput == "2")
            {
                currentLanguage = (languageInput == "1") ? "English" : "Polish";
                WriteLineColor(welcomeColor, $"\n{(currentLanguage == "English" ? "Welcome to the electronic journal!" : "Witamy w dzienniku elektronicznym!")} " +
                    $"\n==================================");
                HowToSaveGrades();
                break;
            }
            else if (languageInput == "q" || languageInput == "Q")
            {
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
                    Console.WriteLine($"{farewellEnglish} {farewellPolish}");
                }
                break;
            }
            else
            {
                WriteLineColor(errorColor, "\nInvalid character. You can only enter 1 or 2 or 'q'. Try again.");
                WriteLineColor(errorColor, "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
                Console.WriteLine("------------------------------------------------------------------------------------\n");
                Console.WriteLine($"{selectEnglish} \n{selectPolish}");
            }
        }
    }
    static void HowToSaveGrades()
    {
        WriteLineColor(optionsColor, $"\n{(currentLanguage == "English" ? "How would you like to store your added grades?\n" + optionsEnglish :
            "Jak chcesz przechowywać dodane oceny?\n" + optionsPolish)}");
        while (true)
        {
            var saveGrades = Console.ReadLine();
            if (saveGrades == "1" || saveGrades == "2")
            {
                saveGradesMethod = saveGrades == "1" ? "StudentInFile" : "StudentInMemory";
                var selectedOption = saveGradesMethod == "StudentInFile" ? ($"{(currentLanguage == "English" ? "You have selected to save grades in a file." :
                    "Wybrano zapis ocen w pliku.")}") : ($"{(currentLanguage == "English" ? "You have selected to save grades in program memory." :
                    "Wybrano zapis ocen w pamięci programu.")}\n");
                WriteLineColor(correctColor, $"\n{selectedOption}");
                StudentName();
                break;
            }
            else if (saveGrades == "q" || saveGrades == "Q")
            {
                CloseApp();
                break;
            }
            else if (saveGrades == "x" || saveGrades == "X")
            {
                Console.WriteLine();
                Console.WriteLine(selectEnglish);
                Console.WriteLine(selectPolish);
                ChooseLanguage();
            }
            else
            {
                WriteLineColor(errorColor, $"\n{(currentLanguage == "English" ? "Invalid character. You can only enter 1 or 2 or 'q' or 'x'. Try again." :
                    "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q' lub 'x'. Spróbuj ponownie.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? optionsEnglish : optionsPolish)}");
            };
        }
    }

    static void StudentName()
    {
        Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student`s name:" : "Wpisz imię ucznia:")}");
        while (true)
        {
            nameOfStudent = Console.ReadLine().Trim();
            if (nameOfStudent == "q" || nameOfStudent == "Q")
            {
                CloseApp();
                break;
            }
            else if (!string.IsNullOrEmpty(nameOfStudent) && !ContainsDigits(nameOfStudent))
            {
                StudentSurname();
                break;
            }
            else
            {
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "\nYou didn't enter the student's name or you accidentally used a digit. " +
                    "Try again." : "\nNie wpisałeś imienia ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student's name:" : "Wpisz imię ucznia:")}");
            }
        }
    }

    static void StudentSurname()
    {
        Console.WriteLine($"{(currentLanguage == "English" ? "\nEnter the student`s surname:" : "\nWpisz nazwisko ucznia:")}");
        while (true)
        {
            surnameOfStudent = Console.ReadLine().Trim();

            if (surnameOfStudent == "q" || surnameOfStudent == "Q")
            {
                CloseApp();
                break;
            }
            else if (!string.IsNullOrEmpty(surnameOfStudent) && !ContainsDigits(surnameOfStudent))
            {
                nameOfStudent = char.ToUpper(nameOfStudent[0]) + nameOfStudent.Substring(1).ToLower();
                surnameOfStudent = char.ToUpper(surnameOfStudent[0]) + surnameOfStudent.Substring(1).ToLower();
                string fileName = $"{nameOfStudent}_{surnameOfStudent}.txt";
                if (saveGradesMethod == "StudentInFile")
                {
                    student = new StudentInFile(nameOfStudent, surnameOfStudent, currentLanguage == "English" ? Language.English : Language.Polish, fileName);
                }
                else
                {
                    student = new StudentInMemory(nameOfStudent, surnameOfStudent, currentLanguage == "English" ? Language.English : Language.Polish);
                }

                Console.WriteLine($"{(currentLanguage == "English" ? $"\nYou add grades for the student: {nameOfStudent} {surnameOfStudent}. Add grade:" :
                    $"\nDodajesz oceny dla ucznia: {nameOfStudent} {surnameOfStudent}. Dodaj ocenę:")}");
                EnterGrade();
                break;
            }
            else
            {
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "You didn't enter the student's surname or you accidentally used a digit. " +
                    "Try again." : "Nie wpisałeś nazwiska ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student's surname:" : "Wpisz nazwisko ucznia:")}");
            }
        }
    }
    static void EnterGrade()
    {
        student.GradeAdded += StudentGradeAdded;

        void StudentGradeAdded(object sender, EventArgs args)
        {
            WriteLineColor(correctColor, $"{(currentLanguage == "English" ? "A new grade has been added." : "Dodano nową ocenę.")}");
        }
        while (true)
        {

            var input = Console.ReadLine();
            if (input == "q" || input == "Q")
            {
                ShowStatistics();
                break;
            }
            else if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "You must enter a grade. You cannot leave the field blank." : "Musisz wpisać ocenę. " +
                    "Nie możesz zostawić pustego pola.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? "Add grade:" : "Dodaj ocenę:")}");
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
                Console.WriteLine($"{(currentLanguage == "English" ? "Add another grade. If you have finished adding grades, press 'q':" : "Dodaj kolejną ocenę. " +
                    "Jeśli zakończyłeś dodawanie ocen wciśnij 'q':")}");
            }
        }
    }

    static void ShowStatistics()
    {
        var statistics = student.GetStatistics();

        if (statistics.Count == 0)
        {
            WriteLineColor(errorColor, $"\n\n{(currentLanguage == "English" ? $"Unfortunately, statistics cannot be displayed because no grades have " +
                $"been added for student {nameOfStudent} {surnameOfStudent} yet:" : $"Niestety statystyki nie mogą zostać wyświetlone, ponieważ nie dodano " +
                $"jeszcze żadnych ocen dla ucznia {nameOfStudent} {surnameOfStudent}: ")}");
        }
        else
        {
            WriteLineColor(studentResultColor, $"\n\n{(currentLanguage == "English" ? $"Student's results: {nameOfStudent} {surnameOfStudent} based on " +
            $"{statistics.Count} added grades" : $"Wyniki ucznia: {nameOfStudent} {surnameOfStudent} na podstawie {statistics.Count} wprowadzonych ocen")}:\n");
            Console.WriteLine($"{(currentLanguage == "English" ? "Average" : "Średnia")}: {statistics.Average:N2}");
            Console.WriteLine($"{(currentLanguage == "English" ? "Lowest grade" : "Najniższa ocena")}: {statistics.Min}");
            Console.WriteLine($"{(currentLanguage == "English" ? "Highest grade" : "Najwyższa ocena")}: {statistics.Max}");
            Console.WriteLine($"{(currentLanguage == "English" ? "Final grade" : "Ocena końcowa")}: {statistics.AverageInWord}");

        }

        GoodBye();
    }

    static void GoodBye()
    {
        Console.WriteLine(currentLanguage == "English" ? farewellEnglish : farewellPolish);
    }
    static void CloseApp()
    {
        GoodBye();
        Environment.Exit(0);
    }
    static void WriteLineColor(ConsoleColor color, string message)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    static bool ContainsDigits(string input)
    {
        return input.Any(char.IsDigit);
    }
}