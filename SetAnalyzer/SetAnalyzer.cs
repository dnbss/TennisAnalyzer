using System;
using System.Collections.Generic;
using System.Text;
using Analyzer;
using Tennis;

namespace SetAnalyzer
{
    public class SetAnalyzer : IAnalyzer<List<int>, Set<string>>
    {
        public List<int> Analyze(Set<string> set)
        {
            List<int> result = new List<int>();

            result.Add(0);

            SetConverter setConverter = new SetConverter();

            Set<int> convertedSet = setConverter.Convert(set);

            var matchPoints = convertedSet.MatchPoints;

            for (int i = 0; i < matchPoints.Count; ++i)
            {
                var matchPoints15 = convertedSet.MatchPoints[i].MatchPoints15;

                for (int j = 0; j < matchPoints15.Count - 1; ++j)
                {
                    int sub = (matchPoints15[j + 1].Item1 - matchPoints15[j].Item1) 
                        - (matchPoints15[j + 1].Item2 - matchPoints15[j].Item2);

                    int analyzedPoint15 = sub < 0 ? (int)Math.Floor((decimal)sub / 15) : (int)Math.Ceiling((decimal)sub / 15);

                    result.Add(result[result.Count - 1] + analyzedPoint15);
                }

                //int analyzedMatchPoint = Math.Sign(matchPoints[i].MatchPointScore.Item1 - matchPoints[i].MatchPointScore.Item2);

                int analyzedMatchPoint = Math.Sign(matchPoints15[matchPoints15.Count - 1].Item1 - matchPoints15[matchPoints15.Count - 1].Item2);

                result.Add(result[result.Count - 1] + analyzedMatchPoint);
            }

            return result;
        }


    }
}
