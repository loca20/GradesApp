namespace GradesApp
{
    public class Statistics
    {
        internal Language language;
        public float Min { get; private set; }
        public float Max { get; private set; }
        public float Sum { get; private set; }
        public int Count { get; private set; }
        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }
        public string AverageInWord
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 5.61:
                        return (language == Language.English) ? "excellent" : "celujący";
                    case var average when average >= 4.76:
                        return (language == Language.English) ? "very good" : "bardzo dobry";
                    case var average when average >= 3.76:
                        return (language == Language.English) ? "good" : "dobry";
                    case var average when average >= 2.76:
                        return (language == Language.English) ? "satisfactory" : "dostateczny";
                    case var average when average >= 1.76:
                        return (language == Language.English) ? "needs improvement" : "mierny";
                    default:
                        return (language == Language.English) ? "fail" : "niedostateczny";
                }
            }
        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }
        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(grade, this.Min);
            this.Max = Math.Max(grade, this.Max);
        }
    }
}
