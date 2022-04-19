namespace Print
{
    public static class Print
    {
        public static void Red(string inn)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inn);
            Reset();
        }

        public static void Green(string inn)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(inn);
            Reset();
        }

        public static void Yellow(string inn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(inn);
            Reset();
        }








        private static void Reset() { Console.ResetColor(); }
    }
}