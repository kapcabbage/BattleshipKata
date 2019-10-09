using System.Collections.Generic;

namespace Battleship
{
    public interface IShip
    {
        eShipType GetShipType();
        void SetCells(IEnumerable<ICell> cells);
        int GetShipLenght();
        int GetShipIdByCell(ICell cell);
        void Hit();
        bool IsSunk();
    }
}