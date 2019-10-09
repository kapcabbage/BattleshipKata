namespace Battleship
{
    public class Cell : ICell
    {
        private int _coordinateX;
        private int _coordinateY;
        private eCellType _cellType;
        private bool _marked;

        public Cell(int x, int y)
        {
            _coordinateX = x;
            _coordinateY = y;
            _cellType = eCellType.Empty;
        }

        public Cell(int x, int y, eCellType cellType)
        {
            _coordinateX = x;
            _coordinateY = y;
            _cellType = cellType;
        }

        public eCellType GetCellType()
        {
            return _cellType;
        }

        public int GetX()
        {
            return _coordinateX;
        } 

        public int GetY()
        {
            return _coordinateY;
        }

        public bool IsMarked()
        {
            return _marked;
        }

        public void Mark()
        {
            _marked = true;
        }

        public void SetCellType(eCellType cellType)
        {
            _cellType = cellType;
        }
    }
}