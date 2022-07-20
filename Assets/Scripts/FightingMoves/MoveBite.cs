namespace Assets.Scripts.FightingMoves
{
    public class MoveBite : IFightingMove
    {
        public string MoveName => "Bite";
        public int Damage => 6;
        public int Duration => 4;
    }
}