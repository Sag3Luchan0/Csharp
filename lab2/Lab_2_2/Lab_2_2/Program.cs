using System;

namespace StringExtensions
{
    public static class StringExtensions
    {
        public static string RemoveExtraSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            // Розділяємо рядок на окремі слова, виключаючи порожні простори
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // З'єднуємо слова, використовуючи один пропуск між ними
            string result = string.Join(" ", words);

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string input = "   Розширення    класу    String    C#   ";
            string result = input.RemoveExtraSpaces();
            Console.WriteLine("Результат: '{0}'", result);
        }
    }
}