using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class MatchPoint<T>
    {
        public readonly (T, T) MatchPointScore;

        public readonly List<(T, T)> MatchPoints15;

        public MatchPoint((T, T) matchPointScore, List<(T, T)> matchPoints15)
        {
            MatchPointScore = matchPointScore;

            MatchPoints15 = matchPoints15;
        }
    }
}
