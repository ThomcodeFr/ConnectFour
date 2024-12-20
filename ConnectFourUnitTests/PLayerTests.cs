using ConnectFour.Board;
using ConnectFour.Players;

namespace ConnectFourUnitTests
{
    public class PLayerTests
    {
        [Fact]
        public void Initialize_PlayerMustChooseAColor_RedOrYellow()
        {
            // Arrange
            Board board = new Board();

            // Act
            //var player1 = new HumanPlayer("Player 1", "R");

            // Assert
           //player1.Color.Should().Be("R");
            //player2.Color.Should().Be("Y");
        }

    }
}
