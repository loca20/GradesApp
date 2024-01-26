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

    static StudentBase student;
    static string saveGradesMethod = "";

    static ConsoleColor errorColor = ConsoleColor.Red;
    static ConsoleColor correctColor = ConsoleColor.DarkGreen;


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
                HowToSaveGrades();
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
        Console.WriteLine($"\n{(currentLanguage == "English" ? "How would you like to store your added grades? \n- press 1 to save the grades to the .txt file \n- press 2 to store the grades in program memory \n- press 'q' to close the journal \n- if you want to go back to the language selection, press 'x'" : "Jak chcesz przechowywać dodane oceny? \n- naciśnij 1 aby zapisać oceny do pliku .txt \n- naciśnij 2 aby zapisać oceny w pamięci programu \n- naciśnij 'q' aby zamknąć dziennik \n- jeśli chcesz wrócić do wyboru języka naciśnij 'x'")}");
        while (true)
        {
            var saveGrades = Console.ReadLine();
            if (saveGrades == "1" || saveGrades == "2")
            {
                saveGradesMethod = saveGrades == "1" ? "StudentInFile" : "StudentInMemory";
                StudentData();
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
                break;
            }
            else {
                WriteLineColor(errorColor, $"\n{(currentLanguage == "English" ? "Invalid character. You can only enter 1 or 2 or 'q'. Try again." : "Wprowadzono nieprawidłowy znak. Możesz wprowadzić jedynie 1 lub 2 lub 'q'. Spróbuj ponownie.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? "- press 1 to save the grades to the .txt file \n- press 2 to store the grades in program memory \n- press 'q' to close the journal" : "- naciśnij 1 aby zapisać oceny do pliku .txt \n- naciśnij 2 aby zapisać oceny w pamięci programu \n- naciśnij 'q' aby zamknąć dziennik")}");
            };
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
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "\nYou didn't enter the student's name or you accidentally used a digit. Try again." : "\nNie wpisałeś imienia ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
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
                string fileName = $"{nameOfStudent}_{surnameOfStudent}.txt";
                if (saveGradesMethod == "StudentInFile")
                {
                    student = new StudentInFile(nameOfStudent, surnameOfStudent, currentLanguage == "English" ? Language.English : Language.Polish, fileName);
                }
                else
                {
                    student = new StudentInMemory(nameOfStudent, surnameOfStudent, currentLanguage == "English" ? Language.English : Language.Polish);
                }

                Console.WriteLine($"{(currentLanguage == "English" ? $"\nYou add grades for the student: {nameOfStudent} {surnameOfStudent}. Add grade:" : $"\nDodajesz oceny dla ucznia: {nameOfStudent} {surnameOfStudent}. Dodaj ocenę:")}");
                EnterGrade();
                break;
            }
            else
            {
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "You didn't enter the student's surname or you accidentally used a digit. Try again." : "Nie wpisałeś nazwiska ucznia lub przypadkowo użyłeś cyfry. Spróbuj jeszcze raz.")}");
                Console.WriteLine($"{(currentLanguage == "English" ? "Enter the student's surname:" : "Wpisz nazwisko ucznia:")}");
            }
        }

    }

    static void EnterGrade()
    {
        string fileName = $"{nameOfStudent}_{surnameOfStudent}.txt";
        if (saveGradesMethod == "StudentInFile")
        {
            student = new StudentInFile("Anna", "Kos", currentLanguage == "English" ? Language.English : Language.Polish, fileName);
        }
        else
        {
            student = new StudentInMemory("Anna", "Kos", currentLanguage == "English" ? Language.English : Language.Polish);
        }
        student.GradeAdded += StudentGradeAdded;

        void StudentGradeAdded(object sender, EventArgs args)
        {
            WriteLineColor(correctColor, $"{(currentLanguage == "English" ? "A new grade has been added." : "Dodano nową ocenę.")}");
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
                WriteLineColor(errorColor, $"{(currentLanguage == "English" ? "You must enter a grade. You cannot leave the field blank." : "Musisz wpisać ocenę. Nie możesz zostawić pustego pola.")}");
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
                Console.WriteLine($"{(currentLanguage == "English" ? "Add another grade:" : "Dodaj kolejną ocenę:")}");
            }
        }
    }

    static void ShowStatistics()
    {
        var statistics = student.GetStatistics();

        Console.WriteLine($"\n{(currentLanguage == "English" ? "Average" : "Średnia")}: {statistics.Average:N2}");
        Console.WriteLine($"{(currentLanguage == "English" ? "Lowest grade" : "Najniższa ocena")}: {statistics.Min}");
        Console.WriteLine($"{(currentLanguage == "English" ? "Highest grade" : "Najwyższa ocena")}: {statistics.Max}");
        Console.WriteLine($"{(currentLanguage == "English" ? "Final grade" : "Ocena końcowa")}: {statistics.AverageInWord}");
        Console.WriteLine(currentLanguage == "English" ? quitEnglish : quitPolish);
    }

    static void CloseApp()
    {
        Console.WriteLine(currentLanguage == "English" ? farewellEnglish : farewellPolish);
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