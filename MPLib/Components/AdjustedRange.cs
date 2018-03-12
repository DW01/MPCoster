using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLib.Components
{
    // Adjusted range calculations.
    // Take cell range as integer,
    // spit out MP cost contributor.
    class AdjustedRange
    {
        #region GLOBALS
        // Final range output.
        public float FinalRange;
        #endregion

        #region BASIC_SINGLE_SOURCE
        // Basic Adjusted Range calculatio method.
        // Uses Dmax - 1 to calculate range.
        public float CalculateBasicAdjustedRange(int MaximumDistance)
        {
            FinalRange = MaximumDistance - 1;
            return FinalRange;
        }
        #endregion

        #region COMPLEX_SINGLE_SOURCE
        // More complete single-source Adjusted Range calculation.
        public float CalculateSingleSourceAdjustedRange(int MaximumDistance, int NullDistance)
        {
            FinalRange = MaximumDistance - (NullDistance + 1);
            return FinalRange;
        }
        #endregion

        #region BASIC_MULTI_SOURCE
        // Calculate basic Adjusted Range for multiple sources.
        public float CalculateBasicMultiSourceAdjustedRange(int MaximumDistance, int[] Sources)
        {
            // Compunded source variables.
            float Source;
            float AllSources;

            // Main loop.
            foreach (int CurrentSource in Sources)
            {
                Source = CalculateBasicAdjustedRange(MaximumDistance);
                AllSources = Source++;
                FinalRange = AllSources;
            }

            return FinalRange;
        }
        #endregion
    }
}
