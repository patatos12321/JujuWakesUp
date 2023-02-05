namespace Assets.Scripts.Fighters
{
    public class FighterDeviljoe : AbstractEnemyFighter, IFighter
    {
        public FighterDeviljoe()
        {
            CurrentHp = MaxHp;
        }
        public string FighterName => "Deviljoe";
        public int MaxHp => 1000;
        public string BattleSongName => "Big boss sous sol loop";
        public string SpriteName => "deviljoe";
    }
}