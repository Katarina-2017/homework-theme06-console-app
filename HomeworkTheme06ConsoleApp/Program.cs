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
                Console.WriteLine($"{"ID",4}\t{"Датa и время записи",12}\t{" Ф.И.О.",25}\t{"Возраст",4}\t{"Рост",7}\t{"Датa рождения",12}\t{"Место рождения"}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] employees = line.Split('#');
                    Console.WriteLine($"{employees[0],4}\t{employees[1],12}\t{employees[2],25}\t{employees[3],4}\t{employees[4],7}\t{employees[5],12}\t{employees[6]}");
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
