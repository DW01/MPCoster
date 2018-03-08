using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLib.Components
{
    // Adjusted damage calculations.
    // We'll have various methods here to account for Piercing, etc..
    class AdjustedDamage
    {
        // Damage type enumerator.
        public enum DamageTypes
        {
            Normal,
            Piercing,
            Destruct
        }

        // Damage types reference.
        public DamageTypes DamageType;

        // Intermediate output.
        float IntermediateOutput;

        // Final output variable.
        float FinalOutput;

        // Basic damage calculation method.
        // Uses multipliers instead of percentages for more readable calcs.
        public float CalculateAdjustedDamage(float DamageMult)
        {
            // Is damage type normal?
            if (DamageType == DamageTypes.Normal)
            {
                // Damage multiplier below 2.0.
                // Also add check for zero-or-lower DamageMults,
                // since this is impossible.
                if (DamageMult < 2.0f & DamageMult > 0.0f)
                {
                    IntermediateOutput = (10 * DamageMult) - 10;
                }

                // Damage multiplier 2.0 or above.
                else if (DamageMult >= 2.0f)
                {
                    IntermediateOutput = (20 * DamageMult) - 28;
                }

                // Throw an exception otherwise because
                // we can't have anything else, dum-dum!
                else throw new InvalidOperationException("Multiplier can't be zero or less!");

                FinalOutput = IntermediateOutput;
            }

            // Is damage type piercing?
            else if (DamageType == DamageTypes.Piercing)
            {
                // Calculate damage for Piercing =< 100%.
                if (DamageMult <= 1.0f & DamageMult > 0.0f)
                {
                    IntermediateOutput = ((40 * DamageMult) - 4) / 3;
                    FinalOutput = IntermediateOutput;
                }

                // Exceedingly rare case, but one we need to handle anyway.
                else if (DamageMult >= 1.05f)
                {
                    IntermediateOutput = ((20 * DamageMult) - 8) + (((DamageMult - 1) * 5) * 4);
                    FinalOutput = IntermediateOutput;
                }

                // Dum-dum scenario #2.
                else throw new InvalidOperationException("Multiplier can't be zero or less!");
            }

            // Is damage type destruct?
            else if (DamageType == DamageTypes.Destruct)
            {
                // Used in 90% of cases.
                if (IntermediateOutput > 0.0f)
                {
                    FinalOutput = IntermediateOutput * 1.5f;
                }

                // We should rarely see this branch,
                // but if we do, prevent negative mult
                // by simply adding 1 to the value.
                else
                {
                    FinalOutput = IntermediateOutput + 1;
                }
            }

            // Return output.
            return FinalOutput;
        }
    }
}
