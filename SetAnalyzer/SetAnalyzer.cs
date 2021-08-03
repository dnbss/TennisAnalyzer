using System;
using System.Collections.Generic;
using System.Text;
using Analyzer;
using Tennis;

namespace SetAnalyzer
{
    public class SetAnalyzer : IAnalyzer<List<int>, Set<int>>
    {
        public List<int> Analyze(Set<int> set)
        {
            List<int> result = new List<int>();

            List<int> matchPointIndexes = set.GetMatchPointIndexes();

            result.Add(0);

            for (int k = 0; k < matchPointIndexes.Count - 1; ++k)
            {
                for (int i = matchPointIndexes[k] + 1; i < matchPointIndexes[k + 1] - 1; ++i)
                {
                    int sub = (set.MatchPoints[i + 1].Item1 - set.MatchPoints[i].Item1)
                        - (set.MatchPoints[i + 1].Item2 - set.MatchPoints[i].Item2);

                    int analyzedPoint = sub > 0 ? (int)Math.Ceiling((decimal)sub / 15) : (int)Math.Floor((decimal)sub / 15);

                    result.Add(result[result.Count - 1] + Math.Sign(sub));
                }

                if (k != matchPointIndexes.Count - 2)
                {
                    int t = set.MatchPoints[matchPointIndexes[k + 1] - 1].Item1
                - set.MatchPoints[matchPointIndexes[k + 1] - 1].Item2;

                    result.Add(result[result.Count - 1] + Math.Sign(t));
                }
            }

            return result;
        }
    }
}
