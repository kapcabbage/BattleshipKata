using Battleship.Consts;
using System;

namespace Battleship
{
    public class Game : IGame
    {
        private readonly IBoard _board;
        public Game(IBoard board)
        {
            _board = board;
        }

        public void Initialize()
        {
            _board.Initialize();
            _board.EnableShipType(eShipType.Destroyer, Constants.DestroyerNumber);
            _board.EnableShipType(eShipType.Battleship, Constants.BattleshipNumber);
            _board.RandomizeShips();
        }

        public string Shot(string coordinates)
        {
            try
            {
                coordinates = coordinates.ToUpper();
                var coordinateXChar = coordinates[0];
                var coordinateY = coordinates.Substring(1, coordinates.Length - 1);
                var mappedCoordidateX = CoordinateMapper.Map(coordinateXChar) - 1;
                var mappedCoordinateY = Int32.Parse(coordinateY) - 1;
                var shotResult = _board.CheckShot(mappedCoordidateX, mappedCoordinateY);
                if (shotResult == eShotResult.Hit)
                {
                    return "Hit!";
                }
                else if (shotResult == eShotResult.Miss)
                {
                    return "Miss!";
                }
                else if (shotResult == eShotResult.Sink)
                {
                    return "Sink!";
                }
                else if (shotResult == eShotResult.Win)
                {

                    return "Won!";
                }
                else if (shotResult == eShotResult.WrongCoordinates)
                {

                    return "Wrong coordinates!";
                }

                return "Something's wrong";
            }
            catch(FormatException ex)
            {
                return "Wrong coordinates!";
            }
            catch(Exception ex)
            {
                return "Something's wrong";
            }

        }
    }
}