namespace Assets.Scripts.Fighters
{
    public class FighterSpaghettiMonster : AbstractEnemyFighter, IFighter
    {
        public FighterSpaghettiMonster()
        {
            CurrentHp = MaxHp;
        }
        public string FighterName => "Pierre";
        public int MaxHp => 60;
        public string BattleSongName => "Big boss sous sol loop";
        public string SpriteName => "spaghetti_monster";
    }
}