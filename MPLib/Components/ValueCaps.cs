using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLib.Components
{
    class ValueCaps
    {
        // Universally speaking, this should default to 4.
        // However, there will be cases where we'll need to pass in another value.
        // So we declare MinValueCap here and leave it as-is.
        int MinValue;
        int MinValueCap;

        // Minimum MP value soft cap.
        // Usually we'll use this instead of MinValue directly.
        public int MinValueSoftCap(int PreCalc, int PostCalc)
        {
            MinValueCap = Math.Max(MinValue, PreCalc) + PostCalc;
            return MinValueCap;
        }
    }
}
