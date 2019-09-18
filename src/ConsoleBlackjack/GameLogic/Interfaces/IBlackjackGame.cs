using ConsoleBlackjack.GameLogic.Common;

namespace ConsoleBlackjack.GameLogic.Interfaces
{
    // TODO: not sure if this is necessary yet
    public interface IBlackjackGame
    {
        void GameIntroduction();
        void GameMenu();
        void StartNewGame(CardGame cardGame);
    }
}
