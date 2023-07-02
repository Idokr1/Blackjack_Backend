namespace Blackjack_Backend.Models
{
    public class DealerHand
    {
        public List<Card> Cards { get; set; }
        public bool IsHoleCardHidden { get; set; }

        // Creating an instance of the dealer hand
        public DealerHand()
        {
            Cards = new List<Card>();
            IsHoleCardHidden = true;
        }

        // Checking the dealer's hand value
        public int CheckDealerHandValue()
        {
            var handValue = 0;
            var acesCount = 0;

            foreach (var card in Cards)
            {
                if (card.IsHoleCard)
                    continue;
                if (card.FaceValue == "A")
                    acesCount++;
                else
                    handValue += card.Value;

                for (var i = 0; i < acesCount; i++)
                {
                    if (handValue + 11 <= 21)
                        handValue += 11;
                    else
                        handValue += 1;
                }
            }
            return handValue;
        }

        // Checking whether the dealer should draw another card
        public bool ShouldDealerDrawCard()
        {
            var handValue = CheckDealerHandValue();

            if (handValue < 17)
                return true;
            if (handValue == 17 && HasAce())
                return true;
            return false;
        }

        // Checking if the dealer has Ace in his hand
        public bool HasAce()
        {
            foreach (var card in Cards)
            {
                if (card.FaceValue == "Ace")
                    return true;
            }
            return false;
        }

        // Getting the dealer's list of cards
        public List<Card> GetCards()
        {
            if (IsHoleCardHidden)
            {
                var cardsCopy = new List<Card>();
                cardsCopy.AddRange(Cards.Take(1));
                cardsCopy.Add(new Card("Unknown", "Unknown", 0));
                return cardsCopy;
            }
            else
            {
                return Cards;
            }
        }

        // Checking if the dealer busts
        public bool IsBust() => CheckDealerHandValue() > 21;      

    }
}
