namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface IDealer
    {
        ICard DrawTopCard();
        void Shuffle();
    }
}
