using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Пространство имен
/// </summary>
namespace HomeworkTheme06ConsoleApp
{
    /// <summary>
    /// Главная составляющая единица приложения - класс
    /// </summary>
    class Program
    {
        /// <summary>
        /// Метод, считывающий вариант работы приложения
        /// </summary>
        /// <returns>Целое число в диапазоне byte</returns>
        static byte UserOption()
        {
            Console.WriteLine("Выберите один из вариантов работы: " +
                              "\nвведите 1- чтобы вывести данные на экран" +
                              "\nвведите 2 - чтобы заполнить данные и добавить новую запись в конец файла");
            byte userOption = byte.Parse(Console.ReadLine());
            return userOption;
        }

        /// <summary>
        /// Метод выбора одного из вариантов работы приложения
        /// </summary>
        /// <param name="option">Целое число в диапазоне byte</param>
        static void ChoiceOfOptions(byte option)
        {
            switch (option)
            {
                case 1:
                    FileRead(); break;
                case 2:
                    FileWrite();break;
                default: Console.WriteLine("Вы ввели некорректное значение"); break;
            }
        }

        /// <summary>
        /// Метод, считывающий информацию из файла db.txt
        /// </summary>
        static void FileRead()
        {
            FileInfo userFileName = new FileInfo("db.txt");

            if (userFileName.Exists)    //если файл существует, то считываем из него информацию
            {
                 using (StreamReader sr = new StreamReader("db.txt"))
                 {
                string line;
                Console.WriteLine($"{"ID",4}\t{"Датa и время записи",12}\t{" Ф.И.О.",25}\t{"Возраст",4}\t{"Рост",7}\t{"Датa рождения",12}\t{"Место рождения"}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] employees = line.Split('#');
                    Console.WriteLine($"{employees[0],4}\t{employees[1],12}\t{employees[2],25}\t{employees[3],4}\t{employees[4],7}\t{employees[5],12}\t{employees[6]}");
                }
                 }
            }
            else      //иначе выводим соответсвующее сообщение 
            {
                Console.WriteLine($"Файл с именем {userFileName} не найден.");
                ChoiceOfOptions(UserOption());
            }
           
        }
        
        /// <summary>
        /// Метод для записи информации в файл
        /// </summary>
        static void FileWrite()
        {
            FileInfo userFileName = new FileInfo("db.txt");

            if (userFileName.Exists)    //если файл существует, то записываем новую строку в конец файла
            {
                using (StreamWriter sw = new StreamWriter("db.txt",true))
                {
                    char key = 'д';

                    do
                    {
                        string note = string.Empty;
                        Console.WriteLine("\nВведите ID записи: ");
                        note += $"{Console.ReadLine()}"+"#";
                        
                        string nowDate = DateTime.Now.ToShortDateString();
                        string nowTime = DateTime.Now.ToShortTimeString();
                        string now = nowDate +" "+ nowTime;
                        Console.WriteLine($"Дата и время добавления записи {now}");
                        note += $"{now}"+"#";

                        Console.WriteLine("Ф. И. О.: ");
                        note += $"{Console.ReadLine()}" + "#";

                        Console.WriteLine("Возраст: ");
                        note += $"{Console.ReadLine()}" + "#";

                        Console.WriteLine("Рост: ");
                        note += $"{Console.ReadLine()}" + "#";

                        Console.WriteLine("Датa рождения: ");
                        note += $"{Console.ReadLine()}" + "#";

                        Console.WriteLine("Место рождения: ");
                        note += $"{Console.ReadLine()}";

                        sw.WriteLine(note);
                        Console.WriteLine("Продолжить н/д"); key = Console.ReadKey(true).KeyChar;
                    } while (char.ToLower(key) == 'н');
                }
                ChoiceOfOptions(UserOption());
            }
            else      //иначе, создаем файл с именем db.txt в текущей директории
            {
                string fileName = "db.txt";

                using (File.Create(fileName))
                {
                    Console.WriteLine($"Файл {fileName} был успешно создан.");
                }
                ChoiceOfOptions(UserOption());
            }
        }
        
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args">Параметры запуска</param>
        static void Main(string[] args)
        {
            ChoiceOfOptions(UserOption());
            Console.ReadKey();
        }
    }
}
