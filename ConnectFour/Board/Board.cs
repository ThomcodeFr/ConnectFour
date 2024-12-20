
namespace ConnectFour.Board
{
    public class Board
    {
        public List<Cell> Grid { get; private set; }

        public Board()
        {

            Grid = InitalizeGrid();
        }

        private List<Cell> InitalizeGrid()
        {
            var grid = new List<Cell>();

            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    grid.Add(new Cell(row, column));
                }
            }
            return grid;
        }

        public void PlaceOnBoard(int column, CellValue placement)
        {
            if (column < 0 || column > 7)
            {
                throw new ArgumentException("Invalid column index");
            }

            // We looking for cells in column
            Cell? columnCells = Grid
                .Where(c => c.Column == column && c.Value == CellValue.Empty)
                .OrderBy(c => c.Row)
                .FirstOrDefault();

            // If no free cell found, that mean column is full
            if (columnCells != null)
            {
                columnCells.Value = placement;
            }
            else
            {
                throw new InvalidOperationException("Column is full");
            }


            // Looking first empty cell in column
            var firstEmptyCell = columnCells.FirstOrDefault(c => c.Value == CellValue.Empty);

            if (firstEmptyCell != null)
            {
                if (firstEmptyCell.Row < 5 && columnCells.Any(c => c.Row > firstEmptyCell.Row && c.Value != CellValue.Empty))
                {
                    throw new InvalidOperationException("Cell is already occupied");
                }
            }

            firstEmptyCell.Value = placement;
        }
    }
}
