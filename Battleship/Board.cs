using Battleship.Consts;
using Battleship.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Board : IBoard
    {
        private Random _randomizer;
        private List<IShip> _ships;
        private List<ICell> _cells;
        private Dictionary<eShipType, int> _shipTypes;

        public Board()
        {
            _ships = new List<IShip>();
            _cells = new List<ICell>();
            _randomizer = new Random();
            _shipTypes = new Dictionary<eShipType, int>();
        }

        public void Initialize()
        {
            FillEmptyBoard();
        }

        public void RandomizeShips()
        {
            PlaceRandomShips();
        }

        private void FillEmptyBoard()
        {
            for (int i = 0; i < Constants.BoardYSize; i++)
            {
                for (int j = 0; j < Constants.BoardXSize; j++)
                {
                    _cells.Add(new Cell(j, i));
                }
            }
        }

        private void PlaceRandomShips()
        {
            foreach (var type in _shipTypes)
            {
                for (int i = 0; i < type.Value; i++)
                {
                    var orientation = GetRandomOrientation();
                    var shipPlaced = false;
                    while (!shipPlaced)
                    {
                        var x = GetRandomCoord(Constants.BoardXSize);
                        var y = GetRandomCoord(Constants.BoardYSize);
                        shipPlaced = PlaceShip(type.Key, orientation, x, y);
                    }
                }
            }
        }

        private int GetRandomCoord(int limit)
        {
            return _randomizer.Next(0, limit);
        }

        private eShipOrientation GetRandomOrientation()
        {
            return _randomizer.Next(0, 2) == 0 ? eShipOrientation.Vertical : eShipOrientation.Horizontal;
        }

        public void EnableShipType(eShipType shipType, int count)
        {
            if (!_shipTypes.ContainsKey(shipType))
            {
                _shipTypes.Add(shipType, count);
            }
        }

        public eShotResult CheckShot(int coordX, int coordY)
        {
            if ((coordX >= Constants.BoardXSize || coordY >= Constants.BoardYSize)
                || (coordX < 0 || coordY < 0))
            {
                return eShotResult.WrongCoordinates;
            }
            else
            {
                var cell = _cells.FirstOrDefault(x => x.GetX() == coordX && x.GetY() == coordY);
                if (cell.GetCellType() == eCellType.Empty)
                {
                    cell.Mark();
                    return eShotResult.Miss;
                }
                else if (cell.GetCellType() == eCellType.Ship)
                {
                    var ship = _ships.FirstOrDefault(x => x.GetShipIdByCell(cell) != 0);
                    cell.Mark();
                    ship.Hit();
                    if (ship.IsSunk())
                    {
                        if (_ships.All(x => x.IsSunk()))
                        {
                            return eShotResult.Win;
                        }
                        return eShotResult.Sink;
                    }
                    return eShotResult.Hit;
                }
                return eShotResult.Miss;
            }
        }

        public bool PlaceShip(eShipType shipType, eShipOrientation shipOrientation, int startX, int startY)
        {
            if (_shipTypes.ContainsKey(shipType) && _ships.Count(x => x.GetShipType() == shipType) < _shipTypes[shipType])
            {
                var shipid = _randomizer.Next(1, 100);
                var ship = new Ship(shipType, shipOrientation, shipid);
                var shipTempCells = new List<ICell>();
                for (int i = 0; i < ship.GetShipLenght(); i++)
                {
                    ICell startingCell = null;
                    if (shipOrientation == eShipOrientation.Horizontal)
                    {
                        startingCell = _cells.FirstOrDefault(x => x.GetX() == startX + i && x.GetY() == startY);
                    }
                    else
                    {
                        startingCell = _cells.FirstOrDefault(x => x.GetX() == startX && x.GetY() == startY + i);
                    }

                    if (startingCell != null && startingCell.GetCellType() != eCellType.Ship)
                    {
                        shipTempCells.Add(startingCell);
                    }
                    else
                    {
                        return false;
                    }
                }
                foreach (var tempCell in shipTempCells)
                {
                    tempCell.SetCellType(eCellType.Ship);
                }

                ship.SetCells(shipTempCells);
                _ships.Add(ship);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintBoard()
        {
            
            for (int i = 0; i < Constants.BoardXSize; i++)
            {
                for (int j = 0; j < Constants.BoardYSize; j++)
                {
                    var cell = _cells.FirstOrDefault(x => x.GetX() == i && x.GetY() == j);
                    if (cell.IsMarked())
                    {
                        Console.Write("X ");
                    }
                    else if (cell.GetCellType() == eCellType.Empty)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("S ");
                    }
                    
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}