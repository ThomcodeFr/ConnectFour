namespace ConnectFour.Players
{
    public interface IPlayer
    {
        public char Pawn { get; }
    }

    public abstract class Player : IPlayer
    {
        public abstract char Pawn { get; }
    }
}
