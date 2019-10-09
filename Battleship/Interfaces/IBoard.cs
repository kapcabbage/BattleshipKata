using Battleship.Enums;

namespace Battleship
{
    public interface IBoard
    {
        eShotResult CheckShot(int x, int y);
        void Initialize();
        void RandomizeShips();
        void PrintBoard();
        void EnableShipType(eShipType shipType, int count);
        bool PlaceShip(eShipType shipType, eShipOrientation shipOrientation, int startX, int startY);
    }
}