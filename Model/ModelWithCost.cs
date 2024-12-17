﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MeterReadingWithCost : MeterReading //Добавляет расчет стоимости
    {
        public double UnitCost { get; set; }
        public double TotalCost { get; set; }

        public MeterReadingWithCost(string resourceType, DateTime date, double value, double unitCost)
            : base(resourceType, date, value)
        {
            UnitCost = unitCost;
            TotalCost = value * unitCost;
        }

        public override void Print()
        {
            try
            {
                Console.WriteLine($"Тип ресурса: {ResourceType}\n" +
                $"Дата выписки: {Date.ToShortDateString()}\n" +
                $"Затрачено (куб.метр): {Value}\n" +
                $"Цена за куб.метр: {UnitCost} рублей\n" +
                $"Итоговый счет: {TotalCost} рублей\n\n");
            }
            catch (Exception e) { Console.WriteLine($"Ошибка: {e.Message}\n"); }
        }
    }
}

