using System;
using System.Collections.Generic;
using System.Text;
using Tennis;
using System.Linq;

namespace TennisParser
{
    public static class TennisConverter
    {
        public static Set<string> ConvertToSet(IEnumerable<AngleSharp.Dom.IElement> matchPoints, int numberSet)
        {
            List<string> convertedResult = new List<string>();

            List<AngleSharp.Dom.IElement> list = matchPoints.ToList();

            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].ClassName == "mp_info_txt" && i > 0)
                {
                    convertedResult.Add("Match Point " + list[i].TextContent);
                }
                else if (list[i].ClassName == "mp_15")
                {
                    var splitted = list[i].TextContent.Split(", ");

                    for (int j = 0; j < splitted.Length; ++j)
                    {
                        convertedResult.Add(splitted[j]);
                    }
                }
                else
                {
                    convertedResult.Add("Match Point " + list[i].TextContent);
                }
            }

            return new Set<string>(ConvertToTuple(convertedResult), numberSet);

        }

        private static List<(string, string)> ConvertToTuple(List<string> matchPoints)
        {
            List<(string, string)> result = new List<(string, string)>();

            foreach(var score in matchPoints)
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

                    result.Add(tuple);
                }
                catch
                {
                    throw new Exception($"Incorrect score!: {score}");
                }
            }


            return result;
        }
    }
}
