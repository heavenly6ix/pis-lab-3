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
        [TestMethod()]
        public void InputReadingLines_Hendler()
        {
            //Arrange
            string input = "0       'Горячая вода'    2024.10.06         10,5";
            MeterReading goodLines = new MeterReading("Горячая вода", Convert.ToDateTime("2024.10.06"), 10.5);

            //Act
            MeterReading result = Logic.ToModel(input);

            //Addert
            Assert.AreEqual(result, goodLines);
        }

        [TestMethod()]
        public void InputReadingLines_Exception()
        {
            // Arrange
            string[] lines = {
                " 'Холодная вода' ",
                "1  ",
                "  ",
                " 'Холодная вода'      2024.11.15   15,3              '50' "
            };

            // Act
            List<MeterReading> results = Logic.InputReadingLines(lines);

            // Assert
            for (int i = 0; i == results.Count(); i++)
            {
                if (results[i].Exception != null)
                {
                    throw new Exception($"Test failed: at index {i}, no exception was captured.");
                }
            }
        }

        [TestMethod()]
        public void ToModel()
        {
            //Arrange
            string[] lines = {
                "'Холодная вода' 2024.07.07 11,28"
            };

            //Act
            MeterReading result = null;
            foreach (string line in lines)
            {
                result = Logic.ToModel(line);
            }

            //Assert
            string[] Values =
            {
                result.ResourceType, result.Date.ToString("yyyy-MM-dd"), result.Value.ToString("F2")
            };
            string[] expectedValues =
            {
                "Холодная вода", "2024-07-07", "11,28"
            };

            for (int i = 0; i<expectedValues.Length; i++)
            {
                if (Values[i] != expectedValues[i])
                {
                    throw new Exception($"Test failed: at index {i}, expected '{expectedValues[i]}', but got '{Values[i]}'.");
                }
            }
        }

        [TestMethod()]
        public void ToModelWithPermutation()
        {
            //Arrange
            string[] lines = {
                "   2024.07.07  11,28   'Холодная вода'"
            };

            //Act
            MeterReading result = null;
            foreach (string line in lines)
            {
                result = Logic.ToModel(line);
            }

            //Assert
            string[] Values =
            {
                result.ResourceType, result.Date.ToString("yyyy-MM-dd"), result.Value.ToString("F2")
            };
            string[] expectedValues =
            {
                "Холодная вода", "2024-07-07", "11,28"
            };

            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (Values[i] != expectedValues[i])
                {
                    throw new Exception($"Test failed: at index {i}, expected '{expectedValues[i]}', but got '{Values[i]}'.");
                }
            }
        }

        [TestMethod()]
        public void ToModelWithCost()
        {
            //Arrange
            string[] lines = {
                "  '200'   'Горячая вода'   13,56   2024.07.08   "
            };

            //Act
            MeterReadingWithCost result = null;
            foreach (string line in lines)
            {
                result = (MeterReadingWithCost)Logic.ToModelWithCost(line);
            }

            //Assert
            string[] Values =
            {
                result.ResourceType, result.Date.ToString("yyyy-MM-dd"), result.Value.ToString("F2"), result.UnitCost.ToString(), result.TotalCost.ToString()
            };
            string[] expectedValues =
            {
                "Горячая вода", "2024-07-08", "13,56", "200", "2712"
            };

            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (Values[i] != expectedValues[i])
                {
                    throw new Exception($"Test failed: at index {i}, expected '{expectedValues[i]}', but got '{Values[i]}'.");
                }
            }
        }

        [TestMethod()]
        public void ToModelWithLocation()
        {
            //Arrange
            string[] lines = {
                "    14,00   ул.Пушкина 28   'Холодная вода' 2024.07.09     '12' "
            };

            //Act
            MeterReadingWithLocation result = null;
            foreach (string line in lines)
            {
                result = (MeterReadingWithLocation)Logic.ToModelWithLocation(line);
            }

            //Assert
            string[] Values =
            {
                result.ResourceType, result.Date.ToString("yyyy-MM-dd"), result.Value.ToString("F2"), result.Location, result.ApartmentNumber.ToString()
            };
            string[] expectedValues =
            {
                "Холодная вода", "2024-07-09", "14,00", "ул.Пушкина 28", "12"
            };

            for (int i = 0; i < expectedValues.Length; i++)
            {
                if (Values[i] != expectedValues[i])
                {
                    throw new Exception($"Test failed: at index {i}, expected '{expectedValues[i]}', but got '{Values[i]}'.");
                }
            }
        }
    }
}