using Battleship.Consts;
using Battleship.Enums;
using FluentAssertions;
using Xunit;

namespace Battleship.Tests
{
    public class BoardTest
    {
        private IBoard _board;
        public BoardTest()
        {
            _board = new Board();
        }

        [Fact]
        public void Should_Board_Not_PlaceShip_When_ShipType_IsNot_Enabled()
        {
            _board.Initialize();
            var result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result.Should().BeFalse();

        }

        [Fact]
        public void Should_Board_PlaceShip_When_ShipType_Enabled()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            var result =  _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_Board_Not_PlaceShip_When_Ship_Overlaps()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            var result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result.Should().BeFalse();
        }

        [Fact]
        public void Should_Board_PlaceShip_When_Ship_Not_Overlap()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            var result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 2, 1);
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_Board_Not_PlaceShip_When_ShipNumber_Is_Being_Exeeded()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, 1);
            var result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 0, 4);
            result = _board.PlaceShip(eShipType.Destroyer, eShipOrientation.Horizontal, 2, 1);
            result.Should().BeFalse();
        }

    }
}