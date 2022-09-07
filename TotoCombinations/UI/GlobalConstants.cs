namespace TotoProject.UI
{
    public static class GlobalConstants
    {       
        public static string Matrix10x100 = "That is how matrix 10x100 looks like :)\r\n";

        public static string NeedARecord = "\r\nDo you want to make a record?!";

        public static string Answer = "Press:\"y\" for YES to proceed with the record, otherwise - no record will be made!";

        public static string TheHundredCombinations = "\r\nThe lucky numbers of next 100 combinations are....\r\n";

        public static string LuckyNumberRecorded = "Lucky numbers have been recorded!";

        public static string NumbersLost = "Lucky numbers were not recorded and will be permanently lost!";

        public static string UnsortedOccurrances = "Unsorted occurrances/repetitions of numbers from 1 to {0}";

        public static string SortedOccurrances = "Sorted occurrances/repetitions of numbers ordered by Descending (Most occurrances first!)";

        public static string SmallTiers = $"\r\n{new string('-', UnsortedOccurrances.Length)}";

        public static string LongTiers = $"\r\n{new string('-', SortedOccurrances.Length)}";

        public static string PrintRowWithCombinations = "No:{0}Lucky row:{1},with combination {2} ";

        public static string EnterNumberPlease = "Моля въведете число , а не Текст  >:(  !!!";

        public static string FinalReportInfo = "Случайна комбинация от {0} числа,формирана от {1} произволни цифри," +
                                               "съединявайки първите {2} най-повтарящи се цифри\r\nвъв произволни 100 от {3} комбинации.\r\n";

        public static string PreferredTotoType = "Моля изберете предпочитание за ТОТО [6x49] или [5x35]\r\n" +
                                                 "Въведете число 5 ( за тото 5х35) или 6 (за тото 6х49)";
    }
}
