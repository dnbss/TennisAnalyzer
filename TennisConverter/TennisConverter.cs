using System;
using System.Collections.Generic;
using System.Text;
using Tennis;

namespace TennisConverter
{
    public static class TennisConverter
    {
        public static IEnumerable<AngleSharp.Dom.> ConvertToSet(List<string> matchPoints)
        {
            /*List<MatchPoint<string>> matchPoints = new List<MatchPoint<string>>();

            for (int i = 1; i < matchPointsInfo.Count; ++i)
            {
                matchPoints.Add(ConvertToMatchPoint(matchPointsInfo[i], matchPoints15[i - 1]));
            }

            return new Set<string>(matchPoints);*/

            List<string> list = new List<string>();

            foreach(var matchPoint in matchPoints)
            {
                if (!matchPoint.Contains(","))
                {
                    list.Add()
                }
            }
        }



        public static MatchPoint<string> ConvertToMatchPoint(string matchPointInfo, string matchPoint15)
        {
            (string, string) matchPointInfoTuple = ConvertToTuple(matchPointInfo);

            List<(string, string)> matchPoints15Tuple = new List<(string, string)>();

            string[] scores15 = matchPoint15.Split(", ");

            foreach(var score in scores15)
            {
                matchPoints15Tuple.Add(ConvertToTuple(score));
            }

            MatchPoint<string> matchPoint = new MatchPoint<string>(matchPointInfoTuple, matchPoints15Tuple);

            return matchPoint;
        }

        private static (string, string) ConvertToTuple(string score)
        {
            try
            {
                string[] points = score.Split('-');

                (string, string) tuple = ("", "");

                if (points[1].Contains("[BP]"))
                {
                    tuple = (points[0], points[1].Replace("[BP]", ""));
                }
                else if (points[1].Contains("[BB]"))
                {
                    tuple = (points[0], points[1].Replace("[BB]", ""));
                }
                else
                {
                    tuple = (points[0], points[1]);
                }

                return tuple;
            }
            catch
            {
                throw new Exception($"Incorrect score!: {score}");
            }

        }
    }
}
