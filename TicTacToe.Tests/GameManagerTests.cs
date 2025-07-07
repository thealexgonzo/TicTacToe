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
            var manager = GetGameManager();

            var result = manager.PlaceSymbol(3, manager._player1.symbol, manager._player1);

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
    }
}
