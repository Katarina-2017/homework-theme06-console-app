using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTheme06ConsoleApp
{
    class Program
    {
        static byte UserOption()
        {
            Console.WriteLine("Выберите один из вариантов работы: " +
                              "\nвведите 1- чтобы вывести данные на экран" +
                              "\nвведите 2 - чтобы заполнить данные и добавить новую запись в конец файла");
            byte userOption = byte.Parse(Console.ReadLine());
            return userOption;
        }
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

        static void FileRead()
        {
            FileInfo userFileName = new FileInfo("db.txt");
            if (userFileName.Exists)
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
            else
            {
                Console.WriteLine($"Файл с именем {userFileName} не найден.");
                ChoiceOfOptions(UserOption());
            }
           
        }

        static void FileWrite()
        {
            FileInfo userFileName = new FileInfo("db.txt");
            if (userFileName.Exists)
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
                        Console.WriteLine("Продожить н/д"); key = Console.ReadKey(true).KeyChar;
                    } while (char.ToLower(key) == 'н');
                }
                ChoiceOfOptions(UserOption());
            }
            else
            {
                
            }
        }

        static void Main(string[] args)
        {
            ChoiceOfOptions(UserOption());
            Console.ReadKey();
        }
    }
}
