﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandExercise.Classes.Hands
{
    internal class TwoPair : SpecifiedPokerHand
    {
        public CardValue HighestPairValue
        {
            get
            {
                var pairs = pokerHand.GroupBy(c => c.Value)
                    .Select(g => new { Key = g.Key, Weighting = GetCardValueWeighting(g.Key), Count = g.Count() })
                    .Where( o => o.Count == 2);

                var highestPair = pairs.Single(o => o.Weighting == pairs.Select(o1 => o1.Weighting).Max());

                return highestPair.Key;
            }
        }

        public CardValue LowestPairValue
        {
            get
            {
                var pairs = pokerHand.GroupBy(c => c.Value)
                    .Select(g => new { Key = g.Key, Weighting = GetCardValueWeighting(g.Key), Count = g.Count() })
                    .Where(o => o.Count == 2);

                var lowestPair = pairs.Single(o => o.Weighting == pairs.Select(o1 => o1.Weighting).Min());

                return lowestPair.Key;
            }
        }

        public Card FifthCard
        {
            get
            {
                var groups = pokerHand.GroupBy(c => c.Value);
                return groups.Where(g => g.Count() == 1).Single().First();
            }
        }

        public TwoPair(PokerHand pokerHand) : base(pokerHand)
        {
            base.Weighting = 3;
        }

        public override int CompareTo(SpecifiedPokerHand other)
        {
            if (other is TwoPair)
            {
                TwoPair otherTwoPair = other as TwoPair;

                if (this.HighestPairValue != otherTwoPair.HighestPairValue)
                    return CompareSingleCard(this.HighestPairValue, otherTwoPair.HighestPairValue);
                
                else if (this.LowestPairValue != otherTwoPair.LowestPairValue)
                    return CompareSingleCard(this.LowestPairValue, otherTwoPair.LowestPairValue);
                
                else if (this.FifthCard.Value != otherTwoPair.FifthCard.Value)
                    return CompareSingleCard(this.FifthCard.Value, otherTwoPair.FifthCard.Value);
                
                else
                    return 0;
            }
            else
            {
                return base.CompareTo(other);
            }
        }

        private int CompareSingleCard(CardValue myValue, CardValue otherValue)
        {
            int myWeighting = GetCardValueWeighting(myValue);
            int otherWeighting = GetCardValueWeighting(otherValue);

            return myWeighting.CompareTo(otherWeighting);
        }

        private int GetCardValueWeighting(CardValue cardValue)
        {
            if (cardValue == CardValue.Ace)
                return 1000;
            else
                return ((int)cardValue);
        }
    }
}
