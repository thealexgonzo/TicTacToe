using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;
using TicTacToe.UI;
using TicTacToe.UI.Implementations;
using TicTacToe.UI.Interfaces;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class GameManagerTests
    {
        public IPlayer GetPlayerOne()
        {
            return new HumanPlayer();
        }

        public IPlayer GetPlayerTwo()
        {
            return new ComputerPlayer();
        }

        public GameManager GetGameManager()
        {
            var p1 = GetPlayerOne();
            p1.symbol = PlayerSymbols.X;

            var p2 = GetPlayerTwo();
            p2.symbol = PlayerSymbols.O;

            return new GameManager(p1, p2);
        }

        [Test]
        public void PlaceSymbol_ReturnsSymbolPlaces()
        {
            var manager1 = new GameManager(new HumanPlayer(), new ComputerPlayer());

            var result = manager1.PlaceSymbol(3, manager1._player1.symbol, manager1._player1);

            Assert.That(result, Is.EqualTo(Result.SymbolPlaced));
        }

        [Test]
        public void PlaceSymbol_ReturnsInvalidOverlap()
        {
            var manager = GetGameManager();
            manager.PlaceSymbol(1, manager._player1.symbol, manager._player1);
            var result = manager.PlaceSymbol(1, manager._player2.symbol, manager._player2);

            Assert.That(result, Is.EqualTo(Result.InvalidOverlap));
        }

        [Test]
        public void PlaceSymbol_ReturnsInvalidOffGrid()
        {
            var manager = GetGameManager();
            var result = manager.PlaceSymbol(20, manager._player2.symbol, manager._player2);

            Assert.That(result, Is.EqualTo(Result.InvalidOffGrid));
        }

        [Test]
        public void DetermineResult_XWins()
        {
            var Board = GameManager.Board;
            var manager = GetGameManager();

            if((Board[0] == "X" && Board[1] == "X" && Board[2] == "X") ||
                (Board[3] == "X" && Board[4] == "X" && Board[5] == "X") ||
                (Board[6] == "X" && Board[7] == "X" && Board[8] == "X") ||
                (Board[0] == "X" && Board[4] == "X" && Board[8] == "X") ||
                (Board[2] == "X" && Board[4] == "X" && Board[6] == "X") ||
                (Board[0] == "X" && Board[3] == "X" && Board[6] == "X") ||
                (Board[1] == "X" && Board[4] == "X" && Board[7] == "X") ||
                (Board[2] == "X" && Board[5] == "X" && Board[8] == "X"))
            {
                Assert.That(manager.determineResult(), Is.EqualTo(Result.XWins));
            }
        }

        [Test]
        public void DetermineResult_OWins()
        {
            var Board = GameManager.Board;
            var manager = GetGameManager();

            if ((Board[0] == "O" && Board[1] == "O" && Board[2] == "O") ||
                (Board[3] == "O" && Board[4] == "O" && Board[5] == "O") ||
                (Board[6] == "O" && Board[7] == "O" && Board[8] == "O") ||
                (Board[0] == "O" && Board[4] == "O" && Board[8] == "O") ||
                (Board[2] == "O" && Board[4] == "O" && Board[6] == "O") ||
                (Board[0] == "O" && Board[3] == "O" && Board[6] == "O") ||
                (Board[1] == "O" && Board[4] == "O" && Board[7] == "O") ||
                (Board[2] == "O" && Board[5] == "O" && Board[8] == "O"))
            {
                Assert.That(manager.determineResult(), Is.EqualTo(Result.OWins));
            }
        }

        [Test]
        public void DetermineResult_Draw()
        {
            var Board = GameManager.Board;
            var manager = GetGameManager();

            if (!Board.Contains(" ") && !Board.Contains(null))
            {
                Assert.That(manager.determineResult(), Is.EqualTo(Result.Draw));
            }
        }
    }
}
