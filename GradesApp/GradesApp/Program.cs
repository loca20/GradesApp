using GradesApp;


class Program
{
    static string selectEnglish = "Please select language: press 1 for English or 2 for Polish. If you want to quit, press 'q'.";
    static string selectPolish = "Proszę wybrać język: naciśnij 1 dla angielskiego lub 2 dla polskiego. Jeśli chcesz zamknąć dziennik naciśnij 'q'.";
    static string quitEnglish = "\nIf you have finished adding grades and want to exit the journal, press 'q' one more time.";
    static string quitPolish = "\nJeśli zakończyłeś dodawanie ocen i chcesz wyjść z dziennika, naciśnij jeszcze raz 'q'.";

    static string currentLanguage = "";
    static string farewellEnglish = "\nSee you soon!";
    static string farewellPolish = "\nDo zobaczenia!";

    static string nameOfStudent;
    static string surnameOfStudent;

    static StudentInFile student;

    ConsoleColor errorColor = ConsoleColor.Red;
    ConsoleColor correctColor = ConsoleColor.DarkGreen;

    static void Main(string[] args)
    {
        Console.WriteLine(selectEnglish);
        Console.WriteLine(selectPolish);

        while (true)
        {
            var languageInput = Console.ReadLine();
            if (languageInput == "1" || languageInput == "2")
            {
                currentLanguage = (languageInput == "1") ? "English" : "Polish";
                Console.WriteLine($"\n{(currentLanguage == "English" ? "Welcome to the electronic journal!" : "Witamy w dzienniku elektronicznym!")} \n==================================");
                StudentData();
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
                Console.WriteLine("\nInvalid character. You can only enter 1 or 2 or 'q'. Try again.");
                Console.WriteLine("Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
                //WriteLineColor(errorColor, "\nInvalid character. You can only enter 1 or 2 or 'q'. Try again.");
                //WriteLineColor(errorColor, "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.");
                Console.WriteLine("------------------------------------------------------------------------------------\n");
                Console.WriteLine($"{selectEnglish} \n{selectPolish}");
            }
        }
    }

    static void StudentData()
    {
        Console.WriteLine($"{(currentLanguage == "English" ? "\nEnter the student`s name:" : "\nWpisz imię ucznia:")}");
        while (true)
        {
            nameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(nameOfStudent) && !ContainsDigits(nameOfStudent))
            {
                Console.WriteLine($"{(currentLanguage == "English" ? "\nEnter the student`s surname:" : "\nWpisz nazwisko ucznia:")}");
                break;
            }
            else
            {
                Console.WriteLine($"{(currentLanguage == "English" ? "\nYou didn't enter the student's name or you accidentally used a digit. Try again." : "\nNie wpisałeś imienia ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                //WriteLineColor(errorColor, "You didn't enter the student's name or you accidentally used a digit. Try again.");
                Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student's name:" : "Wpisz imię ucznia:")}");
            }
        }
        while (true)
        {
            surnameOfStudent = Console.ReadLine().Trim();

            if (!string.IsNullOrEmpty(surnameOfStudent) && !ContainsDigits(surnameOfStudent))
            {
                nameOfStudent = char.ToUpper(nameOfStudent[0]) + nameOfStudent.Substring(1).ToLower();
                surnameOfStudent = char.ToUpper(surnameOfStudent[0]) + surnameOfStudent.Substring(1).ToLower();
                Console.WriteLine($"{(currentLanguage == "English" ? $"\nYou add grades for the student: {nameOfStudent} {surnameOfStudent}. Add grade:" : $"\nDodajesz oceny dla ucznia: {nameOfStudent} {surnameOfStudent}. Dodaj ocenę:")}");
                EnterGrade();
                break;
            }
            else
            {
                Console.WriteLine($"{(currentLanguage == "English" ? "You didn't enter the student's surname or you accidentally used a digit. Try again." : "Nie wpisałeś nazwiska ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                //WriteLineColor(errorColor, "You didn't enter the student's surname or you accidentally used a digit. Try again.");
                Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student's surname:" : "Wpisz nazwisko ucznia:")}");
            }
        }

    }

    static void EnterGrade()
    {
        student = new StudentInFile("Anna", "Kos", currentLanguage == "English" ? Language.English : Language.Polish);
        student.GradeAdded += StudentGradeAdded;

        void StudentGradeAdded(object sender, EventArgs args)
        {
            //WriteLineColor(correctColor, "A new grade has been added.");
            Console.WriteLine($"{(currentLanguage == "English" ? "A new grade has been added." : "Dodano nową ocenę.")}");
        }
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "q")
            {
                ShowStatistics();
                break;
            }
            else if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                //WriteLineColor(errorColor, "You must enter a grade. You cannot leave the field blank. Add a rating:");
                Console.WriteLine($"{(currentLanguage == "English" ? "You must enter a grade. You cannot leave the field blank. Add a rating:" : "Musisz wpisać ocenę. Nie możesz zostawić pustego pola. Dodaj ocenę:")}");
            }
            else
            {
                try
                {
                    student.AddGrade(input.Trim());
                }
                catch (Exception e)
                {
                    //WriteLineColor(errorColor, e.Message);
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine($"{(currentLanguage == "English" ? "Add another grade:" : "Dodaj kolejną ocenę:")}");
            }
        }
    }

    static void ShowStatistics()
    {
        var statistics = student.GetStatistics();

        Console.WriteLine($"\nAverage: {statistics.Average:N2}");
        Console.WriteLine($"Min: {statistics.Min}");
        Console.WriteLine($"Max: {statistics.Max}");
        Console.WriteLine(statistics.AverageInWord);
        Console.WriteLine(currentLanguage == "English" ? quitEnglish : quitPolish);
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