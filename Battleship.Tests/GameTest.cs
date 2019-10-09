using Battleship.Consts;
using Battleship.Enums;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Battleship.Tests
{
    public class GameTest
    {
        private Game _game;
        private Board _board;
        private Dictionary<eShipType, int> _shipTypes;

        public GameTest()
        {
            _board = new Board();
        }

        [Fact]
        public void Should_Shot_Hit_When_Target_Hit()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            _game = new Game(_board);
            var result = _game.Shot("A5");

            result.Should().BeEquivalentTo("Hit!");
        }

        [Fact]
        public void Should_Shot_Miss_When_Target_Miss()
        {
            _board.Initialize();
            _game = new Game(_board);
            var result = _game.Shot("B2");
            result.Should().BeEquivalentTo("Miss!");
        }

        [Fact]
        public void Should_Shot_Warn_When_Coordinate_Exeeds()
        {
            _game = new Game(_board);
            var result = _game.Shot("J13");
            result.Should().BeEquivalentTo("Wrong coordinates!");
        }

        [Fact]
        public void Should_Shot_Sink_When_All_Targets_Cells_Hit()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 2, 1);
            _game = new Game(_board);
            var result = _game.Shot("A5");
            result = _game.Shot("B5");
            result = _game.Shot("C5");
            result = _game.Shot("D5");
            result.Should().BeEquivalentTo("Sink!");
        }

        [Fact]
        public void Should_Game_Win_When_All_Ship_Sunk()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            _game = new Game(_board);
            var result = _game.Shot("A5");
            result = _game.Shot("B5");
            result = _game.Shot("C5");
            result = _game.Shot("D5");
            result.Should().BeEquivalentTo("Won!");
        }
    }
}