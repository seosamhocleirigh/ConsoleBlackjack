using System.ComponentModel;

namespace ConsoleBlackjack.GameLogic.Common.FrenchCardEnums
{
    public enum CardSuit
    {
        [Description("♥")]
        Hearts,
        [Description("♦")]
        Diamonds,
        [Description("♠")]
        Spades,
        [Description("♣")]
        Clubs
    }

    public enum CardType
    {
        [Description("A")]
        Ace,
        [Description("2")]
        Two,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("J")]
        Jack,
        [Description("Q")]
        Queen,
        [Description("K")]
        King
    }
}