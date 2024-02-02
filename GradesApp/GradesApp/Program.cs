using GradesApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(StaticVariable.ProgramConstants.selectEnglish);
        Console.WriteLine(StaticVariable.ProgramConstants.selectPolish);

        ChooseLanguage();
    }

    static void ChooseLanguage()
    {
        while (true)
        {
            var languageInput = Console.ReadLine();
            if (languageInput == "1" || languageInput == "2")
            {
                StaticVariable.ProgramConstants.currentLanguage = (languageInput == "1") ? "English" : "Polish";
                WriteLineColor(StaticVariable.ProgramConstants.welcomeColor, $"\n{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Welcome to the electronic journal!" : "Witamy w dzienniku elektronicznym!")} " +
                    $"\n==================================");
                HowToSaveGrades();
                break;
            }
            else if (languageInput == "q" || languageInput == "Q")
            {
                if (StaticVariable.ProgramConstants.currentLanguage == "English")
                {
                    Console.WriteLine(StaticVariable.ProgramConstants.farewellEnglish);
                }
                else if (StaticVariable.ProgramConstants.currentLanguage == "Polish")
                {
                    Console.WriteLine(StaticVariable.ProgramConstants.farewellPolish);
                }
                else
                {
                    Console.WriteLine($"{StaticVariable.ProgramConstants.farewellEnglish} {StaticVariable.ProgramConstants.farewellPolish}");
                }
                break;
            }
            else
            {
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, "\nInvalid character. You can only enter 1 or 2 or 'q'. Try again.");
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
                Console.WriteLine("------------------------------------------------------------------------------------\n");
                Console.WriteLine($"{StaticVariable.ProgramConstants.selectEnglish} \n{StaticVariable.ProgramConstants.selectPolish}");
            }
        }
    }
    static void HowToSaveGrades()
    {
        WriteLineColor(StaticVariable.ProgramConstants.optionsColor, $"\n{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "How would you like to store your added grades?\n" + StaticVariable.ProgramConstants.optionsEnglish :
            "Jak chcesz przechowywać dodane oceny?\n" + StaticVariable.ProgramConstants.optionsPolish)}");
        while (true)
        {
            var saveGrades = Console.ReadLine();
            if (saveGrades == "1" || saveGrades == "2")
            {
                StaticVariable.ProgramConstants.saveGradesMethod = saveGrades == "1" ? "StudentInFile" : "StudentInMemory";
                var selectedOption = StaticVariable.ProgramConstants.saveGradesMethod == "StudentInFile" ? ($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "You have selected to save grades in a file." :
                    "Wybrano zapis ocen w pliku.")}") : ($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "You have selected to save grades in program memory." :
                    "Wybrano zapis ocen w pamięci programu.")}\n");
                WriteLineColor(StaticVariable.ProgramConstants.correctColor, $"\n{selectedOption}");
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
                Console.WriteLine(StaticVariable.ProgramConstants.selectEnglish);
                Console.WriteLine(StaticVariable.ProgramConstants.selectPolish);
                ChooseLanguage();
            }
            else
            {
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, $"\n{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Invalid character. You can only enter 1 or 2 or 'q' or 'x'. Try again." :
                    "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q' lub 'x'. Spróbuj ponownie.")}");
                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? StaticVariable.ProgramConstants.optionsEnglish : StaticVariable.ProgramConstants.optionsPolish)}");
            };
        }
    }

    static void StudentName()
    {
        Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Enter the student`s name:" : "Wpisz imię ucznia:")}");
        while (true)
        {
            StaticVariable.ProgramConstants.nameOfStudent = Console.ReadLine().Trim();
            if (StaticVariable.ProgramConstants.nameOfStudent == "q" || StaticVariable.ProgramConstants.nameOfStudent == "Q")
            {
                CloseApp();
                break;
            }
            else if (!string.IsNullOrEmpty(StaticVariable.ProgramConstants.nameOfStudent) && !ContainsDigits(StaticVariable.ProgramConstants.nameOfStudent))
            {
                StudentSurname();
                break;
            }
            else
            {
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, $"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "\nYou didn't enter the student's name or you accidentally used a digit. " +
                    "Try again." : "\nNie wpisałeś imienia ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Enter the student's name:" : "Wpisz imię ucznia:")}");
            }
        }
    }

    static void StudentSurname()
    {
        Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "\nEnter the student`s surname:" : "\nWpisz nazwisko ucznia:")}");
        while (true)
        {
            StaticVariable.ProgramConstants.surnameOfStudent = Console.ReadLine().Trim();

            if (StaticVariable.ProgramConstants.surnameOfStudent == "q" || StaticVariable.ProgramConstants.surnameOfStudent == "Q")
            {
                CloseApp();
                break;
            }
            else if (!string.IsNullOrEmpty(StaticVariable.ProgramConstants.surnameOfStudent) && !ContainsDigits(StaticVariable.ProgramConstants.surnameOfStudent))
            {
                StaticVariable.ProgramConstants.nameOfStudent = char.ToUpper(StaticVariable.ProgramConstants.nameOfStudent[0]) + StaticVariable.ProgramConstants.nameOfStudent.Substring(1).ToLower();
                StaticVariable.ProgramConstants.surnameOfStudent = char.ToUpper(StaticVariable.ProgramConstants.surnameOfStudent[0]) + StaticVariable.ProgramConstants.surnameOfStudent.Substring(1).ToLower();
                string fileName = $"{StaticVariable.ProgramConstants.nameOfStudent}_{StaticVariable.ProgramConstants.surnameOfStudent}.txt";
                if (StaticVariable.ProgramConstants.saveGradesMethod == "StudentInFile")
                {
                    StaticVariable.ProgramConstants.student = new StudentInFile(StaticVariable.ProgramConstants.nameOfStudent, StaticVariable.ProgramConstants.surnameOfStudent, StaticVariable.ProgramConstants.currentLanguage == "English" ? Language.English : Language.Polish, fileName);
                }
                else
                {
                    StaticVariable.ProgramConstants.student = new StudentInMemory(StaticVariable.ProgramConstants.nameOfStudent, StaticVariable.ProgramConstants.surnameOfStudent, StaticVariable.ProgramConstants.currentLanguage == "English" ? Language.English : Language.Polish);
                }

                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? $"\nYou add grades for the student: {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent}. Add grade:" :
                    $"\nDodajesz oceny dla ucznia: {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent}. Dodaj ocenę:")}");
                EnterGrade();
                break;
            }
            else
            {
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, $"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "You didn't enter the student's surname or you accidentally used a digit. " +
                    "Try again." : "Nie wpisałeś nazwiska ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Enter the student's surname:" : "Wpisz nazwisko ucznia:")}");
            }
        }
    }
    static void EnterGrade()
    {
        StaticVariable.ProgramConstants.student.GradeAdded += StudentGradeAdded;

        void StudentGradeAdded(object sender, EventArgs args)
        {
            WriteLineColor(StaticVariable.ProgramConstants.correctColor, $"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "A new grade has been added." : "Dodano nową ocenę.")}");
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
                WriteLineColor(StaticVariable.ProgramConstants.errorColor, $"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "You must enter a grade. You cannot leave the field blank." : "Musisz wpisać ocenę. " +
                    "Nie możesz zostawić pustego pola.")}");
                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Add grade:" : "Dodaj ocenę:")}");
            }
            else
            {
                try
                {
                    StaticVariable.ProgramConstants.student.AddGrade(input.Trim());
                }
                catch (Exception e)
                {
                    WriteLineColor(StaticVariable.ProgramConstants.errorColor, e.Message);
                }
                Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Add another grade. If you have finished adding grades, press 'q':" : "Dodaj kolejną ocenę. " +
                    "Jeśli zakończyłeś dodawanie ocen wciśnij 'q':")}");
            }
        }
    }

    static void ShowStatistics()
    {
        var statistics = StaticVariable.ProgramConstants.student.GetStatistics();

        if (statistics.Count == 0)
        {
            WriteLineColor(StaticVariable.ProgramConstants.errorColor, $"\n\n{(StaticVariable.ProgramConstants.currentLanguage == "English" ? $"Unfortunately, statistics cannot be displayed because no grades have " +
                $"been added for student {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent} yet:" : $"Niestety statystyki nie mogą zostać wyświetlone, ponieważ nie dodano " +
                $"jeszcze żadnych ocen dla ucznia {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent}: ")}");
        }
        else
        {
            WriteLineColor(StaticVariable.ProgramConstants.studentResultColor, $"\n\n{(StaticVariable.ProgramConstants.currentLanguage == "English" ? $"Student's results: {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent} based on " +
            $"{statistics.Count} added grades" : $"Wyniki ucznia: {StaticVariable.ProgramConstants.nameOfStudent} {StaticVariable.ProgramConstants.surnameOfStudent} na podstawie {statistics.Count} wprowadzonych ocen")}:\n");
            Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Average" : "Średnia")}: {statistics.Average:N2}");
            Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Lowest grade" : "Najniższa ocena")}: {statistics.Min}");
            Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Highest grade" : "Najwyższa ocena")}: {statistics.Max}");
            Console.WriteLine($"{(StaticVariable.ProgramConstants.currentLanguage == "English" ? "Final grade" : "Ocena końcowa")}: {statistics.AverageInWord}");
        }

        GoodBye();
    }

    static void GoodBye()
    {
        Console.WriteLine(StaticVariable.ProgramConstants.currentLanguage == "English" ? StaticVariable.ProgramConstants.farewellEnglish : StaticVariable.ProgramConstants.farewellPolish);
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