// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Runtime.CompilerServices;

namespace BussinesLogic.Tests
{
    [TestClass()]
    public class LogicTests
    {   
        //[TestMethod()]
        //public void InputReadingLines_Hendler()
        //{
        //    //Arrange
        //    string input = "0       'Горячая вода'    2024.10.06         10,5";
        //    MeterReading goodLines = new MeterReading("Горячая вода", Convert.ToDateTime("2024.10.06"), 10.5);

        //    //Act
        //    MeterReading result = Logic.ToModel(input);

        //    //Addert
        //    Assert.AreEqual(result, goodLines);
        //}
        

        [TestMethod()]
        public void ToModelWithCost()
        {
            //Arrange
            string input = "1  '200'   'Горячая вода'   13,56   2024.07.08   ";
            MeterReadingWithCost goodLines = new MeterReadingWithCost("Горячая вода", Convert.ToDateTime("2024.07,08"), 13.56, 200);

            //Act
            MeterReadingWithCost result = (MeterReadingWithCost)Logic.ToModelWithCost(input);

            //Assert
            Assert.AreEqual(result, goodLines);
        }

        [TestMethod()]
        public void ToModelWithLocation()
        {
            //Arrange
            string input = "    14,00   ул.Пушкина 28   'Холодная вода' 2024.07.09     '12' ";
            MeterReadingWithLocation goodLines = new MeterReadingWithLocation("Холодная вода", Convert.ToDateTime("2024.07,09"), 14.00, "ул.Пушкина 28", 12);

            //Act
            MeterReadingWithLocation result = (MeterReadingWithLocation)Logic.ToModelWithLocation(input);

            //Assert
            Assert.AreEqual(result, goodLines);
        }
    }
}