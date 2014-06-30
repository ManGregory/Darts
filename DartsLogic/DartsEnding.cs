using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartsLogic
{
    public static class DartsEnding
    {
        public static List<DartsSerie> PossibleCombinations { get; private set; }    

        static DartsEnding()
        {
            PossibleCombinations = new List<DartsSerie>();
            FillCombinations();
        }

        public static IEnumerable<DartsSerie> GetPossibleEndings(int desiredScore, int dartsRest = 3)
        {
            var result = new List<DartsSerie>();
            foreach (var serie in PossibleCombinations.Where(s => s.GetSum() == desiredScore))
            {
                if (serie.Throws.Last().Score.IsDouble)
                {
                    result.Add(serie);
                }
                else
                {
                    var firstThrows = serie.Throws.Take(serie.Throws.Count - 1);
                    var lastThrow = serie.Throws.Last();
                    var seriesToEnd = GetPossibleEndings(lastThrow.Score.GetSum(), dartsRest);
                    result.AddRange(
                        seriesToEnd.Select(serieToEnd => new DartsSerie(firstThrows.Concat(serieToEnd.Throws))));
                }
            }
            return result.Where(s => s.Throws.Count <= dartsRest);
        }

        private static void FillCombinations()
        {
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(2, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(11, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(3, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(11, 3)), new DartsThrow(2, new DartsScore(14, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(12, 3)), new DartsThrow(2, new DartsScore(13, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(13, 3)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 3)), new DartsThrow(2, new DartsScore(11, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(15, 3)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(9, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(7, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(6, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(5, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(7, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(13, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(25, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(13, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(15, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(25, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(25, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(25, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(25, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(60, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(71, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(104, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(72, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(75, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(12, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(82, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(84, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(14, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(86, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(87, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(88, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(16, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(90, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(91, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(92, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(18, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(94, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(19, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(96, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(97, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(98, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(100, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(25, 2))
                }));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(1, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(1, 1)), new DartsThrow(2, new DartsScore(1, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(2, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(1, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(3, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(3, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(4, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(1, 1)), new DartsThrow(2, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(5, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(3, 1)), new DartsThrow(2, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(6, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(11, 1)), new DartsThrow(2, new DartsScore(1, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(7, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(13, 1)), new DartsThrow(2, new DartsScore(1, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(13, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(9, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(11, 1)), new DartsThrow(2, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(11, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 1)), new DartsThrow(2, new DartsScore(2, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(13, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 1)), new DartsThrow(2, new DartsScore(4, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(14, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(6, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(15, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(7, 1)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(1, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(17, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(3, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 1)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(5, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(7, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(new DartsSerie(new[] {new DartsThrow(1, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(9, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(10, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(11, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(12, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(13, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(15, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 1)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(9, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(10, 3)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(11, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(12, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(13, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(15, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(10, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(9, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(10, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(9, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(11, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(10, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(13, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[] {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(8, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(12, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(14, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(14, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(11, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(10, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(56, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 2)), new DartsThrow(2, new DartsScore(32, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(58, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(59, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(60, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(17, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(14, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(16, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(15, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(66, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(67, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(68, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(69, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(70, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(18, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(20, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(19, 2))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(42, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(40, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(41, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(42, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(46, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(56, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(45, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(46, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(50, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(16, 3)), new DartsThrow(2, new DartsScore(60, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(49, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(53, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(54, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(52, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(56, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(57, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(55, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(19, 1)),
                    new DartsThrow(3, new DartsScore(40, 1))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(60, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(58, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(62, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(60, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(61, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(68, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(66, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(64, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 1)), new DartsThrow(2, new DartsScore(100, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(69, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(67, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(18, 3)), new DartsThrow(2, new DartsScore(74, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(72, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(70, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(19, 3)), new DartsThrow(2, new DartsScore(74, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 2)), new DartsThrow(2, new DartsScore(82, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(73, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(74, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(25, 2)), new DartsThrow(2, new DartsScore(85, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(76, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(77, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(78, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(79, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(80, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(81, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(82, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(83, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(84, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(85, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(86, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(87, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(88, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(89, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(90, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(91, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(92, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(93, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(94, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(95, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(96, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(97, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(98, 1))}));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(20, 3)),
                    new DartsThrow(3, new DartsScore(20, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(17, 3)),
                    new DartsThrow(3, new DartsScore(25, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(18, 3)),
                    new DartsThrow(3, new DartsScore(25, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(19, 3)),
                    new DartsThrow(3, new DartsScore(25, 2))
                }));
            PossibleCombinations.Add(
                new DartsSerie(new[]
                {
                    new DartsThrow(1, new DartsScore(20, 3)), new DartsThrow(2, new DartsScore(20, 3)),
                    new DartsThrow(3, new DartsScore(25, 2))
                }));
        }
    }
}
