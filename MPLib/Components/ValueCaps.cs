using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLib.Components
{
    // ValueCaps.cs
    // General component for setting the Base Value and Minimum Value Soft Cap.
    class ValueCaps
    {
        #region GLOBALS
        // Universally speaking, this should default to 4.
        // However, there will be cases where we'll need to pass in another value.
        // So we declare MinValueCap here and leave it as-is.
        int MinValue;
        int MinValueCap;
        #endregion

        #region BASE_VALUE
        // Set base value.
        // Usually, this should be 4, so this is the default before override.
        public int SetBaseValue()
        {
            MinValue = 4;
            return MinValue;
        }

        // Overrideable base value.
        // Useful for alternative resources like ENG.
        public int SetBaseValue(int BaseValue)
        {
            MinValue = BaseValue;
            return MinValue;
        }
        #endregion

        #region SOFT_CAP
        // Minimum MP value soft cap.
        // Usually we'll use this instead of MinValue directly.
        public int MinValueSoftCap(int PreCalc, int PostCalc)
        {
            MinValueCap = Math.Max(MinValue, PreCalc) + PostCalc;
            return MinValueCap;
        }
        #endregion
    }
}
