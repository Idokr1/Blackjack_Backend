namespace Blackjack_Backend.Models
{
    public class Deck
    {
        private List<Card> cards;
        private int currentCardIndex;


        // Creating a deck of 52 cards and shuffling it
        public Deck()
        {
            cards = new List<Card>();
            foreach (var suit in new string[] { "C", "D", "H", "S" }) // Clubs, Diamonds, Hearts, Spades
            {
                for (var i = 2; i <= 10; i++)
                {
                    cards.Add(new Card(suit, i.ToString(), i));
                }
                cards.Add(new Card(suit, "J", 10)); // Jack
                cards.Add(new Card(suit, "Q", 10)); // Queen
                cards.Add(new Card(suit, "K", 10)); // King
                cards.Add(new Card(suit, "A", 1)); // Ace
            }

            Shuffle();
        }

        // Shuffling the cards
        public void Shuffle()
        {
            var random = new Random();
            for (var i = cards.Count - 1; i > 0; i--)
            {
                var j = random.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }

            currentCardIndex = 0;
        }

        // Drawing a card
        public Card DrawCard(bool IsHoleCard = false)
        {
            if (currentCardIndex >= cards.Count)
            {
                Shuffle();
            }

            var card = cards[currentCardIndex];
            currentCardIndex++;

            if (IsHoleCard)
                card.IsHoleCard = true;
            else
                card.IsHoleCard = false;

            return card;
        }
    }
}
