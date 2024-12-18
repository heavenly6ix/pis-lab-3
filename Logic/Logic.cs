// This is a personal academic project. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: https://pvs-studio.com

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Model;

namespace BussinesLogic
{
    public class Logic
    {
        public static string ReadValueInFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static string[] SplitTextToLines(string Input)
        {
            return Input.Split(new char[] { '\n' });        
        }

        public static List<MeterReading> InputReadingLines(string[] lines)
        {
            List<MeterReading> readings = new List<MeterReading>();
            foreach (string line in lines)
            {
                try
                {
                    switch (line[0])
                    {
                        case '0':
                            readings.Add(ToModel(line));
                            break;

                        case '1':
                            readings.Add(ToModelWithCost(line));
                            break;

                        case '2':
                            readings.Add(ToModelWithLocation(line));
                            break;

                        default:
                            throw new Exception("Неверный формат введенных данных");
                    }
                }
                catch (Exception e)
                {
                    readings.Add(new MeterReading(e));
                }
            }
            return readings;
        }
        
        public static MeterReading ToModel(string lineParse)
        {
            List<string> parseList = new List<string>();

            Regex resourceType = new Regex(@"\'\w* \w*\'");
            MatchCollection resourceTypeMatches = resourceType.Matches(lineParse);
            foreach (Match match in resourceTypeMatches) { parseList.Add(match.Value); }

            Regex date = new Regex(@"\d*\.\d*\.\d*");
            MatchCollection dateMatches = date.Matches(lineParse);
            foreach (Match match in dateMatches) { parseList.Add(match.Value); }

            Regex value = new Regex(@"\w*,\w*");
            MatchCollection valueMatches = value.Matches(lineParse);
            foreach (Match match in valueMatches) { parseList.Add(match.Value); }

            MeterReading Info = new MeterReading(
                            parseList[0].Trim('\''),
                            Convert.ToDateTime(parseList[1]),
                            Convert.ToDouble(parseList[2])
                            );
            return Info;
        }

        public static MeterReading ToModelWithCost(string lineParse)
        {
            List<string> parseList = new List<string>();

            Regex resourceType = new Regex(@"\'\w* \w*\'");
            MatchCollection resourceTypeMatches = resourceType.Matches(lineParse);
            foreach (Match match in resourceTypeMatches) { parseList.Add(match.Value); }

            Regex date = new Regex(@"\d*\.\d*\.\d*");
            MatchCollection dateMatches = date.Matches(lineParse);
            foreach (Match match in dateMatches) { parseList.Add(match.Value); }

            Regex value = new Regex(@"\w*,\w*");
            MatchCollection valueMatches = value.Matches(lineParse);
            foreach (Match match in valueMatches) { parseList.Add(match.Value); }

            Regex cost = new Regex(@"\'\d*\'");
            MatchCollection costMatches = cost.Matches(lineParse);
            foreach (Match match in costMatches) { parseList.Add(match.Value); }

            MeterReadingWithCost Info = new MeterReadingWithCost(
                            parseList[0].Trim('\''),
                            Convert.ToDateTime(parseList[1]),
                            Convert.ToDouble(parseList[2]),
                            Convert.ToDouble(parseList[3].Trim('\''))
                            );
            return Info;
        }

        public static MeterReading ToModelWithLocation(string lineParse)
        {
            List<string> parseList = new List<string>();

            Regex resourceType = new Regex(@"\'\w* \w*\'");
            MatchCollection resourceTypeMatches = resourceType.Matches(lineParse);
            foreach (Match match in resourceTypeMatches) { parseList.Add(match.Value); }

            Regex date = new Regex(@"\d*\.\d*\.\d*");
            MatchCollection dateMatches = date.Matches(lineParse);
            foreach (Match match in dateMatches) { parseList.Add(match.Value); }

            Regex value = new Regex(@"\w*,\w*");
            MatchCollection valueMatches = value.Matches(lineParse);
            foreach (Match match in valueMatches) { parseList.Add(match.Value); }

            Regex location = new Regex(@"\w*\.\w* \d*\w");
            MatchCollection locationMatches = location.Matches(lineParse);
            foreach (Match match in locationMatches) { parseList.Add(match.Value); }

            Regex appartment = new Regex(@"\'\d*\'");
            MatchCollection appartmentMatches = appartment.Matches(lineParse);
            foreach (Match match in appartmentMatches) { parseList.Add(match.Value); }

            MeterReadingWithLocation Info = new MeterReadingWithLocation(
                            parseList[0].Trim('\''),
                            Convert.ToDateTime(parseList[1]),
                            Convert.ToDouble(parseList[2]),
                            Convert.ToString(parseList[3]),
                            Convert.ToInt32(parseList[4].Trim('\''))
                            );

            return Info;
        }

        public static void PrintAll(List<MeterReading> ListForPrint)
        {
            foreach (MeterReading value in ListForPrint)
            {
                value.Print();
            }
        }
    }
}
