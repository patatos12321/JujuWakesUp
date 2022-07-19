namespace Assets.Scripts.FightingMoves
{
    public class MoveSquirt : IFightingMove
    {
        public string MoveName => "Squirt";

        public int Damage => 6;
        public int Duration => 8;
    }
}