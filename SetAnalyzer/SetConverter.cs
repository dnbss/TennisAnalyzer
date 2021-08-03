using System;
using System.Collections.Generic;
using System.Text;
using Converter;
using Tennis;

namespace SetAnalyzer
{
    public class SetConverter : IConverter<Set<string>, Set<int>>
    {
        public Set<int> Convert(Set<string> data)
        {
            var matchPoints = data.MatchPoints;

            List<(int, int)> convertedMatchPoints = new List<(int, int)>();

            for (int i = 0; i < matchPoints.Count; ++i)
            {
                if (matchPoints[i].Item1.Contains("Match Point "))
                {
                    (string, string) s = (matchPoints[i].Item1.Replace("Match Point ", ""), matchPoints[i].Item2);

                    convertedMatchPoints.Add(ConvertOneScore(s));
                }
                else
                {
                    convertedMatchPoints.Add(ConvertOneScore(matchPoints[i]));
                }

            }

            return new Set<int>(convertedMatchPoints, data.NumberSet);
        }

        private (int, int) ConvertOneScore((string, string) matchPoints)
        {
            int first = 0;

            int second = 0;

            try
            {
                first = int.Parse(matchPoints.Item1);

                second = int.Parse(matchPoints.Item2);
            }
            catch
            {
                if (matchPoints.Item1 == "A")
                {
                    first = 55;

                    second = int.Parse(matchPoints.Item2);
                }

                else if (matchPoints.Item2 == "A")
                {
                    second = 55;

                    first = int.Parse(matchPoints.Item1);
                }

            }

            return (first, second);
        }
    }
}
