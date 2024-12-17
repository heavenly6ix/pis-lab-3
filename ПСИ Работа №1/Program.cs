using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Schema;
using Model;
using BussinesLogic;


namespace ПИС_Работа__2 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Работа с файлом
            string InputFromFile = Logic.ReadValueInFile("Показания счетчиков.txt");

            //Разбиваем весь текст из файла на строки
            string[] Lines = Logic.SplitTextToLines(InputFromFile);

            //Парсим каждую строку в модель
            List<MeterReading> ListForPrint = Logic.InputReadingLines(Lines);
            
            //Выводим её
            Logic.PrintAll(ListForPrint);

            //Через строку
            //string Input = "2     'Горячая вода'      2024.09.04  15,52   пр.Свободный 26А   '112'";

            ////Разбиваем 
            //string[] InputLines = Logic.SplitTextToLines(Input);
            //List<MeterReading> ListForPrint2 = Logic.InputReadingLines(InputLines);
            ////Выводим строку
            //Logic.PrintAll(ListForPrint2);
        }
    }
}
