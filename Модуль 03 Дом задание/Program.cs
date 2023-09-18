using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Модуль_03_Дом_задание
{


    class Program
    {
        static void Zad1()
        {
            //  массив целых чисел
            int[] numbers = { 1, 2, 3, 4, 5 };

            // вывод массив
            Console.WriteLine(string.Join(", ", numbers));
            Console.ReadKey();

        }

        static void Zad2()
        {
            Console.Write("Массив состоит и 5 чисел. Введите  Индекс элемента, который нужно удалить");
            // Создаем массив целых чисел
            int[] numbers = { 1, 2, 3, 4, 5 };


            int indexToDelete = Convert.ToInt32(Console.ReadLine());
            // Индекс элемента, который нужно удалить


            // Проверяем, что индекс находится в пределах массива
            if (indexToDelete >= 0 && indexToDelete < numbers.Length)
            {
                // Создаем новый массив с уменьшенным размером
                int[] newArray = new int[numbers.Length - 1];

                // Копируем элементы до удаляемого элемента
                for (int i = 0, j = 0; i < numbers.Length; i++)
                {
                    if (i != indexToDelete)
                    {
                        newArray[j] = numbers[i];
                        j++;
                    }
                }

                // Обновляем исходный массив
                numbers = newArray;

                Console.WriteLine("Массив после удаления элемента:");
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Неверный индекс для удаления элемента.");
            }
        }

        static void Zad3() //Вставить элемент в массив по индексу
        {

            int[] numbers = { 1, 2, 3, 4, 5 };

            // Индекс, по которому нужно вставить элемент.
            int Vstavit = 2;

            // Элемент, который нужно вставить.
            int elementVstavit = 10;

            // Проверяем, что индекс находится в допустимых пределах массива.
            if (Vstavit >= 0 && Vstavit < numbers.Length)
            {
                // Присваиваем новое значение по указанному индексу.
                numbers[Vstavit] = elementVstavit;

                // Выводим результат.
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }

        static void Zad4() //Удалить те элементы массива, которые встречаются в нем ровно два раза
        {

            int[] numbers = { 1, 2, 2, 3, 4, 4, 5, 6, 6 };

            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i != j && numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }
                if (count != 2)
                {
                    Console.WriteLine(numbers[i]);
                }
            }
        }

        static void Zad5()
        {

            string input = "Я ел Арбузы и бежал за слоном.";

            // Разбиваем строку на слова по пробелам.
            string[] words = input.Split(' ');

            // Получаем последнее слово.
            string Word = words.LastOrDefault();

            if (Word != null)
            {
                // Получаем уникальные буквы из последнего слова.
                char[] uniquelbuk = Word.Distinct().ToArray();

                // Формируем новую строку, исключая слова, содержащие буквы из последнего слова.
                string result = string.Join(" ", words.Where(word => !uniquelbuk.Any(letter => word.Contains(letter))));

                Console.WriteLine(result);
            }
        }

        static void Zad6()
        {

            int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);

            // Определяем главную диагональ и обнуляем строки, на пересечении которых с ней стоит четный элемент.
            for (int i = 0; i < numRows; i++)
            {
                if (matrix[i, i] % 2 == 0)
                {
                    for (int j = 0; j < numCols; j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            // Выводим результат.
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Zad7()
        {

            Console.WriteLine("Введите текст. Для завершения введите точку.");

            char input;
            int spaceCount = 0;

            do
            {
                input = Console.ReadKey().KeyChar;

                if (input == ' ')
                {
                    spaceCount++;
                }

            } while (input != '.');

            Console.WriteLine("\nКоличество введенных пробелов: " + spaceCount);
        }
        static void Zad8()
        {
            Console.WriteLine("Введите номер трамвайного билета (6-значное число):");
            string input = Console.ReadLine();

            if (input.Length == 6 && int.TryParse(input, out int ticket))
            {
                int sumFirst = GetSum(ticket / 1000);
                int sumLast = GetSum(ticket % 1000);

                if (sumFirst == sumLast)
                {
                    Console.WriteLine("Этот билет считается счастливым!");
                }
                else
                {
                    Console.WriteLine("Этот билет не считается счастливым.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 6-значное число.");
            }
        }

        static int GetSum(int number)
        {
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }

            return sum;
        }
        static void Zad9()
        {
            string word = "класс";
            char[] wordArray = word.ToCharArray();

            for (int i = 0; i < wordArray.Length - 1; i++)
            {
                if (wordArray[i] == wordArray[i + 1])
                {
                    wordArray[i] = '1';
                    wordArray[i + 1] = '1';
                }
            }

            string result = new string(wordArray);
            Console.WriteLine(result);

        }
        static void Zad10()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            int digitCount = CountDigits(input);

            Console.WriteLine($"Количество цифр в строке: {digitCount}");
        }

        static int CountDigits(string input)
        {
            int digitCount = 0;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    digitCount++;
                }
            }

            return digitCount;
        }
        static void Zad11()
        {
            Console.WriteLine("Введите текст:");
            string text = Console.ReadLine();

            bool containsOne = ContainsWord(text, "one");

            if (containsOne)
            {
                Console.WriteLine("Слово 'one' найдено в тексте.");
            }
            else
            {
                Console.WriteLine("Слово 'one' не найдено в тексте.");
            }
        }

        static bool ContainsWord(string text, string word)
        {
            string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string w in words)
            {
                if (string.Equals(w, word, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    
        static void Zad12()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            char vstrecha = 'P';
            int count = 0;

            foreach (char c in input)
            {
                if (c == 'P' || c == 'p') // Учитываем как большие, так и маленькие буквы.
                {
                    count++;
                }
            }

            Console.WriteLine($"Буква '{vstrecha}' встречается {count} раз.");
        
    }
        static void Zad13()
        {

            
                Console.WriteLine("Введите текст:");
                string input = Console.ReadLine();

                // Создаем массив слов, разбивая строку по пробелам.
                string[] words = input.Split(' ');

                Console.WriteLine($"Количество слов в строке: {words.Length}");
                Console.WriteLine("Слова в столбик:");

                // Выводим слова в столбик, перебирая массив слов.
                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
            }
        
        static void Zad14()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            // Разбиваем строку на слова, используя пробел в качестве разделителя.
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            // Перебираем каждое слово и проверяем первый и последний символ.
            foreach (string word in words)
            {
                if (word.Length > 0 && word[0] == word[word.Length - 1])
                {
                    count++;
                }
            }

            Console.WriteLine($"Количество слов, у которых первый и последний символы совпадают: {count}");
        
    }
          
        static void Zad15()
        {

            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            // Разбиваем строку на слова, используя пробел в качестве разделителя.
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            char openBracket = '[';
            char closeBracket = ']';

            foreach (string word in words)
            {
                if (word.Length >= 2 && word[0] == word[word.Length - 1] && char.IsLetter(word[0]))
                {
                    // Заменяем слово в строке, добавляя квадратные скобки.
                    input = input.Replace(word, $"{openBracket}{word}{closeBracket}");
                }
            }

            Console.WriteLine("Строка с выделенными словами:");
            Console.WriteLine(input);
        }
            static void Main(string[] args)
        {
            //Zad1();
            //Zad2();
            //Zad3();
            //Zad4();
           // Zad5();
           // Zad6();
         //   Zad7();
        //    Zad8();
        //    Zad9();
        //    Zad10();
         //   Zad11();
            Zad12();
            Zad13();
            Zad14();
            Zad15();
        }


    }

}
