using Assets.Scripts.FightingGear;
using Assets.Scripts.FightingMoves;
using System.Collections.Generic;

namespace Assets.Scripts.Fighters
{
    public interface IFighter
    {
        string FighterName { get; }
        int MaxHp { get; }
        int CurrentHp { get; set; }
        List<IFightingMove> FightingMoves { get; }
        List<IFightingGear> FightingGear { get; }
        string BattleSongName { get; }
        string SpriteName { get; }
        int MaxInventorySize { get; }
    }
}