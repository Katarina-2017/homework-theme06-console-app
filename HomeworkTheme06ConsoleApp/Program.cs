using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTheme06ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите один из вариантов работы: " +
                              "\nвведите 1- чтобы вывести данные на экран" +
                              "\nвведите 2 - чтобы заполнить данные и добавить новую запись в конец файла");
            byte userOption = byte.Parse(Console.ReadLine());

            switch (userOption)
            {
                case 1:break;
                case 2:break;
                default:Console.WriteLine("Вы ввели некорректное значение");break;
            }
            Console.ReadKey();
        }
    }
}
