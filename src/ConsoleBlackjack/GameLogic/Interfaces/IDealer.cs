namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface IDealer
    {
        void TakeBet(double betAmount);
        double PayoutWinnings();
        void Shuffle();
        ICard DealCardToPlayer();
        ICard DealCardToDealer();
    }
}
