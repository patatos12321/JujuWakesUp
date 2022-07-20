namespace Assets.Scripts.FightingMoves
{
    public class MoveMindDestruction : IFightingMove
    {
        public string MoveName => "Destroy mind";

        public int Damage => 60;
        public int Duration => 20;
    }
}