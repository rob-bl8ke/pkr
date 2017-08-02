﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class Flush : SpecifiedPokerHand
    {
        public Flush(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 6;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is Flush)
            {
                for (int x = this.pokerHand.Count - 1; x >=0; x--)
                {
                    int val = this[x].CompareTo(other[x]);
                    if (val != 0)
                        return val;
                }

                return 0;
            }
            else
            {
                return base.CompareTo(other);
            }
        }
    }
}
