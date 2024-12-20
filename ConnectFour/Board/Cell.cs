namespace ConnectFour.Board
{
    public class Cell(int Row, int Column)
    {
        public int Row { get; set; } = Row;
        public int Column { get; set; } = Column;
        public CellValue Value { get; set; } = CellValue.Empty;
    }

    public enum CellValue
    {
        Empty,
        R,
        Y
    }

    

}
