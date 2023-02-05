namespace Assets.Scripts.Fighters
{
    public class FighterPeanut : AbstractPlayableFighter, IFighter
    {
        public FighterPeanut()
        {
            CurrentHp = MaxHp;
        }
        public string FighterName => "Peanut";
        public int MaxHp => 20;
        //Peanut a pas de tune sp�ciale
        public string BattleSongName => "";
        public string SpriteName => "Peanut";
        public int MaxInventorySize => 0;
    }
}