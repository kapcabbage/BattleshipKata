namespace Battleship
{
    public interface ICell
    {
        int GetX();
        int GetY();
        eCellType GetCellType();
        void SetCellType(eCellType cellType);
        void Mark();
        bool IsMarked();
    }
}