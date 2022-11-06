namespace Assets.Scripts.FightingMoves
{
    public class MoveSquirt : IFightingMove
    {
        public string MoveName => "Squirt";

        public int Damage => 12;
        public int Duration => 10;
    }
}