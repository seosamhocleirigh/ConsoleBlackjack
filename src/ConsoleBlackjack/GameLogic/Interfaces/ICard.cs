namespace ConsoleBlackjack.GameLogic.Interfaces
{
    public interface ICard
    {
        int[] CardValues { get; }
        string CardFace { get; } // TODO: card face up and down text should be private, not really a part of the interface
        string CardBack { get; }
        string CurrentCardAspect { get; }
        bool IsCardFaceUp { get; set; }
    }
}
