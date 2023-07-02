namespace Blackjack_Backend.Models
{
    public class Game
    {
        public DealerHand DealerHand { get; set; }
        public PlayerHand PlayerHand { get; set; }
        public Deck Deck { get; set; }
        public string? Winner { get; set; }

        // Creating an instance of a game
        public Game()
        {
            DealerHand = new DealerHand();
            PlayerHand = new PlayerHand();
            Deck = new Deck();
        }
    }
}
