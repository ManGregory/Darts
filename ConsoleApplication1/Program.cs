using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DartsLogic;
using HtmlAgilityPack;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var desiredScore = 2;
            while (desiredScore <= 170)
            {
                var possibleSeries = DartsEnding.GetPossibleEndings(desiredScore);
                if (!possibleSeries.Any())
                {
                    Console.WriteLine("{0} - impossible", desiredScore);   
                }
                {
                    foreach (var serie in possibleSeries)
                    {
                        Console.WriteLine("{0} - {1}", desiredScore, serie.ToString(true));
                    }
                }
                desiredScore++;
            }
            Console.ReadLine();
        }

        private static void GetEndings()
        {
            var htmlText = string.Empty;
            using (var webC = new WebClient())
            {
                htmlText = webC.DownloadString("http://ricksmith.ca/Darts/dartsouts.htm");
            }
            var html = new HtmlDocument();
            html.LoadHtml(htmlText);
            var allTd = html.DocumentNode.SelectNodes("//tr[@class='tablebody']/td[position() = 2]");
            foreach (var td in allTd)
            {
                ParseScore(td.InnerText.Trim());
                Console.WriteLine(td.InnerText.Trim());
            }
        }

        private static void ParseScore(string innerText)
        {
            if (string.IsNullOrWhiteSpace(innerText)) return;
            var sb = new StringBuilder();
            var scoreGroups = innerText.Split(new[] {"or"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var scoreGroup in scoreGroups)
            {
                sb.Append("serie.Add(new DartsSerie(new [] {");
                var throwGroups = scoreGroup.Trim().Split(new[] {"-"}, StringSplitOptions.RemoveEmptyEntries);
                sb.Append(string.Join(",", throwGroups.Select(GetDartsThrowText)));
                sb.Append("}));" + Environment.NewLine);
            }
            System.IO.File.AppendAllText("1.txt", sb.ToString());
        }

        private static string GetDartsThrowText(string throwGroup, int index)
        {
            return string.Format("new DartsThrow({0}, {1})", index + 1, GetScoreText(throwGroup));
        }

        private static string GetScoreText(string s)
        {
            var res = string.Empty;
            var num = -1;
            if (int.TryParse(s, out num))
            {
                res = string.Format("new DartsScore({0}, {1})", num, 1);
            }
            else
            {
                if (s.Length >= 2)
                {
                    if (s[0] == 'T')
                    {
                        res = string.Format("new DartsScore({0}, {1})", string.Join("", s.Skip(1)), 3);
                    }
                    else if (s[0] == 'D')
                    {
                        res = s[1] == 'B'
                            ? string.Format("new DartsScore(25, 2)")
                            : string.Format("new DartsScore({0}, {1})", string.Join("", s.Skip(1)), 2);
                    }
                    else if (s[0] == 'S')
                    {
                        res = s[1] == 'B'
                            ? string.Format("new DartsScore(25, 1)")
                            : string.Format("new DartsScore({0}, {1})", string.Join("", s.Skip(1)), 1);
                    }
                }
            }
            return res;
        }

        private static IEnumerable<DartsSerie> GenerateAllSeries(IEnumerable<DartsScore> scores)
        {
            var result = new List<DartsSerie>();
            foreach (var score in scores)
            {
                var throws = new List<DartsThrow>();
                for (var throwNum = 1; throwNum <= 3; throwNum++)
                {
                    throws.Add(new DartsThrow(throwNum, score));
                }
                result.Add(new DartsSerie(throws));
            }
            return result;
        }

        private static IEnumerable<DartsScore> GenerateAllScores()
        {
            var sectors = GetSectors();
            var factors = GetFactors();
            var result = (from sector in sectors from factor in factors select new DartsScore(sector, factor)).ToList();
            result.AddRange(new[] {new DartsScore(25, 1), new DartsScore(25, 2)});
            return result;
        }

        private static IEnumerable<int> GetFactors()
        {
            var result = new List<int>();
            for (var factor = 1; factor <= 3; factor++)
            {
                result.Add(factor);
            }
            return result;
        }

        private static IEnumerable<int> GetSectors()
        {
            var result = new List<int>();
            for (var sector = 0; sector <= 20; sector++)
            {
                result.Add(sector);
            }
            return result;
        }
    }
}
