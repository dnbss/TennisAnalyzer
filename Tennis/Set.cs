using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Set<T>
    {
        public readonly List<(T, T)> MatchPoints;

        public readonly int NumberSet;

        public Set(List<(T, T)> matchPoints, int numberSet)
        {
            MatchPoints = matchPoints;

            NumberSet = numberSet;
        }

        public List<int> GetMatchPointIndexes()
        {
            var matchPoints = MatchPoints;

            List<int> result = new List<int>();

            for (int i = 0; i < matchPoints.Count - 1; ++i)
            {
                if (matchPoints[i + 1].Item1.ToString() == "0" && matchPoints[i + 1].Item2.ToString() == "0")
                {
                    result.Add(i);
                }
            }

            result.Add(MatchPoints.Count);

            return result;
        }
    }
}
