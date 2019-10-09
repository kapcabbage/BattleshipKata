using Battleship.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Ship : IShip
    {
        private eShipType _shipType;
        private eShipOrientation _shipOrientation;
        private IEnumerable<ICell> _cells;
        private int _health;
        private int _length;
        private int _shipId;

        public Ship(eShipType shipType, eShipOrientation shipOrientation, int id)
        {
            _shipType = shipType;
            _shipOrientation = shipOrientation;
            _length = (int)_shipType;
            _health = _length;
            _shipId = id;
            _cells = new List<ICell>();
        }

        public int GetShipIdByCell(ICell cell)
        {
            if (_cells.Any(x => x.GetX() == cell.GetX() && x.GetY() == cell.GetY()))
            {
                return _shipId;
            }
            return 0;
        }

        public int GetShipLenght()
        {
            return _length;
        }

        public eShipType GetShipType()
        {
            return _shipType;
        }

        public void Hit()
        {
            --_health;
        }

        public bool IsSunk()
        {
            return _health == 0;
        }

        public void SetCells(IEnumerable<ICell> cells)
        {
            _cells = cells;
        }


    }
}