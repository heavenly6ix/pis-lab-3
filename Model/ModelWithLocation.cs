// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MeterReadingWithLocation : MeterReading //Добавляет уточнение локации
    {
        public string Location { get; set; }
        public int ApartmentNumber { get; set; }

        public MeterReadingWithLocation(string resourceType, DateTime date, double value, string location, int apartmentNumber)
            : base(resourceType, date, value)
        {
            Location = location;
            ApartmentNumber = apartmentNumber;
        }

        public override void Print()
        {
            Console.WriteLine($"Тип ресурса: {ResourceType}\n" +
                $"Дата выписки: {Date.ToShortDateString()}\n" +
                $"Затрачено(куб.метр): {Value}\n" +
                $"Адрес: {Location}\n" +
                $"Квартира: {ApartmentNumber}\n\n");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }
            MeterReadingWithLocation other = (MeterReadingWithLocation)obj;
            return ResourceType == other.ResourceType && Date == other.Date && Value == other.Value && Location == other.Location && ApartmentNumber == other.ApartmentNumber;
        }
    }
}
