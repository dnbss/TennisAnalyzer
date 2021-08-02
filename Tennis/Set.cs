using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis
{
    public class Set<T>
    {
        public readonly List<MatchPoint<T>> MatchPoints;

        public Set(List<MatchPoint<T>> matchPoints)
        {
            MatchPoints = matchPoints;
        }
    }
}
