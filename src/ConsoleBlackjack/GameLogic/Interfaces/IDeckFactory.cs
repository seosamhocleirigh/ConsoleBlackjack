using System.Collections.Generic;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface IDeckFactory<ICard>
    {
        IList<ICard> GenerateDeck();
    }
}
