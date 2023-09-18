using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практик_03
{
    class Program
    {

        static void Zad1()
        {

            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 3, 4, 5, 6, 7 };

            int[] commonElements = GetElements(array1, array2);

            Console.WriteLine("Общие элементы массивов без повторений:");
            foreach (int element in commonElements)
            {
                Console.WriteLine(element);
            }
        }

        static int[] GetElements(int[] array1, int[] array2)
        {
            // Создаем массив для хранения общих элементов.
            int[] commonElements = new int[Math.Min(array1.Length, array2.Length)];
            int count = 0;

            // Перебираем элементы первого массива.
            foreach (int element1 in array1)
            {
                // Проверяем, есть ли такой элемент во втором массиве и в массиве общих элементов.
                if (Array.Exists(array2, element2 => element2 == element1) && !Array.Exists(commonElements, element => element == element1))
                {
                    commonElements[count] = element1;
                    count++;
                }
            }

            // Создаем новый массив с точным размером.
            int[] result = new int[count];
            Array.Copy(commonElements, result, count);

            return result;

        }

        static void Zad2()
        {

            Console.WriteLine("Введите предложение:");
            string input = Console.ReadLine();

            int wordCount = CountWords(input);

            Console.WriteLine($"Количество слов в предложении: {wordCount}");
        }

        static int CountWords(string input)
        {
            // Разделители слов - пробел, запятая, точка с запятой и т.д.
            char[] delimiters = { ' ', ',', ';', '.', '!', '?' };

            // Разбиваем предложение на слова, используя заданные разделители.
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            // Возвращаем количество слов в предложении.
            return words.Length;

        }
        static void Zad3()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            bool isPalindrome = true;

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("Введенная строка является палиндромом.");
            }
            else
            {
                Console.WriteLine("Введенная строка не является палиндромом.");
            }
        }
        static void Zad4()
        {

            // Создаем генератор случайных чисел.
            Random random = new Random();

            // Создаем двумерный массив 5x5 и заполняем его случайными числами от -100 до 100.
            int[,] array = new int[5, 5];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    array[i, j] = random.Next(-100, 101); // Генерируем числа от -100 до 100.
                }
            }

            // Находим минимальный и максимальный элементы массива.
            int minValue = array[0, 0];
            int maxValue = array[0, 0];
            int minRow = 0, minCol = 0, maxRow = 0, maxCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] < minValue)
                    {
                        minValue = array[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (array[i, j] > maxValue)
                    {
                        maxValue = array[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            // Находим сумму элементов между минимальным и максимальным элементами.
            int sum = 0;
            int startRow = Math.Min(minRow, maxRow);
            int endRow = Math.Max(minRow, maxRow);
            int startCol = Math.Min(minCol, maxCol);
            int endCol = Math.Max(minCol, maxCol);

            for (int i = startRow + 1; i < endRow; i++)
            {
                for (int j = startCol + 1; j < endCol; j++)
                {
                    sum += array[i, j];
                }
            }

            // Выводим результаты.
            Console.WriteLine("Двумерный массив:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Минимальный элемент: {minValue} (строка {minRow}, столбец {minCol})");
            Console.WriteLine($"Максимальный элемент: {maxValue} (строка {maxRow}, столбец {maxCol})");
            Console.WriteLine($"Сумма элементов между минимальным и максимальным элементами: {sum}");

        }

        static void Zad5()
        {

            Console.WriteLine("Введите текст:");
            string input = Console.ReadLine();

            char maxChar = '\0'; // Инициализируем символ как пустой символ.
            int maxCount = 0;   // Инициализируем количество символов как 0.
            char currentChar = '\0';
            int currentCount = 0;

            foreach (char c in input)
            {
                if (c == currentChar)
                {
                    currentCount++;
                }
                else
                {
                    currentChar = c;
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                    maxChar = currentChar;
                }
            }

            if (maxCount > 1)
            {
                Console.WriteLine($"Наибольшее количество идущих подряд одинаковых символов: '{maxChar}', количество: {maxCount}");
            }
            else
            {
                Console.WriteLine("В тексте нет повторяющихся символов подряд.");
            }

        }

        static void Zad6()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            int uniqueLetterCount = 0;
            bool[] letterExists = new bool[32]; // Размер массива соответствует количеству русских букв.

            foreach (char c in input)
            {
                if (char.IsUpper(c) && c >= 'А' && c <= 'Я')
                {
                    int index = c - 'А'; // Вычисляем индекс буквы в массиве.
                    if (!letterExists[index])
                    {
                        letterExists[index] = true;
                        uniqueLetterCount++;
                    }
                }
            }

            Console.WriteLine($"Количество различных букв: {uniqueLetterCount}");

        }
        static void Zad7()
        {

            Console.WriteLine("Введите строку длиной 20 символов:");
            string input = Console.ReadLine();

            if (input.Length != 20)
            {
                Console.WriteLine("Введенная строка должна быть длиной 20 символов.");
            }
            else
            {
                int digitCount = 0;

                foreach (char c in input)
                {
                    if (char.IsDigit(c))
                    {
                        digitCount++;
                    }
                }

                Console.WriteLine($"Количество цифр в строке: {digitCount}");
            }
        }
        static void Zad8()
        {
            Console.WriteLine("Введите текст из 20 символов:");
            string input = Console.ReadLine();

            char[] nameChars = "Ваше_имя".ToCharArray(); // Замените "Ваше_имя" на ваше имя

            if (input.Length != 20)
            {
                Console.WriteLine("Нет имени");
            }
            else
            {
                bool isNamePossible = true;

                for (int i = 0; i < nameChars.Length; i++)
                {
                    if (input[i] != nameChars[i])
                    {
                        isNamePossible = false;
                        break;
                    }
                }

                if (isNamePossible)
                {
                    Console.WriteLine("Поздравляем! Вы ввели ваше имя.");
                }
                else
                {
                    Console.WriteLine("Нет имени");
                }
            }

        }
        static void Zad9()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            int count = 0;
            bool isWord = false;
            char firstChar = '\0';

            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    if (!isWord)
                    {
                        isWord = true;
                        firstChar = c;
                    }
                }
                else if (isWord)
                {
                    if (c == firstChar)
                    {
                        count++;
                    }
                    isWord = false;
                }
            }

            Console.WriteLine($"Количество слов с совпадающими первым и последним символами: {count}");
        }
        static void Zad10()
        {
            Console.WriteLine("Введите малую русскую букву:");
            char lowercaseChar = Console.ReadKey().KeyChar;

            if (lowercaseChar >= 'а' && lowercaseChar <= 'я')
            {
                char uppercaseChar = (char)(lowercaseChar - ('а' - 'А'));
                Console.WriteLine($"\nСоответствующая большая буква: {uppercaseChar}");
            }
            else
            {
                Console.WriteLine("\nЭто не малая русская буква.");
            }

        }

        static void Main(string[] args)
        {

           // Zad1();
           // Zad2();
           // Zad3();
           // Zad4();
           // Zad5();
           // Zad6();
           // Zad7();
           // Zad8();
           // Zad9();
           // Zad10();
        }
    }
}

    
   



     

      

