using System;
using System.Collections.Generic;
using System.Text;
using Converter;
using Tennis;

namespace SetAnalyzer
{
    class SetConverter : IConverter<Set<string>, Set<int>>
    {
        public Set<int> Convert(Set<string> data)
        {
            var matchPoints = data.MatchPoints;

            List<MatchPoint<int>> setMatchPoints = new List<MatchPoint<int>>();

            foreach (var matchPoint in matchPoints)
            {
                var convertedMatchPoint = (int.Parse(matchPoint.MatchPointScore.Item1), int.Parse(matchPoint.MatchPointScore.Item2));

                var matchPoints15InMatchPoint = matchPoint.MatchPoints15;

                List<(int, int)> convertedMatchPoints15 = new List<(int, int)>();

                foreach (var matchPoint15 in matchPoints15InMatchPoint)
                {
                    int first = 0;

                    int second = 0;

                    try
                    {
                        first = int.Parse(matchPoint15.Item1);

                        second = int.Parse(matchPoint15.Item2);
                    }
                    catch
                    {
                        if (matchPoint15.Item1 == "A")
                        {
                            first = 55;

                            second = int.Parse(matchPoint15.Item2);
                        }
                        else if (matchPoint15.Item2 == "A")
                        {
                            second = 55;

                            first = int.Parse(matchPoint15.Item1);
                        }
                    }

                    convertedMatchPoints15.Add((first, second));

                }

                setMatchPoints.Add(new MatchPoint<int>(convertedMatchPoint, convertedMatchPoints15));
            }

            return new Set<int>(setMatchPoints);
        }


    }
}
