using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public interface IConverter<FromType, ToType>
    {
        public ToType Convert(FromType data);

    }
}
