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
        static void FileRead()
        {
            using (StreamReader sr = new StreamReader("db.txt"))
            {
                string line;
                Console.WriteLine($"{"ID"}\t{"Датa и время записи"}\t{" Ф.И.О.",20}\t{"Возраст"}\t{"Рост"}\t{"Датa рождения"}\t{"Место рождения"}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] employees = line.Split('#');
                    Console.WriteLine($"{employees[0]}\t{employees[1]}\t{employees[2]}\t{employees[3]}\t{employees[4]}\t{employees[5]}\t{employees[6]}");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Выберите один из вариантов работы: " +
                              "\nвведите 1- чтобы вывести данные на экран" +
                              "\nвведите 2 - чтобы заполнить данные и добавить новую запись в конец файла");
            byte userOption = byte.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 1:FileRead(); break;
                case 2:break;
                default:Console.WriteLine("Вы ввели некорректное значение");break;
            }
            Console.ReadKey();
        }
    }
}
