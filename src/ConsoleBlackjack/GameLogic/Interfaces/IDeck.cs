namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface IDeck
    {
        void AddCard(ICard card);
        ICard DrawTopCard();
        void Shuffle();
    }
}
