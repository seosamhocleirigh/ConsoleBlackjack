using ConsoleBlackjack.GameLogic.Common.FrenchCardEnums;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBlackjack.GameLogic.Classes
{
    public class BlackjackHand : List<FrenchCard>
    {
        public int SumCardValues()
        {
            var sum = 0;
            foreach (var card in this)
            {
                if (card.IsCardFaceUp)
                    sum += card.CardValues.Max();
            }

            if (sum > 21 && this.Any(c => c.CardType == CardType.Ace))
            {
                var numberOfAces = this.Count(c => c.CardType == CardType.Ace);
                sum -= numberOfAces * 10;
            }

            return sum;
        }
    }
}
