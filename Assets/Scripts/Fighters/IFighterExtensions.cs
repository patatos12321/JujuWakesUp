namespace Assets.Scripts.Fighters
{
    public static class IFighterExtensions
    {
        public static bool IsAlive(this IFighter fighter)
        {
            return fighter.CurrentHp > 0;
        }
    }
}