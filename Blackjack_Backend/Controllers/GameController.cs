using Blackjack_Backend.Models;
using Blackjack_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blackjack_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        // Start New Game - Post Method
        [HttpPost("start-new-game")]
        public ActionResult StartNewGame()
        {
            try
            {
                _gameService.StartNewGame();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // End Game - Post Method
        [HttpPost("end-game")]
        public ActionResult<Game> EndGame()
        {
            try
            {
                _gameService.EndGame();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Hit - Post Method
        [HttpPost("hit")]
        public ActionResult<Game> PlayerHit()
        {
            try
            {
                _gameService.PlayerHits();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Stand - Post Method
        [HttpPost("stand")]
        public ActionResult<Game> PlayerStand()
        {
            try
            {
                _gameService.PlayerStand();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Dealer Playes - Post Method
        [HttpPost("dealer-play")]
        public ActionResult<Game> DealerPlay()
        {
            try
            {
                _gameService.DealerPlayes();
                return Ok(_gameService.GetGame());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Player Busts - Get Method
        [HttpGet("player-bust")]
        public ActionResult<Game> PlayerBust()
        {
            try
            {
                _gameService.PlayerBust();
                return Ok(_gameService.PlayerBust());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Checking Player Hand - Get Method
        [HttpGet("check-player-hand")]
        public ActionResult<Game> CheckPlayerHand()
        {
            try
            {
                return Ok(_gameService.CheckPlayerHand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Checking Dealer Hand - Get Method
        [HttpGet("check-dealer-hand")]
        public ActionResult<int> CheckDealerHand()
        {
            try
            {
                return Ok(_gameService.CheckDealerHand());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
