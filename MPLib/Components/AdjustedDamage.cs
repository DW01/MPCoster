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
            Piercing
        }

        // Intermediate output.
        public float IntermediateOutput;

        // Final output variable.
        public float FinalOutput;


        // Basic damage calculation method.
        // Uses multipliers instead of percentages for more readable calcs.
        public float CalculateAdjustedDamage(float DamageMult, DamageTypes DamageType, bool IsDestructDamage)
        {

            // Refactor part of if-else linguini into a switch statement.
            // thanks, Eebit!
            switch (DamageType)
            {

                // Is damage type normal?
                case DamageTypes.Normal:

                    // Is this Destruct Damage?
                    if (!IsDestructDamage)
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

                    // Yes, it is.
                    else
                    {
                        // Damage multiplier below 2.0.
                        // Also add check for zero-or-lower DamageMults,
                        // since this is impossible.
                        if (DamageMult < 2.0f & DamageMult > 0.0f)
                        {
                            IntermediateOutput = (10 * DamageMult) - 10;

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

                        // Damage multiplier 2.0 or above.
                        else if (DamageMult >= 2.0f)
                        {
                            IntermediateOutput = (20 * DamageMult) - 28;

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

                        // Throw an exception otherwise because
                        // we can't have anything else, dum-dum!
                        else throw new InvalidOperationException("Multiplier can't be zero or less!");
                    }

                    break;

                // Is damage type piercing?
                case DamageTypes.Piercing:

                    // Is this Destruct Damage?
                    if (!IsDestructDamage)
                    {
                        // Calculate damage for Piercing =< 100%.
                        if (DamageMult <= 1.0f & DamageMult > 0.0f)
                        {
                            IntermediateOutput = (15 * DamageMult) - 3;
                            FinalOutput = IntermediateOutput;
                        }

                        // Exceedingly rare case, but one we need to handle anyway.
                        else if (DamageMult >= 1.05f)
                        {
                            IntermediateOutput = (32 * DamageMult) - 20;
                            FinalOutput = IntermediateOutput;
                        }
                    }

                    // Yes it is!
                    else
                    {

                        // Calculate damage for Piercing =< 100%.
                        if (DamageMult <= 1.0f & DamageMult > 0.0f)
                        {
                            IntermediateOutput = (15 * DamageMult) - 3;

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

                        // Exceedingly rare case, but one we need to handle anyway.
                        else if (DamageMult >= 1.05f)
                        {
                            IntermediateOutput = (32 * DamageMult) - 20;

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

                        // Dum-dum scenario #2.
                        else throw new InvalidOperationException("Multiplier can't be zero or less!");
                    }

                    break;

                // Should never actually reach this, but juuust in case...
                default:

                    // ... here's the final dum-dum scenario.
                    throw new InvalidOperationException("Damage type can't be none!");
            }

            return FinalOutput;
        }
    }
}
