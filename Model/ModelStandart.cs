// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class MeterReading //Показания счетчика
    {
        public string ResourceType;
        public DateTime Date;
        public double Value;

        public MeterReading(string resourceType, DateTime date, double value)
        {
            ResourceType = resourceType;
            Date = date;
            Value = value;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Тип ресурса: {ResourceType}\n" +
                $"Дата выписки: {Date.ToShortDateString()}\n" +
                $"Затрачено (куб.метр): {Value}\n\n");
        }
      

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }
            MeterReading other = (MeterReading)obj;
            return ResourceType == other.ResourceType && Date == other.Date && Value == other.Value;
        }
    }
}
