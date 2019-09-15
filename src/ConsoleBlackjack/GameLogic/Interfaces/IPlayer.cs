using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface IPlayer
    {
        double PlaceBet(double betAmountToWithDrawFromPlayersMoneyPot);
        void Hit(ICard card);
        void Stay();
    }
}
