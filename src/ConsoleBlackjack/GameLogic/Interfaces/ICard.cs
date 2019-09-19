namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface ICard
    {
        int[] CardValues { get; }
        string CardFaceUpName { get; }
        string CardFaceDownText { get; }
    }
}
