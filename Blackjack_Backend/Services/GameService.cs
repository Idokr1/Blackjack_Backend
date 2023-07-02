using Blackjack_Backend.Models;

namespace Blackjack_Backend.Services
{
    public class GameService
    {
        private readonly Game _game;

        public GameService(Game game)
        {
            _game = game;
        }

        // Starting a new game
        public void StartNewGame()
        {
            _game.DealerHand.Cards.Clear();
            _game.DealerHand.IsHoleCardHidden = true;
            _game.Winner = null;
            _game.PlayerHand.Cards.Clear();

            DealInitialCards();
        }

        // Dealing initial cards and checking if someone won at the beginning
        public void DealInitialCards()
        {
            _game.Deck.Shuffle();
            _game.DealerHand.Cards.Add(_game.Deck.DrawCard());
            _game.DealerHand.Cards.Add(_game.Deck.DrawCard(true));
            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());
            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());

            if (_game.DealerHand.CheckDealerHandValue() == 21 && _game.DealerHand.CheckDealerHandValue() == 21)
                _game.Winner = "Dealer";

            else if (_game.PlayerHand.CheckPlayerHandValue() == 21)
                _game.Winner = "Player";

            else if (_game.DealerHand.CheckDealerHandValue() == 21)
                _game.Winner = "Dealer";
        }

        // The dealer playes
        public void DealerPlayes()
        {
            if (_game.Winner != null)
                _game.Winner = "Dealer";

            _game.DealerHand.Cards[1].IsHoleCard = false;

            while (_game.DealerHand.ShouldDealerDrawCard())
            {
                _game.DealerHand.Cards.Add(_game.Deck.DrawCard());
            }

        }

        // Player hits
        public void PlayerHits()
        {
            if (_game.Winner != null)
                throw new Exception("The game has already been won by " + _game.Winner);

            if (_game.PlayerHand.IsBust())
                throw new Exception("Player has been bust");

            _game.PlayerHand.Cards.Add(_game.Deck.DrawCard());
        }

        // Player stands
        public void PlayerStand()
        {
            if (_game.Winner != null)
                throw new Exception("The game has already been won by " + _game.Winner);

            DealerPlayes();
        }

        // Player busts
        public bool PlayerBust()
        {
            if (_game.Winner != null)
                throw new Exception("The game has already been won by " + _game.Winner);

            return _game.PlayerHand.IsBust();
        }

        // Ending the game
        public void EndGame()
        {
            if (_game.PlayerHand.IsBust())
                _game.Winner = "Dealer";

            else if (_game.DealerHand.IsBust() || _game.PlayerHand.CheckPlayerHandValue() > _game.DealerHand.CheckDealerHandValue())
                _game.Winner = "Player";

            else if (_game.DealerHand.CheckDealerHandValue() > _game.PlayerHand.CheckPlayerHandValue())
                _game.Winner = "Dealer";

            else
                _game.Winner = "Dealer";
        }

        // Checking player hand
        public int CheckPlayerHand() => _game.PlayerHand.CheckPlayerHandValue();


        // Checking dealer hand
        public int CheckDealerHand() => _game.DealerHand.CheckDealerHandValue();

        // Getting Game
        public Game GetGame() => _game;

    }
}
