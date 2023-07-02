namespace Blackjack_Backend.Models
{
    public class PlayerHand
    {
        public List<Card> Cards { get; set; }

        // Creating an instance of the player hand
        public PlayerHand()
        {
            Cards = new List<Card>();
        }

        // Checking the player's hand value
        public int CheckPlayerHandValue()
        {
            var handValue = 0;
            var acesCount = 0;

            foreach (var card in Cards)
            {
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

        // Checking if the player busts
        public bool IsBust() => CheckPlayerHandValue() > 21;

    }
}
