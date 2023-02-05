namespace Assets.Scripts.Fighters
{
    public class FighterJuju : AbstractPlayableFighter, IFighter
    {
        public FighterJuju()
        {
            CurrentHp = MaxHp;
        }
        public string FighterName => "Juju";

        public int MaxHp => 50;

        //Juju a pas de tune spéciale
        public string BattleSongName => "";

        public string SpriteName => "juju";

        public int MaxInventorySize => 4;
    }
}