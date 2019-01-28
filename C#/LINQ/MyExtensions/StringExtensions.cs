using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.MyExtensions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string text, double defaultValue)
        {
            if (!double.TryParse(text, out double result))
            {
                result = defaultValue;
            }

            return result;

            
        }
    }
}
