namespace Blackjack_Backend.Models
{
    public class Card
    {
        public string Suit { get; set; }
        public string FaceValue { get; set; }
        public int Value { get; set; }
        public bool IsHoleCard { get; set; }

        // Creating an instance of a card
        public Card(string suit, string faceValue, int value)
        {
            Suit = suit;
            FaceValue = faceValue;
            Value = value;
            IsHoleCard = false;
        }
    }
}
