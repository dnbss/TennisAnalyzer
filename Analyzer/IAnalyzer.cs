using System;
using System.Collections.Generic;
using System.Text;
using Tennis;


namespace Analyzer
{
    public interface IAnalyzer<U, V> 
        where U : class
        where V : class 
    {

        U Analyze(V data);

    }
}
