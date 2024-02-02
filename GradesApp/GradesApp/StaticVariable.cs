namespace GradesApp
{
    public static class StaticVariable
    {
        public static class ProgramConstants
        {
            public static string selectEnglish = "Please select language: press 1 for English or 2 for Polish. If you want to quit, press 'q'.";
            public static string selectPolish = "Proszę wybrać język: naciśnij 1 dla angielskiego lub 2 dla polskiego. Jeśli chcesz zamknąć dziennik naciśnij 'q'.";
            public static string optionsEnglish = "- press 1 to save the grades to the .txt file " +
                "\n- press 2 to store the grades in program memory \n- press 'q' to close the journal \n- if you want to go back to the language selection, press 'x'";
            public static string optionsPolish = "- naciśnij 1 aby zapisać oceny do pliku .txt " +
                    "\n- naciśnij 2 aby zapisać oceny w pamięci programu \n- naciśnij 'q' aby zamknąć dziennik \n- jeśli chcesz wrócić do wyboru języka naciśnij 'x'";

            public static string currentLanguage = "";
            public static string farewellEnglish = "\nSee you soon!";
            public static string farewellPolish = "\nDo zobaczenia!";

            public static string nameOfStudent;
            public static string surnameOfStudent;

            public static StudentBase student;
            public static string saveGradesMethod = "";

            public static ConsoleColor errorColor = ConsoleColor.Red;
            public static ConsoleColor correctColor = ConsoleColor.DarkGreen;
            public static ConsoleColor welcomeColor = ConsoleColor.DarkYellow;
            public static ConsoleColor optionsColor = ConsoleColor.DarkGray;
            public static ConsoleColor studentResultColor = ConsoleColor.DarkCyan;
        }

        public static class ErrorMessages
        {
            public static class English
            {
                public static string IncorrectGrade = "Incorrect grade. You can only add a grade from 1 to 6.";
                public static string IncorrectGradeMultiple = "Incorrect grade. You can only add a grade in multiples of 0.5 or 0,5 (for example: 4.5 or 4,5).";
                public static string StringNotFloat = "A letter has been entered. We enter grades only as numbers from 1 to 6.";
                public static string TooLowOrHighGrade = "There is no such grade. The lowest grade is 1 and the highest is 6.";
            }

            public static class Polish
            {
                public static string IncorrectGrade = "Nieprawidłowa ocena. Możesz dodać ocenę od 1 do 6.";
                public static string IncorrectGradeMultiple = "Nieprawidłowa ocena. Możesz dodać ocenę tylko w wielokrotnościach 0.5 lub 0,5 (na przykład: 4.5 lub 4,5).";
                public static string StringNotFloat = "Została wprowadzona litera. Oceny wprowadzamy tylko w formie cyfr od 1 do 6.";
                public static string TooLowOrHighGrade = "Nie ma takiej oceny. Najniższą oceną jest 1, a najwyższą 6.";
            }
        }
    }
}
