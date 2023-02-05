namespace Assets.Scripts.Fighters
{
    public class FighterPieuvre : AbstractEnemyFighter, IFighter
    {
        public FighterPieuvre()
        {
            CurrentHp = MaxHp;
        }
        public string FighterName => "Pieuvre";
        public int MaxHp => 30;
        public string BattleSongName => "Pieuvre Fight";
        public string SpriteName => "pieuvre_de_chambre";
    }
}