using ConnectFour.Board;
using FluentAssertions;

namespace ConnectFourUnitTests
{
    public class BoardTests
    {
        [Fact]
        public void Initialize_ReturnBoardGame()
        {
            // Arrange
            int rows = 6;
            int columns = 7;

            // Act 
            Board board = new Board();

            // Assert
            board.Grid.Should().NotBeNull();
            board.Grid.Should().HaveCount(rows * columns);
        }

        [Fact]
        public void PlaceOnBoard_OnePiece_GoodPlacement()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.PlaceOnBoard(0, CellValue.R);

            // Assert
            board.Grid.First(c => c.Row == 0 && c.Column == 0).Value.Should().Be(CellValue.R);
        }

        [Fact]
        public void PlaceOnBoard_OnePiece_BadPlacementOutOfRange()
        {
            // Arrange
            Board board = new Board();

            // Act & Assert
            Action act = () => board.PlaceOnBoard(8, CellValue.R);
            act.Should().Throw<ArgumentException>().WithMessage("Invalid column index");
        }


        [Fact]
        public void PlaceOnBoard_OnePiece_BadPlacementPlaceOccuped()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.PlaceOnBoard(0, CellValue.R);

            // Assert
            Action act = () => board.PlaceOnBoard(0, CellValue.Y);

        }

        [Fact]
        public void PlaceOnBoard_OnePiece_BadPlacementColumnFull()
        {
            // Arrange
            Board board = new Board();

            // Act
            for (int i = 0; i < 6; i++)
            {
                board.PlaceOnBoard(0, CellValue.R);
            }
            // Assert
          Action act = () => board.PlaceOnBoard(0, CellValue.Y);
            act.Should().Throw<InvalidOperationException>().WithMessage("Column is full");
        }

    }
}